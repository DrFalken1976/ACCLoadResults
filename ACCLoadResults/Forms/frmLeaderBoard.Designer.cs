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
            grdLeaderBoard = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grdLeaderBoard).BeginInit();
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
            // grdLeaderBoard
            // 
            grdLeaderBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdLeaderBoard.Location = new Point(-2, 39);
            grdLeaderBoard.Name = "grdLeaderBoard";
            grdLeaderBoard.ReadOnly = true;
            grdLeaderBoard.RowTemplate.Height = 25;
            grdLeaderBoard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdLeaderBoard.Size = new Size(1350, 756);
            grdLeaderBoard.TabIndex = 7;
            // 
            // frmLeaderBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 790);
            Controls.Add(label1);
            Controls.Add(cboSeason);
            Controls.Add(grdLeaderBoard);
            Name = "frmLeaderBoard";
            Text = "frmLeaderBoard";
            Load += frmLeaderBoard_Load;
            ((System.ComponentModel.ISupportInitialize)grdLeaderBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboSeason;
        private DataGridView grdLeaderBoard;
    }
}