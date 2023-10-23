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
            grdRaces.Location = new Point(-2, 3);
            grdRaces.Name = "grdRaces";
            grdRaces.ReadOnly = true;
            grdRaces.RowTemplate.Height = 25;
            grdRaces.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdRaces.Size = new Size(1350, 690);
            grdRaces.TabIndex = 1;
            // 
            // frmRaceAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 777);
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
        }

        #endregion

        private Button btnGenHTML;
        private DataGridView grdRaces;

    }
}