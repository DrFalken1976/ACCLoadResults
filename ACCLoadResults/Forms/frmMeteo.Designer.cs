namespace ACCLoadResults.Forms
{
    partial class frmMeteo
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
            button1 = new Button();
            label3 = new Label();
            cboTracks = new ComboBox();
            txtJSON = new TextBox();
            txtInfo = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(411, 28);
            button1.Name = "button1";
            button1.Size = new Size(136, 23);
            button1.TabIndex = 0;
            button1.Text = "Generate data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 31);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 7;
            label3.Text = "Track";
            // 
            // cboTracks
            // 
            cboTracks.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTracks.FormattingEnabled = true;
            cboTracks.Location = new Point(107, 28);
            cboTracks.Name = "cboTracks";
            cboTracks.Size = new Size(269, 23);
            cboTracks.TabIndex = 6;
            // 
            // txtJSON
            // 
            txtJSON.Location = new Point(27, 75);
            txtJSON.Multiline = true;
            txtJSON.Name = "txtJSON";
            txtJSON.ReadOnly = true;
            txtJSON.Size = new Size(349, 180);
            txtJSON.TabIndex = 8;
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(411, 75);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.Size = new Size(349, 180);
            txtInfo.TabIndex = 9;
            // 
            // frmMeteo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtInfo);
            Controls.Add(txtJSON);
            Controls.Add(label3);
            Controls.Add(cboTracks);
            Controls.Add(button1);
            Name = "frmMeteo";
            Text = "frmMeteo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private ComboBox cboTracks;
        private TextBox txtJSON;
        private TextBox txtInfo;
    }
}