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

            //Load Races without Quali's
            List<Sessions> oSessions = (from Datos in Classes.Globals.oData.Sessions 
                                        where Datos.sessionType.Contains("R") && Datos.IDQualySession == null 
                                        orderby Datos.SessionDate descending, Datos.SessionHour descending select Datos).ToList();

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
            decimal QualiID = (decimal)grdQualy.CurrentRow.Cells["ID"].Value;


            //Update Race with Quali ID Session

            Sessions oSession = Classes.Globals.oData.Sessions.Where(F => F.ID == RaceID).Select(f => f).ToArray()[0];
            oSession.IDQualySession = QualiID;

            Classes.Globals.oData.SaveChanges();

            //Call Load for refresh
            frmManageSessions_Load(sender, e);

        }
    }
}
