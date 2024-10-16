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
                         ).Distinct().OrderByDescending(o=> o.SessionDate) .ToList();
            
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

                string CSVPath = AppPath + @"\ExportFiles\" + SelSeason.Name.Trim() + ".csv";
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

            //Get LeaderBoard
            List<vGetRaceCSVFile> oClassf = (from Data in Globals.oData.vGetRaceCSVFile
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

                string CSVPath = AppPath + @"\ExportFiles\" + SelRace.Trim() + ".csv";
                ExportarDataGridViewACSV(grdSession, CSVPath);
            }
        }
    }
}
