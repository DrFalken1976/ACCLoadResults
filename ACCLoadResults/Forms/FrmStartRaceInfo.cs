using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using NetCoreAudio;
using Timer = System.Windows.Forms.Timer;

namespace ACCLoadResults.Forms
{
    public partial class FrmStartRaceInfo : Form
    {
        private int currentRow;
        private float scrollOffset;
        private Timer scrollTimer;
        private Timer delayTimer;
        private Font f1Font;
        private Font f1FontPos;

        List<vGetQualyResult> _oClassf;

        private int pilotoWidth;
        private int pilotoHeight;
        private float scrollStep = 20f;
        private int delaySeconds = 4;
        private bool mostrarIntro = true;

        private Player player;

        public FrmStartRaceInfo()
        {

            //Play Music
            player = new Player();

            try
            {
                string rutaMp3 = Path.Combine(AppContext.BaseDirectory, "Assets", "f1.mp3");
                player.Play(rutaMp3);
            }
            catch (Exception ex)
            {
            }

            //Get LeaderBoard
            _oClassf = (from Data in Globals.oData.vGetQualyResult                                                
                        orderby Data.Position ascending
                        select Data).ToList();

            InitializeComponent();

            Timer introTimer = new Timer();
            introTimer.Interval = 5000; // 5 segundos
            introTimer.Tick += (s, e) =>
            {
                introTimer.Stop();
                mostrarIntro = false;
                Invalidate(); // Redibuja para mostrar la parrilla
                PrepararAnimacion();
            };
            introTimer.Start();

            this.DoubleBuffered = true;
            CargarPilotos();
            CargarFuenteF1();
            CalcularTamañoPiloto();            

        }

        private void FrmStartRaceInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Stop();
        }


        private void CargarFuenteF1()
        {
            f1Font = new Font("Formula1 Display-Regular", 18, FontStyle.Bold); // Sustituye por "Formula1 Display Regular" si la tienes
            f1FontPos = new Font("Formula1 Display-Regular", 80, FontStyle.Bold); // Sustituye por "Formula1 Display Regular" si la tienes
        }

        private void CalcularTamañoPiloto()
        {
            pilotoHeight = this.ClientSize.Height + 220;
            pilotoWidth = this.ClientSize.Width / 2 - 90;
        }

        private void CargarPilotos()
        {
            // No invertimos la lista aquí, porque el scroll lo hará
            currentRow = 0;
            scrollOffset = 0;
        }

        private void PrepararAnimacion()
        {
            delayTimer = new Timer();
            delayTimer.Interval = delaySeconds * 1000;
            delayTimer.Tick += (s, e) =>
            {
                delayTimer.Stop();
                scrollTimer.Start();
            };

            scrollTimer = new Timer();
            scrollTimer.Interval = 30;
            scrollTimer.Tick += (s, e) =>
            {
                scrollOffset += scrollStep;
                Invalidate();

                float targetOffset = (currentRow + 1) * pilotoHeight;
                if (scrollOffset >= targetOffset)
                {
                    scrollOffset = targetOffset;
                    scrollTimer.Stop();
                    currentRow++;

                    if (currentRow < Math.Ceiling(_oClassf.Count / 2.0))
                        delayTimer.Start();
                }
            };

            delayTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mostrarIntro)
                DibujarIntro(e.Graphics);
            else
                DibujarFilaActual(e.Graphics);

        }


        private void DibujarFilaActual(Graphics g)
        {
            int totalRows = (int)Math.Ceiling(_oClassf.Count / 2.0);

            for (int row = 0; row < totalRows; row++)
            {
                float y = row * pilotoHeight - scrollOffset;

                if (y + pilotoHeight < 0 || y > this.ClientSize.Height) continue;

                int i = row * 2;

                for (int j = 0; j < 2 && (i + j) < _oClassf.Count; j++)
                {
                    // 🟢 Invertimos el orden: el piloto con mejor posición va a la izquierda
                    int x = j == 0
                        ? this.ClientSize.Width / 4 - pilotoWidth / 2
                        : 3 * this.ClientSize.Width / 4 - pilotoWidth / 2;

                    vGetQualyResult p = _oClassf[i + j];

                    g.DrawString(p.Position.ToString(), f1FontPos, Brushes.Gold, x, (int)y + 20);

                    if (p.Photo != null)
                    { 
                        using (MemoryStream ms = new MemoryStream(p.Photo))
                        {
                            Image img = Image.FromStream(ms);
                            g.DrawImage(img, x, (int)y + 20, pilotoWidth, pilotoHeight - 140);
                        }
                    }

                    int textY = (int)y + pilotoHeight - 110;
                    g.DrawString(p.Driver, f1Font, Brushes.White, x, textY);

                    if (p.Position == 1)
                        g.DrawString($"Best Lap: {p.BestLap}", f1Font, Brushes.Violet, x, textY + 30);
                    else
                        g.DrawString($"Best Lap: {p.BestLap}", f1Font, Brushes.Yellow, x, textY + 30);

                    g.DrawString($"Campeonato: {p.GeneralPos}º", f1Font, Brushes.LightBlue, x, textY + 60);
                }
            }
        }

        private void DibujarIntro(Graphics g)
        {
            string titulo = "FalkenCUP";
            string circuito = _oClassf[0].trackName.Trim();
            string subtitulo = "Qualify results";
            
            Font fontTitulo = new Font("Formula1 Display-Regular", 60, FontStyle.Bold);
            Font fontCircuito = new Font("Formula1 Display-Regular", 40, FontStyle.Bold);
            Font fontSubtitulo = new Font("Formula1 Display-Regular", 30, FontStyle.Bold);

            SizeF sizeTitulo = g.MeasureString(titulo, fontTitulo);
            SizeF sizeCircuito = g.MeasureString(circuito, fontCircuito);
            SizeF sizeSubtitulo = g.MeasureString(subtitulo, fontSubtitulo);

            int centerX = this.ClientSize.Width / 2;

            float y = 80;

            // Título principal
            g.DrawString(titulo, fontTitulo, Brushes.White, centerX - sizeTitulo.Width / 2, y);

            // Línea roja debajo del título
            y += sizeTitulo.Height + 10;
            g.FillRectangle(Brushes.Red, centerX - sizeTitulo.Width / 2, y, sizeTitulo.Width, 5);

            // Nombre del circuito
            y += 20;
            g.DrawString(circuito, fontCircuito, Brushes.LightGray, centerX - sizeCircuito.Width / 2, y);

            // Subtítulo
            y += sizeCircuito.Height + 20;
            g.DrawString(subtitulo, fontSubtitulo, Brushes.Yellow, centerX - sizeSubtitulo.Width / 2, y);
        }


    }

}
