
namespace ACCLoadResults.Forms
{
    partial class frmMantSeasons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grdSeassons = new DataGridView();
            btnNewSeason = new Button();
            btnEditSeason = new Button();
            grpSeason = new GroupBox();
            chkActive = new CheckBox();
            datEnd = new DateTimePicker();
            label5 = new Label();
            datStart = new DateTimePicker();
            label4 = new Label();
            txtCategory = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            GrpCalendar = new GroupBox();
            btnDelRace = new Button();
            btnNewRace = new Button();
            grdCalendar = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            IdSeason = new DataGridViewTextBoxColumn();
            ORder = new DataGridViewTextBoxColumn();
            idTrack = new DataGridViewComboBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Hour = new DataGridViewTextBoxColumn();
            IdRaceType = new DataGridViewComboBoxColumn();
            OnlySumFirsQualy = new DataGridViewCheckBoxColumn();
            btnSaveSeason = new Button();
            ((System.ComponentModel.ISupportInitialize)grdSeassons).BeginInit();
            grpSeason.SuspendLayout();
            GrpCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCalendar).BeginInit();
            SuspendLayout();
            // 
            // grdSeassons
            // 
            grdSeassons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdSeassons.Location = new Point(22, 25);
            grdSeassons.MultiSelect = false;
            grdSeassons.Name = "grdSeassons";
            grdSeassons.ReadOnly = true;
            grdSeassons.RowTemplate.Height = 25;
            grdSeassons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdSeassons.Size = new Size(792, 150);
            grdSeassons.TabIndex = 0;
            // 
            // btnNewSeason
            // 
            btnNewSeason.Location = new Point(820, 25);
            btnNewSeason.Name = "btnNewSeason";
            btnNewSeason.Size = new Size(121, 23);
            btnNewSeason.TabIndex = 1;
            btnNewSeason.Text = "New Season";
            btnNewSeason.UseVisualStyleBackColor = true;
            btnNewSeason.Click += btnNewSeason_Click;
            // 
            // btnEditSeason
            // 
            btnEditSeason.Location = new Point(820, 54);
            btnEditSeason.Name = "btnEditSeason";
            btnEditSeason.Size = new Size(121, 23);
            btnEditSeason.TabIndex = 2;
            btnEditSeason.Text = "Edit Season";
            btnEditSeason.UseVisualStyleBackColor = true;
            btnEditSeason.Click += btnEditSeason_Click;
            // 
            // grpSeason
            // 
            grpSeason.Controls.Add(chkActive);
            grpSeason.Controls.Add(datEnd);
            grpSeason.Controls.Add(label5);
            grpSeason.Controls.Add(datStart);
            grpSeason.Controls.Add(label4);
            grpSeason.Controls.Add(txtCategory);
            grpSeason.Controls.Add(label3);
            grpSeason.Controls.Add(txtName);
            grpSeason.Controls.Add(label2);
            grpSeason.Controls.Add(txtID);
            grpSeason.Controls.Add(label1);
            grpSeason.Enabled = false;
            grpSeason.Location = new Point(22, 194);
            grpSeason.Name = "grpSeason";
            grpSeason.Size = new Size(645, 147);
            grpSeason.TabIndex = 3;
            grpSeason.TabStop = false;
            grpSeason.Text = "Season info";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(348, 110);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(59, 19);
            chkActive.TabIndex = 10;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // datEnd
            // 
            datEnd.Format = DateTimePickerFormat.Custom;
            datEnd.Location = new Point(348, 67);
            datEnd.Name = "datEnd";
            datEnd.Size = new Size(200, 23);
            datEnd.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(287, 71);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 8;
            label5.Text = "End Date";
            // 
            // datStart
            // 
            datStart.Format = DateTimePickerFormat.Custom;
            datStart.Location = new Point(64, 67);
            datStart.Name = "datStart";
            datStart.Size = new Size(200, 23);
            datStart.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 71);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 6;
            label4.Text = "Start Date";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(64, 108);
            txtCategory.MaxLength = 3;
            txtCategory.Name = "txtCategory";
            txtCategory.ReadOnly = true;
            txtCategory.Size = new Size(128, 23);
            txtCategory.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 111);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Category";
            // 
            // txtName
            // 
            txtName.Location = new Point(226, 26);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 29);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // txtID
            // 
            txtID.Location = new Point(48, 26);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 29);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // GrpCalendar
            // 
            GrpCalendar.Controls.Add(btnDelRace);
            GrpCalendar.Controls.Add(btnNewRace);
            GrpCalendar.Controls.Add(grdCalendar);
            GrpCalendar.Enabled = false;
            GrpCalendar.Location = new Point(25, 361);
            GrpCalendar.Name = "GrpCalendar";
            GrpCalendar.Size = new Size(892, 429);
            GrpCalendar.TabIndex = 4;
            GrpCalendar.TabStop = false;
            GrpCalendar.Text = "Season Calendar";
            // 
            // btnDelRace
            // 
            btnDelRace.Location = new Point(795, 51);
            btnDelRace.Name = "btnDelRace";
            btnDelRace.Size = new Size(87, 23);
            btnDelRace.TabIndex = 3;
            btnDelRace.Text = "Del. Race";
            btnDelRace.UseVisualStyleBackColor = true;
            btnDelRace.Click += btnDelRace_Click;
            // 
            // btnNewRace
            // 
            btnNewRace.Location = new Point(795, 22);
            btnNewRace.Name = "btnNewRace";
            btnNewRace.Size = new Size(87, 23);
            btnNewRace.TabIndex = 2;
            btnNewRace.Text = "New Race";
            btnNewRace.UseVisualStyleBackColor = true;
            btnNewRace.Click += btnNewRace_Click;
            // 
            // grdCalendar
            // 
            grdCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdCalendar.Columns.AddRange(new DataGridViewColumn[] { ID, IdSeason, ORder, idTrack, Date, Hour, IdRaceType, OnlySumFirsQualy });
            grdCalendar.Location = new Point(6, 22);
            grdCalendar.MultiSelect = false;
            grdCalendar.Name = "grdCalendar";
            grdCalendar.RowTemplate.Height = 25;
            grdCalendar.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grdCalendar.Size = new Size(783, 401);
            grdCalendar.TabIndex = 1;
            grdCalendar.DataError += grdCalendar_DataError;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Visible = false;
            // 
            // IdSeason
            // 
            IdSeason.DataPropertyName = "IdSeason";
            IdSeason.HeaderText = "Season";
            IdSeason.Name = "IdSeason";
            // 
            // ORder
            // 
            ORder.DataPropertyName = "Order";
            ORder.HeaderText = "Order";
            ORder.Name = "ORder";
            ORder.ReadOnly = true;
            // 
            // idTrack
            // 
            idTrack.DataPropertyName = "IdTrack";
            idTrack.HeaderText = "Track";
            idTrack.Name = "idTrack";
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Date";
            Date.Name = "Date";
            // 
            // Hour
            // 
            Hour.DataPropertyName = "Hour";
            Hour.HeaderText = "Hour";
            Hour.Name = "Hour";
            // 
            // IdRaceType
            // 
            IdRaceType.DataPropertyName = "IDRaceType";
            IdRaceType.HeaderText = "Race Type";
            IdRaceType.Name = "IdRaceType";
            // 
            // OnlySumFirsQualy
            // 
            OnlySumFirsQualy.DataPropertyName = "OnlySumFirstQualy";
            OnlySumFirsQualy.HeaderText = "OSFQ";
            OnlySumFirsQualy.Name = "OnlySumFirsQualy";
            OnlySumFirsQualy.Resizable = DataGridViewTriState.True;
            // 
            // btnSaveSeason
            // 
            btnSaveSeason.Location = new Point(820, 83);
            btnSaveSeason.Name = "btnSaveSeason";
            btnSaveSeason.Size = new Size(121, 23);
            btnSaveSeason.TabIndex = 5;
            btnSaveSeason.Text = "Save Season";
            btnSaveSeason.UseVisualStyleBackColor = true;
            btnSaveSeason.Click += btnSaveSeason_Click;
            // 
            // frmMantSeasons
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 802);
            Controls.Add(btnSaveSeason);
            Controls.Add(GrpCalendar);
            Controls.Add(grpSeason);
            Controls.Add(btnEditSeason);
            Controls.Add(btnNewSeason);
            Controls.Add(grdSeassons);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMantSeasons";
            Text = "MantSeasons";
            Load += MantSeasons_Load;
            ((System.ComponentModel.ISupportInitialize)grdSeassons).EndInit();
            grpSeason.ResumeLayout(false);
            grpSeason.PerformLayout();
            GrpCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdCalendar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdSeassons;
        private Button btnNewSeason;
        private Button btnEditSeason;
        private GroupBox grpSeason;
        private TextBox txtName;
        private Label label2;
        private TextBox txtID;
        private Label label1;
        private TextBox txtCategory;
        private Label label3;
        private DateTimePicker datEnd;
        private Label label5;
        private DateTimePicker datStart;
        private Label label4;
        private CheckBox chkActive;
        private GroupBox GrpCalendar;
        private DataGridView grdCalendar;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn IdSeason;
        private DataGridViewTextBoxColumn ORder;
        private DataGridViewComboBoxColumn idTrack;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Hour;
        private DataGridViewComboBoxColumn IdRaceType;
        private DataGridViewCheckBoxColumn OnlySumFirsQualy;
        private Button btnDelRace;
        private Button btnNewRace;
        private Button btnSaveSeason;
    }
}