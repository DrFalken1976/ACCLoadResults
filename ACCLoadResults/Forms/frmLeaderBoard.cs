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
        public frmLeaderBoard()
        {
            InitializeComponent();
        }

        private void cboSeason_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void frmLeaderBoard_Load(object sender, EventArgs e)
        {
            //grdRaces.DataBindingComplete += grdRaces_DataBindingComplete;

            List<vGetCompleteSessions> OStatsR = (from Datos in Globals.oData.vGetCompleteSessions orderby Datos.IDQualySession descending, Datos.ID descending select Datos).ToList();
            //grdRaces.DataSource = OStatsR;

            List<Seasons> oSeasons = (from Data in Globals.oData.Seasons orderby Data.Active descending select Data).ToList();
            cboSeason.ValueMember = "ID";
            cboSeason.DisplayMember = "Name";
            cboSeason.DataSource = oSeasons;
        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<vGetClassification> oClassf = (from Data in Globals.oData.vGetClassification
                                                where Data.IdSeason == (Decimal)cboSeason.SelectedValue
                                                orderby Data.Puntuacio descending
                                                select Data).ToList();

            grdLeaderBoard.DataSource = oClassf;

            if (oClassf.Any()) 
            { 
                int LeaderPoints = (int)grdLeaderBoard.Rows[0].Cells["Puntuacio"].Value;

                grdLeaderBoard.Columns.Remove("IdSeason");

                foreach (DataGridViewRow row in grdLeaderBoard.Rows) 
                {                    
                    row.Cells["DiffLider"].Value = (LeaderPoints - (int)row.Cells["Puntuacio"].Value) * -1;
                    row.Cells["MitjaPuntsPerCursa"].Value = Math.Round((decimal)row.Cells["MitjaPuntsPerCursa"].Value, 2);
                }
            }

        }

    }
}
