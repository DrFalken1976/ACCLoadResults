namespace ACCLoadResults.Forms
{
    partial class frmMenus
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
            btnLoadData = new Button();
            btnManSes = new Button();
            btnRaceAna = new Button();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(371, 72);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(212, 66);
            btnLoadData.TabIndex = 0;
            btnLoadData.Text = "Load Data";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // btnManSes
            // 
            btnManSes.Location = new Point(371, 182);
            btnManSes.Name = "btnManSes";
            btnManSes.Size = new Size(212, 69);
            btnManSes.TabIndex = 1;
            btnManSes.Text = "Manage Sessions";
            btnManSes.UseVisualStyleBackColor = true;
            btnManSes.Click += btnManSes_Click;
            // 
            // btnRaceAna
            // 
            btnRaceAna.Location = new Point(371, 279);
            btnRaceAna.Name = "btnRaceAna";
            btnRaceAna.Size = new Size(212, 69);
            btnRaceAna.TabIndex = 2;
            btnRaceAna.Text = "Race Analysis";
            btnRaceAna.UseVisualStyleBackColor = true;
            btnRaceAna.Click += btnRaceAna_Click;
            // 
            // frmMenus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 523);
            Controls.Add(btnRaceAna);
            Controls.Add(btnManSes);
            Controls.Add(btnLoadData);
            Name = "frmMenus";
            Text = "frmMenucs";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadData;
        private Button btnManSes;
        private Button btnRaceAna;
    }
}