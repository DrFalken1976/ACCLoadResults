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
            groupBox1 = new GroupBox();
            btnRaceAna = new Button();
            btnManSes = new Button();
            btnLoadData = new Button();
            groupBox2 = new GroupBox();
            btnCreateTeams = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRaceAna);
            groupBox1.Controls.Add(btnManSes);
            groupBox1.Controls.Add(btnLoadData);
            groupBox1.Location = new Point(322, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(293, 416);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Manage Data Sessions";
            // 
            // btnRaceAna
            // 
            btnRaceAna.Location = new Point(41, 263);
            btnRaceAna.Name = "btnRaceAna";
            btnRaceAna.Size = new Size(212, 69);
            btnRaceAna.TabIndex = 5;
            btnRaceAna.Text = "Race Analysis";
            btnRaceAna.UseVisualStyleBackColor = true;
            btnRaceAna.Click += btnRaceAna_Click;
            // 
            // btnManSes
            // 
            btnManSes.Location = new Point(41, 156);
            btnManSes.Name = "btnManSes";
            btnManSes.Size = new Size(212, 69);
            btnManSes.TabIndex = 4;
            btnManSes.Text = "Manage Sessions";
            btnManSes.UseVisualStyleBackColor = true;
            btnManSes.Click += btnManSes_Click;
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(41, 56);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(212, 66);
            btnLoadData.TabIndex = 3;
            btnLoadData.Text = "Load Data";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnCreateTeams);
            groupBox2.Location = new Point(12, 51);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(285, 416);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Manage Server Files";
            // 
            // btnCreateTeams
            // 
            btnCreateTeams.Location = new Point(33, 45);
            btnCreateTeams.Name = "btnCreateTeams";
            btnCreateTeams.Size = new Size(212, 66);
            btnCreateTeams.TabIndex = 4;
            btnCreateTeams.Text = "Manage Teams";
            btnCreateTeams.UseVisualStyleBackColor = true;
            btnCreateTeams.Click += btnCreateTeams_Click;
            // 
            // button1
            // 
            button1.Location = new Point(36, 175);
            button1.Name = "button1";
            button1.Size = new Size(212, 66);
            button1.TabIndex = 5;
            button1.Text = "Manage Meteo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmMenus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 487);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmMenus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMenucs";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnRaceAna;
        private Button btnManSes;
        private Button btnLoadData;
        private GroupBox groupBox2;
        private Button btnCreateTeams;
        private Button button1;
    }
}