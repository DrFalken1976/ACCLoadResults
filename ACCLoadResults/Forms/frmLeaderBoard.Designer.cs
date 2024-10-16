namespace ACCLoadResults.Forms
{
    partial class frmLeaderBoard
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
            label1 = new Label();
            cboSeason = new ComboBox();
            btnExportGeneral = new Button();
            btnExportRace = new Button();
            tabControl1 = new TabControl();
            TabLeaderBoard = new TabPage();
            grdLeaderBoard = new DataGridView();
            TabSession = new TabPage();
            grdSession = new DataGridView();
            label2 = new Label();
            cboRaces = new ComboBox();
            tabControl1.SuspendLayout();
            TabLeaderBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdLeaderBoard).BeginInit();
            TabSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdSession).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 9;
            label1.Text = "Season";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(60, 5);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(367, 23);
            cboSeason.TabIndex = 8;
            cboSeason.SelectedIndexChanged += cboSeason_SelectedIndexChanged;
            cboSeason.SelectedValueChanged += cboSeason_SelectedValueChanged;
            // 
            // btnExportGeneral
            // 
            btnExportGeneral.Location = new Point(997, 8);
            btnExportGeneral.Name = "btnExportGeneral";
            btnExportGeneral.Size = new Size(167, 23);
            btnExportGeneral.TabIndex = 10;
            btnExportGeneral.Text = "Export LeaderBoard (CSV)";
            btnExportGeneral.UseVisualStyleBackColor = true;
            btnExportGeneral.Click += btnExportGeneral_Click;
            // 
            // btnExportRace
            // 
            btnExportRace.Location = new Point(1178, 8);
            btnExportRace.Name = "btnExportRace";
            btnExportRace.Size = new Size(167, 23);
            btnExportRace.TabIndex = 11;
            btnExportRace.Text = "Export Race (CSV)";
            btnExportRace.UseVisualStyleBackColor = true;
            btnExportRace.Click += btnExportRace_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabLeaderBoard);
            tabControl1.Controls.Add(TabSession);
            tabControl1.Location = new Point(10, 37);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1335, 755);
            tabControl1.TabIndex = 12;
            // 
            // TabLeaderBoard
            // 
            TabLeaderBoard.Controls.Add(grdLeaderBoard);
            TabLeaderBoard.Location = new Point(4, 24);
            TabLeaderBoard.Name = "TabLeaderBoard";
            TabLeaderBoard.Padding = new Padding(3);
            TabLeaderBoard.Size = new Size(1327, 727);
            TabLeaderBoard.TabIndex = 0;
            TabLeaderBoard.Text = "Leaderboard";
            TabLeaderBoard.UseVisualStyleBackColor = true;
            // 
            // grdLeaderBoard
            // 
            grdLeaderBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdLeaderBoard.Dock = DockStyle.Fill;
            grdLeaderBoard.Location = new Point(3, 3);
            grdLeaderBoard.Name = "grdLeaderBoard";
            grdLeaderBoard.ReadOnly = true;
            grdLeaderBoard.RowTemplate.Height = 25;
            grdLeaderBoard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdLeaderBoard.Size = new Size(1321, 721);
            grdLeaderBoard.TabIndex = 8;
            // 
            // TabSession
            // 
            TabSession.Controls.Add(grdSession);
            TabSession.Location = new Point(4, 24);
            TabSession.Name = "TabSession";
            TabSession.Padding = new Padding(3);
            TabSession.Size = new Size(1327, 727);
            TabSession.TabIndex = 1;
            TabSession.Text = "Races";
            TabSession.UseVisualStyleBackColor = true;
            // 
            // grdSession
            // 
            grdSession.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdSession.Dock = DockStyle.Fill;
            grdSession.Location = new Point(3, 3);
            grdSession.Name = "grdSession";
            grdSession.ReadOnly = true;
            grdSession.RowTemplate.Height = 25;
            grdSession.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdSession.Size = new Size(1321, 721);
            grdSession.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(469, 8);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 14;
            label2.Text = "Race";
            // 
            // cboRaces
            // 
            cboRaces.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRaces.FormattingEnabled = true;
            cboRaces.Location = new Point(519, 5);
            cboRaces.Name = "cboRaces";
            cboRaces.Size = new Size(367, 23);
            cboRaces.TabIndex = 13;
            cboRaces.SelectedIndexChanged += cboRaces_SelectedIndexChanged;
            // 
            // frmLeaderBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 790);
            Controls.Add(label2);
            Controls.Add(cboRaces);
            Controls.Add(tabControl1);
            Controls.Add(btnExportRace);
            Controls.Add(btnExportGeneral);
            Controls.Add(label1);
            Controls.Add(cboSeason);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmLeaderBoard";
            Text = "frmLeaderBoard";
            Load += frmLeaderBoard_Load;
            tabControl1.ResumeLayout(false);
            TabLeaderBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdLeaderBoard).EndInit();
            TabSession.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdSession).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboSeason;
        private Button btnExportGeneral;
        private Button btnExportRace;
        private TabControl tabControl1;
        private TabPage TabLeaderBoard;
        private TabPage TabSession;
        private DataGridView grdLeaderBoard;
        private DataGridView grdSession;
        private Label label2;
        private ComboBox cboRaces;
    }
}