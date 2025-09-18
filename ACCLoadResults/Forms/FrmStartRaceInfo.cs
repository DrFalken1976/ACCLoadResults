using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using NetCoreAudio;
using System.Drawing.Printing;
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
        private bool mostrarPatrocinadores = true;
        private bool MostrarFilaActual = false;

        private Player player;

        private Timer timerChangePartnerImage;
        private int TicksParnersTimer = 0;

        public FrmStartRaceInfo()
        {

            //Play Music
            player = new Player();

            try
            {
                string rutaMp3 = Path.Combine(AppContext.BaseDirectory, "Assets", "Epic.mp3");
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
            };
            introTimer.Start();


            Timer PatroTimer = new Timer();
            PatroTimer.Interval = 5000; // 5 segundos

            timerChangePartnerImage = new Timer();
            timerChangePartnerImage.Interval = 5000; // 5 segundos
            timerChangePartnerImage.Tick += timerChangePartnerImage_Tick;
            timerChangePartnerImage.Start();

            this.DoubleBuffered = true;
            CargarPilotos();
            CargarFuenteF1();
            CalcularTamañoPiloto();            

        }

        private void timerChangePartnerImage_Tick(object? sender, EventArgs e)
        {
            TicksParnersTimer += 1;

            if (TicksParnersTimer > 2)
            {
                mostrarPatrocinadores = false;
                timerChangePartnerImage.Stop();
                PrepararAnimacion();
            }

            //if (ParterShowFirstImage == true && ParterShowSecondImage == false && MostrarFilaActual == false)
            //{ 
            //    ParterShowFirstImage = true;
            //    ParterShowSecondImage = true;
            //}
            //else if (ParterShowFirstImage == false && MostrarFilaActual == false)
            //{

            //    ParterShowFirstImage = false;
            //    ParterShowSecondImage = false;

            //    MostrarFilaActual = true;                
            //}
            //else
            //{
            //}

            this.Invalidate();
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
            pilotoHeight = this.ClientSize.Height + 250; //220;
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
            else if (TicksParnersTimer < 3)
            {                
                DibujarPatrocinadores(e.Graphics);
            }
            else 
                DibujarFilaActual(e.Graphics);

        }


        private void DibujarFilaActual(Graphics g)
        {

            timerChangePartnerImage.Stop();            

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

                    Font f1FontPlus = new Font(f1FontPos.FontFamily, f1FontPos.Size + 4, f1FontPos.Style);
                    g.DrawString(p.Position.ToString(), f1FontPlus, Brushes.Orange, x, (int)y + 20);
                    g.DrawString(p.Position.ToString(), f1FontPos, Brushes.Yellow, x-4, (int)y + 24);

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


                    string texto = "Championship position: ";
                    string valor = $"{p.GeneralPos}º";

                    if (p.GeneralPos == 99)
                        valor = "First Race";

                    float baseX = x;
                    float baseY = textY + 60;

                    // Mide el ancho del texto para posicionar el valor justo después
                    SizeF sizeTexto = g.MeasureString(texto, f1Font);

                    // Dibuja el texto base
                    g.DrawString(texto, f1Font, Brushes.LightBlue, baseX, baseY);

                    // Dibuja el valor en otro color (por ejemplo, rojo)
                    g.DrawString(valor, f1Font, Brushes.White, baseX + sizeTexto.Width, baseY);

                    g.DrawString($"Car Model: {p.CarModel}", f1Font, Brushes.Gold, x, baseY + 30);

                    baseY += 300;

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
            float centery = (this.ClientSize.Height / 2) -200;

            float y = 80;

            // Título principal
            g.DrawString(titulo, fontTitulo, Brushes.White, centerX - sizeTitulo.Width / 2, centery);

            // Línea roja debajo del título
            centery += sizeTitulo.Height + 10;
            g.FillRectangle(Brushes.Red, centerX - sizeTitulo.Width / 2, centery, sizeTitulo.Width, 5);

            // Nombre del circuito
            centery += 20;
            g.DrawString(circuito, fontCircuito, Brushes.LightGray, centerX - sizeCircuito.Width / 2, centery);

            // Subtítulo
            centery += sizeCircuito.Height + 20;
            g.DrawString(subtitulo, fontSubtitulo, Brushes.Yellow, centerX - sizeSubtitulo.Width / 2, centery);


        }

        private void DibujarPatrocinadores(Graphics g)
        {

            string titulo = "Partners";

            Font fontTitulo = new Font("Formula1 Display-Regular", 60, FontStyle.Bold);

            SizeF sizeTitulo = g.MeasureString(titulo, fontTitulo);

            int centerX = this.ClientSize.Width / 2;
            float centery = 200;

            float y = 80;

            // Título principal
            g.DrawString(titulo, fontTitulo, Brushes.White, centerX - sizeTitulo.Width / 2, centery);

            // Línea roja debajo del título
            centery += sizeTitulo.Height + 10;
            g.FillRectangle(Brushes.Red, centerX - sizeTitulo.Width / 2, centery, sizeTitulo.Width, 5);

            Image imgLogo;
            float scale;
            int logoWidth;
            int logoHeight;
            Rectangle destRect;

            string pathImagen = string.Empty;

            if (TicksParnersTimer == 1)
                pathImagen = @"assets\\Tulsa.png";

            if (TicksParnersTimer == 2)
                pathImagen = @"assets\\JC.png";
            
            imgLogo = Image.FromFile(pathImagen);
            scale = 0.5f;
            int x = (int)(centerX - (sizeTitulo.Width / 2));
            logoWidth = (int)(imgLogo.Width);
            logoHeight = (int)(imgLogo.Height);
            destRect = new Rectangle(x-75, (int)centery + 200, logoWidth, logoHeight);
            g.DrawImage(imgLogo, destRect);
                
            //if (ParterShowFirstImage == false)
            //    MostrarFilaActual = true;
        }

    }

}
