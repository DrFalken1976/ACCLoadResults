using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

    public partial class frmCreateTeams : Form
    {

        public enum FormStatus
        {
            initial,
            newRace,
            editRace
        }

        Models.RaceTeams _RaceTeams = null;
        List<Models.TeamsByRace> _TeamsByRace = new List<Models.TeamsByRace>();
        FormStatus _FormStatus = FormStatus.initial;

        public frmCreateTeams()
        {
            InitializeComponent();
        }

        private void CleanAndLoadBasicData()
        {

            List<Models.RaceTeams> Races = (from Datos in Globals.oData.RaceTeams orderby Datos.Date descending select Datos).ToList();

            cboRaces.ValueMember = "ID";
            cboRaces.DisplayMember = "RaceName";
            cboRaces.DataSource = Races;

            _FormStatus = FormStatus.initial;

            grdTeams.DataSource = null;
            grdPilots.DataSource = null;
        }


        private void frmCreateTeams_Load(object sender, EventArgs e)
        {

            //Init form
            CleanAndLoadBasicData();

        }

        private void btnCreateRace_Click(object sender, EventArgs e)
        {

            grdEditData.Enabled = true;
            txtRaceName.Focus();
            btnCreateRace.Enabled = false;
            btnEdit.Enabled = false;

            //Add Pilots to available pilots.
            List<Pilots> Drivers = (from Datos in Globals.oData.LeaderBoard
                                    select new Pilots { GameTag = Datos.lastName.Trim() }
                                   ).Distinct().ToList();

            grdPilots.DataSource = Drivers;

            _FormStatus = FormStatus.newRace;

        }



        private void btnAddPilot_Click(object sender, EventArgs e)
        {


            //Create new RaceTeams
            Models.TeamsByRace NewPilot = new Models.TeamsByRace();

            NewPilot.IDRace = 0;
            NewPilot.GameTagUID = "M";
            NewPilot.GameTag = grdPilots.CurrentCell.Value.ToString();
            NewPilot.TeamName = "";

            _TeamsByRace.Add(NewPilot);

            grdTeams.DataSource = null;
            grdTeams.DataSource = _TeamsByRace;
            grdTeams.Refresh();


        }

        private void btnSaveRace_Click(object sender, EventArgs e)
        {

            try
            {

                //IF is new race create race and Get new ID
                if (_FormStatus == FormStatus.newRace)
                {
                    Models.RaceTeams NewRace = new Models.RaceTeams();

                    NewRace.Date = datRaceData.Value.Date;
                    NewRace.RaceName = txtRaceName.Text.Trim();
                    Globals.oData.RaceTeams.Add(NewRace);
                    Globals.oData.SaveChanges();

                    //Assign new Race ID to Teams & Save data in database
                    foreach (Models.TeamsByRace t in _TeamsByRace)
                    {
                        t.IDRace = NewRace.ID;
                    }
                }

                if (_FormStatus == FormStatus.editRace)
                {

                    //List<Models.TeamsByRace> NewPilots = (from Datos in grdTeams.DataSource where Datos )

                    //Globals.oData.SaveChanges();

                }

                //Globals.oData.TeamsByRace.AddRange(_TeamsByRace);
                Globals.oData.SaveChanges();

                //Clean and Update Form Status and data

                MessageBox.Show("save successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _FormStatus = FormStatus.initial;

                grdEditData.Enabled = false;
                btnCreateRace.Enabled = true;
                btnEdit.Enabled = true;

                //Init form
                CleanAndLoadBasicData();

                grdTeams.DataSource = null;
                grdPilots.DataSource = null;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _FormStatus = FormStatus.editRace;

            grdEditData.Enabled = true;
            txtRaceName.Focus();
            txtRaceName.Enabled = false;
            datRaceData.Enabled = false;
            btnCreateRace.Enabled = false;
            btnEdit.Enabled = false;


            //Add Pilots to available pilots.
            List<Pilots> Drivers = (from Datos in Globals.oData.LeaderBoard
                                    select new Pilots { GameTag = Datos.lastName.Trim() }
                                   ).Distinct().ToList();

            grdPilots.DataSource = Drivers;


            decimal IDRace = decimal.Parse(cboRaces.SelectedValue.ToString());


            _RaceTeams = (from Data in Globals.oData.RaceTeams
                          where Data.ID == IDRace
                          select Data).ToList().First();


            _TeamsByRace = (from Data in Globals.oData.TeamsByRace
                            where Data.IDRace == IDRace
                            select Data).ToList();

            grdTeams.DataSource = null;
            grdTeams.DataSource = _TeamsByRace;
            grdTeams.Columns["ID"].Visible = false;
            grdTeams.Columns["IDRace"].Visible = false;
            grdTeams.Refresh();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            _FormStatus = FormStatus.initial;

            grdEditData.Enabled = false;
            btnCreateRace.Enabled = true;
            btnEdit.Enabled = true;

            //Init form
            CleanAndLoadBasicData();

            grdTeams.DataSource = null;
            grdPilots.DataSource = null;

        }

        private void btnDeletePilot_Click(object sender, EventArgs e)
        {

            //Remove firs row selected
            foreach (DataGridViewRow row in grdTeams.SelectedRows)
            {
                grdTeams.Rows.RemoveAt(row.Index);
            }

        }

        private void btnNewPilot_Click(object sender, EventArgs e)
        {

            Models.TeamsByRace NewPilot = new Models.TeamsByRace();

            NewPilot.IDRace = _RaceTeams.ID;
            NewPilot.GameTagUID = "M";

            _TeamsByRace.Add(NewPilot);

            grdTeams.DataSource = null;
            grdTeams.DataSource = _TeamsByRace;
            grdTeams.Refresh();

        }

        private void btnCreateEntryFile_Click(object sender, EventArgs e)
        {




        }
    }

    public class Pilots
    {
        public string GameTag { get; set; }
    }

}
