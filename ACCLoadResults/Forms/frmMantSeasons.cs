using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace ACCLoadResults.Forms
{
    public partial class frmMantSeasons : Form
    {

        List<Models.Seasons> _Seasons;
        Models.Seasons _CurrentSeason;
        List<SeasonCalendar> _seasonCalendars;

        public frmMantSeasons()
        {
            InitializeComponent();
        }

        private void MantSeasons_Load(object sender, EventArgs e)
        {
            //Get all Seasons & Load in dataGrid
            _Seasons = (from Data in Globals.oData.Seasons orderby Data.Active descending, Data.DateStart descending select Data).ToList();
            grdSeassons.DataSource = _Seasons;

        }

        private void btnEditSeason_Click(object sender, EventArgs e)
        {
            if (grdSeassons.SelectedRows.Count > 0)
            {
                decimal sID = (decimal)grdSeassons.SelectedRows[0].Cells[0].Value;
                _CurrentSeason = (from Data in Globals.oData.Seasons where Data.ID == sID select Data).First();

                if (_CurrentSeason != null)
                {
                    //Set all values in fields
                    txtID.Text = _CurrentSeason.ID.ToString();
                    txtName.Text = _CurrentSeason.Name.Trim();
                    datStart.Value = _CurrentSeason.DateStart;
                    datEnd.Value = _CurrentSeason.DateEnd;
                    txtCategory.Text = _CurrentSeason.Category.Trim();
                    chkActive.Checked = _CurrentSeason.Active;

                    txtID.ReadOnly = false;
                    txtName.ReadOnly = false;
                    datStart.Enabled = true;
                    datEnd.Enabled = true;
                    txtCategory.ReadOnly = false;
                    chkActive.Enabled = true;

                    //Load Calendar
                    grdCalendar.AutoGenerateColumns = false;

                    //Load Data in DropDown columns
                    DataGridViewComboBoxColumn TrackColumn = (DataGridViewComboBoxColumn)grdCalendar.Columns["idTrack"];
                    TrackColumn.DataSource = Globals.oData.Tracks.ToList();
                    TrackColumn.DisplayMember = "TrackName";
                    TrackColumn.ValueMember = "ID";

                    DataGridViewComboBoxColumn RaceType = (DataGridViewComboBoxColumn)grdCalendar.Columns["idRaceType"];
                    RaceType.DataSource = Globals.oData.TypeRace.ToList();
                    RaceType.DisplayMember = "Name";
                    RaceType.ValueMember = "ID";

                    _seasonCalendars = (from Data in Globals.oData.SeasonCalendar where Data.IdSeason == sID select Data).ToList();
                    grdCalendar.DataSource = _seasonCalendars;

                    GrpCalendar.Enabled = true;
                    grpSeason.Enabled = true;

                }
                else
                    MessageBox.Show("Error in get values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRace_Click(object sender, EventArgs e)
        {
            SeasonCalendar NewRace = new SeasonCalendar();

            if (_CurrentSeason != null)
            {
                NewRace.IdSeason = _CurrentSeason.ID;

                if (_seasonCalendars.Any())
                    NewRace.Order = _seasonCalendars.Last().Order + 1;
                else
                    NewRace.Order = 1;

            }
            else
            {
                NewRace.IdSeason = 1000;
                NewRace.Order = 1;
            }

            NewRace.Hour = TimeSpan.Parse("22:30:00");

            _seasonCalendars.Add(NewRace);
            grdCalendar.DataSource = null;
            grdCalendar.DataSource = _seasonCalendars;            
        }

        private void btnDelRace_Click(object sender, EventArgs e)
        {

            if ((Decimal)grdCalendar.CurrentRow.Cells["ID"].Value != 0)
                Globals.oData.Entry(grdCalendar.CurrentRow.DataBoundItem).State = EntityState.Deleted;

            _seasonCalendars.RemoveAt(grdCalendar.CurrentRow.Index);
            grdCalendar.DataSource = null;
            grdCalendar.DataSource = _seasonCalendars;

        }

        private void grdCalendar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Cancel all errors in grid
            e.Cancel = true;
        }

        private void btnSaveSeason_Click(object sender, EventArgs e)
        {

            bool isNew = false;

            //Save Season Data
            if (_CurrentSeason == null)
            {
                _CurrentSeason = new Seasons();
                isNew = true;
            }

            //Get values
            _CurrentSeason.Name = txtName.Text;
            _CurrentSeason.DateStart = datStart.Value;
            _CurrentSeason.DateEnd = datEnd.Value;
            _CurrentSeason.Category = txtCategory.Text;
            _CurrentSeason.Active = chkActive.Checked;

            foreach (var oRace in (List<SeasonCalendar>)grdCalendar.DataSource)
            {
                if (Globals.oData.SeasonCalendar.Entry(oRace).State == EntityState.Detached)
                {
                    Globals.oData.SeasonCalendar.Attach(oRace);
                }

                Globals.oData.SeasonCalendar.Entry(oRace).State = oRace.ID == 0 ? EntityState.Added : EntityState.Modified;
            }

            if (isNew)
                Globals.oData.Seasons.Add(_CurrentSeason);

            //Save Changes
            Globals.oData.SaveChanges();

            //If is new create a simple race
            if (isNew)
            {
                SeasonCalendar oRace = new SeasonCalendar();
                oRace.IdSeason = _CurrentSeason.ID;
                oRace.Order = 1;

                Globals.oData.SeasonCalendar.Add(oRace);

                //Save Changes
                Globals.oData.SaveChanges();

            }


            GrpCalendar.Enabled = false;

            MessageBox.Show("Save succefully", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);

            GrpCalendar.Enabled = false;
            grpSeason.Enabled = false;
            txtID.ReadOnly = true;
            txtName.ReadOnly = true;
            datStart.Enabled = false;
            datEnd.Enabled = false;
            txtCategory.ReadOnly = true;
            chkActive.Enabled = false;

            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            chkActive.Checked = false;

            grdSeassons.Refresh();

        }

        private void btnNewSeason_Click(object sender, EventArgs e)
        {
            //Set all values in fields
            txtID.Text = "0";
            txtName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            chkActive.Checked = false;

            txtID.ReadOnly = false;
            txtName.ReadOnly = false;
            datStart.Enabled = true;
            datEnd.Enabled = true;
            txtCategory.ReadOnly = false;
            chkActive.Enabled = true;

            //Load Calendar
            grdCalendar.AutoGenerateColumns = false;

            //Load Data in DropDown columns
            DataGridViewComboBoxColumn TrackColumn = (DataGridViewComboBoxColumn)grdCalendar.Columns["idTrack"];
            TrackColumn.DataSource = Globals.oData.Tracks.ToList();
            TrackColumn.DisplayMember = "TrackName";
            TrackColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn RaceType = (DataGridViewComboBoxColumn)grdCalendar.Columns["idRaceType"];
            RaceType.DataSource = Globals.oData.TypeRace.ToList();
            RaceType.DisplayMember = "Name";
            RaceType.ValueMember = "ID";

            _seasonCalendars = new List<SeasonCalendar>();
            grdCalendar.DataSource = _seasonCalendars;

            grpSeason.Enabled = true;

        }

    }
}

