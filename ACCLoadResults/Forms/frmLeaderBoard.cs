using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCLoadResults.Forms
{
    public partial class frmLeaderBoard : Form
    {

        string AppPath = AppDomain.CurrentDomain.BaseDirectory;

        public frmLeaderBoard()
        {
            InitializeComponent();
        }

        private void cboSeason_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void frmLeaderBoard_Load(object sender, EventArgs e)
        {

            List<vGetCompleteSessions> OStatsR = (from Datos in Globals.oData.vGetCompleteSessions orderby Datos.IDQualySession descending, Datos.ID descending select Datos).ToList();

            List<Seasons> oSeasons = (from Data in Globals.oData.Seasons orderby Data.Active descending select Data).ToList();
            cboSeason.ValueMember = "ID";
            cboSeason.DisplayMember = "Name";
            cboSeason.DataSource = oSeasons;

        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {


            var oRaces = (from Data in Globals.oData.vGetRaceCSVFile
                          join Season in Globals.oData.SeasonSessions on
                              Data.IDSession equals Season.IdSession
                          where Season.IdSeason == (Decimal)cboSeason.SelectedValue
                          select new { Data.IDSession, IdCircuit = Data.IdCircuit + " (" + Data.SessionHour + ")", Data.SessionDate }
                         ).Distinct().OrderByDescending(o => o.SessionDate).ToList();

            cboRaces.ValueMember = "IDSession";
            cboRaces.DisplayMember = "IdCircuit";
            cboRaces.DataSource = oRaces;


            //Get LeaderBoard
            List<vGetClassification> oClassf = (from Data in Globals.oData.vGetClassification
                                                where Data.IdSeason == (Decimal)cboSeason.SelectedValue
                                                orderby Data.Puntuacio descending
                                                select Data).ToList();

            grdLeaderBoard.DataSource = oClassf;

            //If any data
            if (oClassf.Any())
            {
                //Get Leader Points
                int LeaderPoints = (int)grdLeaderBoard.Rows[0].Cells["Puntuacio"].Value;

                //Remove first column
                grdLeaderBoard.Columns.Remove("IdSeason");

                //Calculate diff point with leader and % point for race
                foreach (DataGridViewRow row in grdLeaderBoard.Rows)
                {
                    row.Cells["DiffLider"].Value = (LeaderPoints - (int)row.Cells["Puntuacio"].Value) * -1;
                    row.Cells["MitjaPuntsPerCursa"].Value = Math.Round((decimal)row.Cells["MitjaPuntsPerCursa"].Value, 2);
                }


            }

        }

        private void btnExportGeneral_Click(object sender, EventArgs e)
        {
            if (grdLeaderBoard.Rows.Count > 0)
            {

                Models.Seasons SelSeason = (Models.Seasons)cboSeason.SelectedItem;

                string CSVPath = AppPath + @"\ExportFiles\" + SelSeason.Name.Trim();

                if (!System.IO.Directory.Exists(CSVPath))
                 System.IO.Directory.CreateDirectory(CSVPath); 

                CSVPath += @"\" + SelSeason.Name.Trim() + ".csv";


                ExportarDataGridViewACSV(grdLeaderBoard, CSVPath);
            }
        }


        public void ExportarDataGridViewACSV(DataGridView dataGridView, string nombreArchivo)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nombreArchivo, false, Encoding.UTF8))
                {
                    // Escribir encabezados de columna
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        sw.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.WriteLine();

                    // Escribir filas de datos
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString());
                            if (i < dataGridView.Columns.Count - 1)
                            {
                                sw.Write(";");
                            }
                        }
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Data exported to CSV.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar datos: " + ex.Message, "Error");
            }
        }

        private void cboRaces_SelectedIndexChanged(object sender, EventArgs e)
        {

            grdSession.DataSource = null;

            //Get LeaderBoard
            List <vGetRaceCSVFile> oClassf = (from Data in Globals.oData.vGetRaceCSVFile
                                             where Data.IDSession == (Decimal)cboRaces.SelectedValue
                                             orderby Data.Posicio ascending
                                             select Data).ToList();

            grdSession.DataSource = oClassf;

            //If any data
            if (oClassf.Any())
            {

                //Remove columns
                grdSession.Columns.Remove("IDSession");
                grdSession.Columns.Remove("SessionDate");
                grdSession.Columns.Remove("SessionHour");

            }

        }

        private void btnExportRace_Click(object sender, EventArgs e)
        {
            if (grdSession.Rows.Count > 0)
            {

                string SelRace = cboRaces.Text.Replace("(", "").Replace(")", "").Replace(":", "-");
                string IdCircuit = SelRace.Substring(0, SelRace.IndexOf("Race") - 1);

                Models.Seasons SelSeason = (Models.Seasons)cboSeason.SelectedItem;
                string SeassonPath = AppPath + @"\ExportFiles\" + SelSeason.Name.Trim();

                if (!System.IO.Directory.Exists(SeassonPath))
                    System.IO.Directory.CreateDirectory(SeassonPath);

                string CircuitPath = SeassonPath + @"\" + IdCircuit;
                if (!System.IO.Directory.Exists(CircuitPath))
                    System.IO.Directory.CreateDirectory(CircuitPath);

                string CSVPath = CircuitPath + @"\" + SelRace.Trim() + ".csv";
                ExportarDataGridViewACSV(grdSession, CSVPath);
            }
        }

        private bool SaveDataInHistory()
        {

            try
            {
                List<SeasonsLeaderBoardHistory> oHist = (from Data in Globals.oData.SeasonsLeaderBoardHistory
                                                         where
                                                                Data.IdSeason == (Decimal)cboSeason.SelectedValue &&
                                                                Data.IdSession == (Decimal)cboRaces.SelectedValue
                                                         select Data
                                                        ).ToList();

                //If don't have any data
                if (!oHist.Any())
                {

                    //Create new record with data.
                    List<vGetClassification> oClassHist = (from Data in Globals.oData.vGetClassification
                                                           where Data.IdSeason == (Decimal)cboSeason.SelectedValue
                                                           orderby Data.Puntuacio descending
                                                           select Data).ToList();

                    var QRorder = (from Data in Globals.oData.SeasonsLeaderBoardHistory
                                   where
                                        Data.IdSeason == (Decimal)cboSeason.SelectedValue
                                   select Data.RaceOrder);


                    int RaceOrder = 1;

                    if (QRorder.Any())
                        RaceOrder = QRorder.Max()+1;

                    foreach (vGetClassification Data in oClassHist)
                    {

                        SeasonsLeaderBoardHistory NewSeasonsH = new SeasonsLeaderBoardHistory();
                        NewSeasonsH.IdSeason = (Decimal)cboSeason.SelectedValue;
                        NewSeasonsH.IdTemporada = Data.IdTemporada;
                        NewSeasonsH.IdSession = (Decimal)cboRaces.SelectedValue;
                        NewSeasonsH.Posicio = (int)Data.Posicio;
                        NewSeasonsH.GameTag = Data.GameTag;
                        NewSeasonsH.Puntuacio = (int)Data.Puntuacio;
                        NewSeasonsH.SancionsTemps = Data.SancionsTemps;
                        NewSeasonsH.SancionsBox = Data.SancionsBox;
                        NewSeasonsH.Poles = (int)Data.Poles;
                        NewSeasonsH.VoltesRapides = (int)Data.VoltesRapides;
                        NewSeasonsH.Curses = (int)Data.Curses;
                        NewSeasonsH.DiffPunts = (int)Data.DiffPunts;
                        NewSeasonsH.DiffLider = (int)Data.DiffLider;
                        NewSeasonsH.MitjaPuntsPerCursa = Data.MitjaPuntsPerCursa;
                        NewSeasonsH.RaceOrder = RaceOrder;

                        Globals.oData.SeasonsLeaderBoardHistory.Add(NewSeasonsH);

                    }

                    Globals.oData.SaveChanges();

                }

                MessageBox.Show("Save data history OK", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception e)
            {

                MessageBox.Show("Error on save data history", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

        }

        private void btnSaveDataHist_Click(object sender, EventArgs e)
        {
            SaveDataInHistory();
        }
    }
}
