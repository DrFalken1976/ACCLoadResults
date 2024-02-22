namespace ACCLoadResults.Forms
{
    partial class frmCreateTeams
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
            btnCreateRace = new Button();
            grdEditData = new GroupBox();
            btnDeletePilot = new Button();
            btnNewPilot = new Button();
            btnCancel = new Button();
            btnAddPilot = new Button();
            label4 = new Label();
            grdPilots = new DataGridView();
            btnCreateEntryFile = new Button();
            btnSaveRace = new Button();
            grdTeams = new DataGridView();
            datRaceData = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            txtRaceName = new TextBox();
            cboRaces = new ComboBox();
            label3 = new Label();
            btnEdit = new Button();
            tabControl1 = new TabControl();
            pEntry = new TabPage();
            PEventRules = new TabPage();
            txtEntryJson = new TextBox();
            txtEventRulesJson = new TextBox();
            grdEditData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdPilots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTeams).BeginInit();
            tabControl1.SuspendLayout();
            pEntry.SuspendLayout();
            PEventRules.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreateRace
            // 
            btnCreateRace.Location = new Point(30, 26);
            btnCreateRace.Name = "btnCreateRace";
            btnCreateRace.Size = new Size(147, 23);
            btnCreateRace.TabIndex = 1;
            btnCreateRace.Text = "Create Race";
            btnCreateRace.UseVisualStyleBackColor = true;
            btnCreateRace.Click += btnCreateRace_Click;
            // 
            // grdEditData
            // 
            grdEditData.Controls.Add(btnDeletePilot);
            grdEditData.Controls.Add(btnNewPilot);
            grdEditData.Controls.Add(btnCancel);
            grdEditData.Controls.Add(btnAddPilot);
            grdEditData.Controls.Add(label4);
            grdEditData.Controls.Add(grdPilots);
            grdEditData.Controls.Add(btnCreateEntryFile);
            grdEditData.Controls.Add(btnSaveRace);
            grdEditData.Controls.Add(grdTeams);
            grdEditData.Controls.Add(datRaceData);
            grdEditData.Controls.Add(label2);
            grdEditData.Controls.Add(label1);
            grdEditData.Controls.Add(txtRaceName);
            grdEditData.Enabled = false;
            grdEditData.Location = new Point(31, 68);
            grdEditData.Name = "grdEditData";
            grdEditData.Size = new Size(904, 656);
            grdEditData.TabIndex = 3;
            grdEditData.TabStop = false;
            grdEditData.Text = "Race Data";
            // 
            // btnDeletePilot
            // 
            btnDeletePilot.Location = new Point(680, 339);
            btnDeletePilot.Name = "btnDeletePilot";
            btnDeletePilot.Size = new Size(160, 23);
            btnDeletePilot.TabIndex = 15;
            btnDeletePilot.Text = "Delete Selected Pilot";
            btnDeletePilot.UseVisualStyleBackColor = true;
            btnDeletePilot.Click += btnDeletePilot_Click;
            // 
            // btnNewPilot
            // 
            btnNewPilot.Location = new Point(680, 310);
            btnNewPilot.Name = "btnNewPilot";
            btnNewPilot.Size = new Size(160, 23);
            btnNewPilot.TabIndex = 14;
            btnNewPilot.Text = "Add New Pilot";
            btnNewPilot.UseVisualStyleBackColor = true;
            btnNewPilot.Click += btnNewPilot_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(718, 613);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(147, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAddPilot
            // 
            btnAddPilot.Location = new Point(22, 274);
            btnAddPilot.Name = "btnAddPilot";
            btnAddPilot.Size = new Size(147, 23);
            btnAddPilot.TabIndex = 12;
            btnAddPilot.Text = "Add Pilot";
            btnAddPilot.UseVisualStyleBackColor = true;
            btnAddPilot.Click += btnAddPilot_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 87);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 11;
            label4.Text = "Current server Pilots";
            // 
            // grdPilots
            // 
            grdPilots.AllowUserToAddRows = false;
            grdPilots.AllowUserToDeleteRows = false;
            grdPilots.AllowUserToOrderColumns = true;
            grdPilots.AllowUserToResizeRows = false;
            grdPilots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdPilots.Location = new Point(22, 120);
            grdPilots.Name = "grdPilots";
            grdPilots.ReadOnly = true;
            grdPilots.RowTemplate.Height = 25;
            grdPilots.Size = new Size(280, 141);
            grdPilots.TabIndex = 10;
            // 
            // btnCreateEntryFile
            // 
            btnCreateEntryFile.Location = new Point(718, 64);
            btnCreateEntryFile.Name = "btnCreateEntryFile";
            btnCreateEntryFile.Size = new Size(147, 23);
            btnCreateEntryFile.TabIndex = 9;
            btnCreateEntryFile.Text = "Create EntryList File";
            btnCreateEntryFile.UseVisualStyleBackColor = true;
            btnCreateEntryFile.Click += btnCreateEntryFile_Click;
            // 
            // btnSaveRace
            // 
            btnSaveRace.Location = new Point(718, 35);
            btnSaveRace.Name = "btnSaveRace";
            btnSaveRace.Size = new Size(147, 23);
            btnSaveRace.TabIndex = 8;
            btnSaveRace.Text = "Save race";
            btnSaveRace.UseVisualStyleBackColor = true;
            btnSaveRace.Click += btnSaveRace_Click;
            // 
            // grdTeams
            // 
            grdTeams.AllowUserToOrderColumns = true;
            grdTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTeams.Location = new Point(22, 310);
            grdTeams.Name = "grdTeams";
            grdTeams.RowTemplate.Height = 25;
            grdTeams.Size = new Size(638, 340);
            grdTeams.TabIndex = 7;
            // 
            // datRaceData
            // 
            datRaceData.Format = DateTimePickerFormat.Short;
            datRaceData.Location = new Point(552, 32);
            datRaceData.MinDate = new DateTime(2023, 1, 1, 0, 0, 0, 0);
            datRaceData.Name = "datRaceData";
            datRaceData.Size = new Size(108, 23);
            datRaceData.TabIndex = 6;
            datRaceData.Value = new DateTime(2023, 11, 15, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(488, 35);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 5;
            label2.Text = "Race data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 35);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "Race name";
            // 
            // txtRaceName
            // 
            txtRaceName.Location = new Point(106, 32);
            txtRaceName.Name = "txtRaceName";
            txtRaceName.Size = new Size(348, 23);
            txtRaceName.TabIndex = 3;
            // 
            // cboRaces
            // 
            cboRaces.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRaces.FormattingEnabled = true;
            cboRaces.Location = new Point(337, 28);
            cboRaces.Name = "cboRaces";
            cboRaces.Size = new Size(269, 23);
            cboRaces.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 30);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 5;
            label3.Text = "View Race teams";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(630, 28);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(147, 23);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit Race";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(pEntry);
            tabControl1.Controls.Add(PEventRules);
            tabControl1.Location = new Point(955, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(632, 644);
            tabControl1.TabIndex = 7;
            // 
            // pEntry
            // 
            pEntry.Controls.Add(txtEntryJson);
            pEntry.Location = new Point(4, 24);
            pEntry.Name = "pEntry";
            pEntry.Padding = new Padding(3);
            pEntry.Size = new Size(624, 616);
            pEntry.TabIndex = 0;
            pEntry.Text = "EntryList";
            pEntry.UseVisualStyleBackColor = true;
            // 
            // PEventRules
            // 
            PEventRules.Controls.Add(txtEventRulesJson);
            PEventRules.Location = new Point(4, 24);
            PEventRules.Name = "PEventRules";
            PEventRules.Padding = new Padding(3);
            PEventRules.Size = new Size(624, 616);
            PEventRules.TabIndex = 1;
            PEventRules.Text = "EventRules";
            PEventRules.UseVisualStyleBackColor = true;
            // 
            // txtEntryJson
            // 
            txtEntryJson.Dock = DockStyle.Fill;
            txtEntryJson.Location = new Point(3, 3);
            txtEntryJson.Multiline = true;
            txtEntryJson.Name = "txtEntryJson";
            txtEntryJson.ReadOnly = true;
            txtEntryJson.Size = new Size(618, 610);
            txtEntryJson.TabIndex = 0;
            txtEntryJson.WordWrap = false;
            // 
            // txtEventRulesJson
            // 
            txtEventRulesJson.Dock = DockStyle.Fill;
            txtEventRulesJson.Location = new Point(3, 3);
            txtEventRulesJson.Multiline = true;
            txtEventRulesJson.Name = "txtEventRulesJson";
            txtEventRulesJson.ReadOnly = true;
            txtEventRulesJson.Size = new Size(618, 610);
            txtEventRulesJson.TabIndex = 1;
            txtEventRulesJson.WordWrap = false;
            // 
            // frmCreateTeams
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 752);
            Controls.Add(tabControl1);
            Controls.Add(btnEdit);
            Controls.Add(label3);
            Controls.Add(cboRaces);
            Controls.Add(grdEditData);
            Controls.Add(btnCreateRace);
            Name = "frmCreateTeams";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmCreateTeams";
            Load += frmCreateTeams_Load;
            grdEditData.ResumeLayout(false);
            grdEditData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdPilots).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTeams).EndInit();
            tabControl1.ResumeLayout(false);
            pEntry.ResumeLayout(false);
            pEntry.PerformLayout();
            PEventRules.ResumeLayout(false);
            PEventRules.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateRace;
        private GroupBox grdEditData;
        private DataGridView grdTeams;
        private DateTimePicker datRaceData;
        private Label label2;
        private Label label1;
        private TextBox txtRaceName;
        private Button btnCreateEntryFile;
        private Button btnSaveRace;
        private ComboBox cboRaces;
        private Label label3;
        private Button btnAddPilot;
        private Label label4;
        private DataGridView grdPilots;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnDeletePilot;
        private Button btnNewPilot;
        private TabControl tabControl1;
        private TabPage pEntry;
        private TextBox txtEntryJson;
        private TabPage PEventRules;
        private TextBox txtEventRulesJson;
    }
}