namespace ACCLoadResults.Forms
{
    partial class frmRaceAnalysis
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
            btnGenHTML = new Button();
            grdRaces = new DataGridView();
            label1 = new Label();
            cboSeason = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdRaces).BeginInit();
            SuspendLayout();
            // 
            // btnGenHTML
            // 
            btnGenHTML.Location = new Point(503, 726);
            btnGenHTML.Name = "btnGenHTML";
            btnGenHTML.Size = new Size(379, 39);
            btnGenHTML.TabIndex = 0;
            btnGenHTML.Text = "Generate HTML Page";
            btnGenHTML.UseVisualStyleBackColor = true;
            btnGenHTML.Click += btnGenHTML_Click;
            // 
            // grdRaces
            // 
            grdRaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdRaces.Location = new Point(-2, 44);
            grdRaces.Name = "grdRaces";
            grdRaces.ReadOnly = true;
            grdRaces.RowTemplate.Height = 25;
            grdRaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdRaces.Size = new Size(1350, 649);
            grdRaces.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 13);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Season";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(60, 10);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(367, 23);
            cboSeason.TabIndex = 5;
            cboSeason.SelectedIndexChanged += cboSeason_SelectedIndexChanged;
            // 
            // frmRaceAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 777);
            Controls.Add(label1);
            Controls.Add(cboSeason);
            Controls.Add(grdRaces);
            Controls.Add(btnGenHTML);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRaceAnalysis";
            ShowIcon = false;
            Text = "Race Analysis";
            Load += frmRaceAnalysis_Load;
            ((System.ComponentModel.ISupportInitialize)grdRaces).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenHTML;
        private DataGridView grdRaces;
        private Label label1;
        private ComboBox cboSeason;
    }
}