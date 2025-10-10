using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NetCoreAudio;
using System.Drawing.Imaging;
using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace ACCLoadResults.Forms
{
    public partial class FrmGDIClassification : Form
    {
        private int currentRow;
        private float scrollOffset;
        private Timer scrollTimer;
        private Timer delayTimer;
        private Font f1Font;
        private Font f1FontPos;

        List<vGetGDIClassification> _oClassf;

        private int pilotoWidth;
        private int pilotoHeight;
        private float scrollStep = 20f;
        private int delaySeconds = 4;
        private bool mostrarIntro = true;

        private Player player;

        public FrmGDIClassification()
        {

            //Get LeaderBoard
            _oClassf = (from Data in Globals.oData.vGetGDIClassification
                        orderby Data.Posicio ascending
                        select Data).ToList();

            if (!_oClassf.Any())
            {
                return;
            }

            //Play Music
            player = new Player();

            try
            {
                string rutaMp3 = Path.Combine(AppContext.BaseDirectory, "Assets", "Epic.mp3");
                player.SetVolume(25);
                player.Play(rutaMp3);
            }
            catch (Exception ex)
            {
            }


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
            f1Font = new Font("Formula1 Display Regular", 18, FontStyle.Bold); // Sustituye por "Formula1 Display Regular" si la tienes
            f1FontPos = new Font("Formula1 Display Regular", 30, FontStyle.Bold); // Sustituye por "Formula1 Display Regular" si la tienes
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
            CargarFuenteF1();

            int width = 1200;
            int rowHeight = 40;
            int headerHeight = 50;
            int logoSize = 100;
            int titleHeight = 80;
            int margin = 20;
            int numRows = 17;
            int height = titleHeight + logoSize + headerHeight + rowHeight * numRows + margin;

            // Obtener ancho real del canvas
            int canvasWidth = g.VisibleClipBounds.Width > 0 ? (int)g.VisibleClipBounds.Width : width;
            int offsetX = (canvasWidth - width) / 2;

            g.Clear(Color.Black);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Dibujar logo escalado y centrado horizontalmente
            Image imgLogo = Image.FromFile(@"assets\\LogoFalkenCup-Small.png");
            float scale = 0.5f;
            int logoWidth = (int)(imgLogo.Width * scale);
            int logoHeight = (int)(imgLogo.Height * scale);
            Rectangle destRect = new Rectangle(offsetX + margin, margin, logoWidth, logoHeight);
            g.DrawImage(imgLogo, destRect);

            // Título de la temporada centrado
            string seasonTitle = _oClassf[0].IdTemporada.Trim();
            SizeF titleSize = g.MeasureString(seasonTitle, f1FontPos);
            float titleX = offsetX + (width - titleSize.Width) / 2;
            float titleY = margin + (logoSize - titleSize.Height) / 2;
            g.DrawString(seasonTitle, f1FontPos, Brushes.Gold, titleX, titleY);

            // Línea roja debajo del título
            int lineY = margin + logoSize + 10;
            g.DrawLine(new Pen(Color.Red, 3), offsetX, lineY, offsetX + width, lineY);

            // Encabezados de columna
            string[] headers = { "Pos", "Driver", "Points", "A.Points", "G.Pos", "G.Points" };
            int[] colX = { 10, 80, 350, 500, 650, 790 };
            int headerY = lineY + 100;

            offsetX += 100;

            for (int i = 0; i < headers.Length; i++)
                g.DrawString(headers[i], f1Font, Brushes.Gold, offsetX + colX[i], headerY);

            SizeF LastColSize = g.MeasureString("G.Points", f1Font);
            float FinalLine = (offsetX + colX[colX.Length - 1]) + LastColSize.Width + 10;
            g.DrawLine(new Pen(Color.White, 1.5f), offsetX, headerY + 35, FinalLine, headerY + 35);



            var data = new List<object[]>();

            foreach (vGetGDIClassification Driver in _oClassf)
            {

                data.Add(new object[]
                    {
                        Driver.Posicio,
                        Driver.GameTag,
                        Driver.Puntuacio,
                        Driver.DiffPunts,
                        Driver.GainPos,
                        Driver.GainPoints
                    });

            }

            int yFinal = 0;

            // Dibujar filas
            for (int i = 0; i < data.Count; i++)
            {
                int y = headerY + headerHeight + i * rowHeight;
                for (int j = 0; j < data[i].Length; j++)
                {
                    Brush brush = Brushes.White;
                    string text = data[i][j].ToString();

                    if (j == 4 || j == 5) // GainPos / GainPoints
                    {
                        int val = Convert.ToInt32(data[i][j]);

                        string valNorm = val.ToString();

                        if (val < 0)
                            valNorm = Math.Abs(val).ToString();

                        if (valNorm.Length == 1)
                            valNorm = " " + valNorm;

                        if (val > 0)
                        {
                            brush = Brushes.LimeGreen;
                            text = $"{valNorm} ▲";
                        }
                        else if (val < 0)
                        {
                            brush = Brushes.Red;
                            text = $"{valNorm} ▼";
                        }
                        else
                        {
                            text = " 0";
                        }
                    }

                    g.DrawString(text, f1Font, brush, offsetX + colX[j], y);
                }

                yFinal = y;
            }


            imgLogo = Image.FromFile(@"assets\\Tulsa.png");
            scale = 0.5f;
            logoWidth = (int)(imgLogo.Width * scale);
            logoHeight = (int)(imgLogo.Height * scale);
            destRect = new Rectangle(offsetX + margin, yFinal + 200, logoWidth, logoHeight);
            g.DrawImage(imgLogo, destRect);

            imgLogo = Image.FromFile(@"assets\\jc.png");
            scale = 0.5f;
            logoWidth = (int)(imgLogo.Width * scale);
            logoHeight = (int)(imgLogo.Height * scale);
            destRect = new Rectangle(offsetX + colX[colX.Length - 1] - 200, yFinal + 250, logoWidth, logoHeight);
            g.DrawImage(imgLogo, destRect);



        }

        private void DibujarIntro(Graphics g)
        {

            if (!_oClassf.Any())
            {
                return;
            }

            string titulo = "FalkenCUP";
            string circuito = _oClassf[0].IdTemporada.Trim();
            string subtitulo = "General Classification";
            
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


    }

}
