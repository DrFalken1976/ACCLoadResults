using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using System.Data;

namespace ACCLoadResults.Forms
{
    public partial class frmManageSessions : Form
    {
        public frmManageSessions()
        {
            InitializeComponent();
        }

        private void frmManageSessions_Load(object sender, EventArgs e)
        {


            List<Seasons> oSeasons = (from Data in Globals.oData.Seasons orderby Data.Active descending select Data).ToList();
            cboSeason.ValueMember = "ID";
            cboSeason.DisplayMember = "Name";
            cboSeason.DataSource = oSeasons;

            //Load Races without Quali's
            List<Sessions> oSessions = (from Datos in Classes.Globals.oData.Sessions
                                        where Datos.sessionType.Contains("R") && Datos.IDQualySession == null
                                        orderby Datos.SessionDate descending, Datos.SessionHour descending
                                        select Datos).ToList();

            grdRaces.DataSource = oSessions;

            //Load Qualis without Race
            List<Sessions> oQuali = (from Datos in Classes.Globals.oData.Sessions
                                     where Datos.sessionType.Contains("Q") &&
                                           !(
                                             from DatosR in Classes.Globals.oData.Sessions
                                             where DatosR.sessionType.Contains("R")
                                             select DatosR.IDQualySession
                                            ).Contains(Datos.ID)
                                     orderby Datos.SessionDate descending, Datos.SessionHour descending
                                     select Datos).ToList();

            grdQualy.DataSource = oQuali;

        }

        private void btnLinkQToR_Click(object sender, EventArgs e)
        {

            //Get selected rows for link
            decimal RaceID = (decimal)grdRaces.CurrentRow.Cells["ID"].Value;
            decimal QualiID = 0;

            if (grdQualy.CurrentRow != null)
                QualiID = (decimal)grdQualy.CurrentRow.Cells["ID"].Value;


            //Update Race with Quali ID Session

            Sessions oSession = Classes.Globals.oData.Sessions.Where(F => F.ID == RaceID).Select(f => f).ToArray()[0];
            oSession.IDQualySession = QualiID;

            if (cboSeason.SelectedValue != null)
            {
                SeasonSessions oLinkSeason = new SeasonSessions();
                oLinkSeason.IdSession = RaceID;
                oLinkSeason.IdSeason = (decimal)cboSeason.SelectedValue;

                Globals.oData.SeasonSessions.Add(oLinkSeason);

            }

            Classes.Globals.oData.SaveChanges();

            //Call Load for refresh
            frmManageSessions_Load(sender, e);

        }

        private void grdRaces_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DateTime StartDate = (DateTime)grdRaces.Rows[e.RowIndex].Cells["SessionDate"].Value;
            StartDate = StartDate.AddDays(-1);
            DateTime EndDate = (DateTime)grdRaces.Rows[e.RowIndex].Cells["SessionDate"].Value;
            EndDate = EndDate.AddDays(1);

            var query = from c in Classes.Globals.oData.SeasonCalendar
                        join s in Classes.Globals.oData.Seasons on c.IdSeason equals s.ID
                        join t in Classes.Globals.oData.Tracks on c.IdTrack equals t.ID
                        where s.Active == true && c.Date >= StartDate && c.Date <= EndDate
                        select new
                        {
                            IdSeason = s.ID,
                            IdRace = c.ID,
                            c.Date,
                            TrackName = t.TrackName.Trim() + "(" + s.Name.Trim() + ") " + c.Date.ToString()
                        };

            cboSeason.DataSource = query.ToList();
            cboSeason.ValueMember = "IdRace";
            cboSeason.DisplayMember = "TrackName";


        }


    }
}
