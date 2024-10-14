namespace ACCLoadResults.Forms
{
    partial class frmManageSessions
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
            grdRaces = new DataGridView();
            grdQualy = new DataGridView();
            btnLinkQToR = new Button();
            cboLinkRace = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)grdRaces).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdQualy).BeginInit();
            SuspendLayout();
            // 
            // grdRaces
            // 
            grdRaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRaces.Location = new Point(24, 24);
            grdRaces.Name = "grdRaces";
            grdRaces.ReadOnly = true;
            grdRaces.RowTemplate.Height = 25;
            grdRaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdRaces.Size = new Size(1350, 234);
            grdRaces.TabIndex = 0;
            grdRaces.CellClick += grdRaces_CellClick;
            // 
            // grdQualy
            // 
            grdQualy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdQualy.Location = new Point(24, 331);
            grdQualy.Name = "grdQualy";
            grdQualy.ReadOnly = true;
            grdQualy.RowTemplate.Height = 25;
            grdQualy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdQualy.Size = new Size(1350, 246);
            grdQualy.TabIndex = 1;
            // 
            // btnLinkQToR
            // 
            btnLinkQToR.Location = new Point(536, 275);
            btnLinkQToR.Name = "btnLinkQToR";
            btnLinkQToR.Size = new Size(283, 38);
            btnLinkQToR.TabIndex = 2;
            btnLinkQToR.Text = "Link Quali to Race";
            btnLinkQToR.UseVisualStyleBackColor = true;
            btnLinkQToR.Click += btnLinkQToR_Click;
            // 
            // cboLinkRace
            // 
            cboLinkRace.FormattingEnabled = true;
            cboLinkRace.Location = new Point(120, 284);
            cboLinkRace.Name = "cboLinkRace";
            cboLinkRace.Size = new Size(367, 23);
            cboLinkRace.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 287);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Set Race link";
            // 
            // frmManageSessions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 599);
            Controls.Add(label1);
            Controls.Add(cboLinkRace);
            Controls.Add(btnLinkQToR);
            Controls.Add(grdQualy);
            Controls.Add(grdRaces);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmManageSessions";
            ShowIcon = false;
            Text = "Manage Sessions";
            Load += frmManageSessions_Load;
            ((System.ComponentModel.ISupportInitialize)grdRaces).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdQualy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdRaces;
        private DataGridView grdQualy;
        private Button btnLinkQToR;
        private ComboBox cboLinkRace;
        private Label label1;
    }
}