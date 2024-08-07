namespace ACCLoadResults.Forms
{
    public partial class frmMenus : Form
    {
        public frmMenus()
        {
            InitializeComponent();

            Classes.Globals.oData = new Models.DataContext();
        }

        private void btnManSes_Click(object sender, EventArgs e)
        {

            frmManageSessions oForm = new frmManageSessions();
            oForm.ShowDialog();

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            frmLoadData oForm = new frmLoadData();
            oForm.ShowDialog();

        }

        private void btnRaceAna_Click(object sender, EventArgs e)
        {

            frmRaceAnalysis oForm = new frmRaceAnalysis();
            oForm.ShowDialog();

        }

        private void btnCreateTeams_Click(object sender, EventArgs e)
        {

            frmCreateTeams oForm = new frmCreateTeams();
            oForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMeteo oForm = new frmMeteo();
            oForm.ShowDialog();

        }
    }
}
