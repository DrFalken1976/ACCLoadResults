namespace ACCLoadResults
{
    partial class frmLoadData
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadFiles = new Button();
            prgLoad = new ProgressBar();
            gbStatus = new GroupBox();
            lblTotalKO = new Label();
            lblTotalOK = new Label();
            lblTotalFiles = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grdAvFiles = new DataGridView();
            label4 = new Label();
            calDate = new DateTimePicker();
            gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdAvFiles).BeginInit();
            SuspendLayout();
            // 
            // btnLoadFiles
            // 
            btnLoadFiles.Location = new Point(41, 289);
            btnLoadFiles.Name = "btnLoadFiles";
            btnLoadFiles.Size = new Size(592, 40);
            btnLoadFiles.TabIndex = 0;
            btnLoadFiles.Text = "Load Server Files";
            btnLoadFiles.UseVisualStyleBackColor = true;
            btnLoadFiles.Click += btnLoadFiles_Click;
            // 
            // prgLoad
            // 
            prgLoad.Location = new Point(41, 335);
            prgLoad.Name = "prgLoad";
            prgLoad.Size = new Size(592, 23);
            prgLoad.TabIndex = 1;
            // 
            // gbStatus
            // 
            gbStatus.Controls.Add(lblTotalKO);
            gbStatus.Controls.Add(lblTotalOK);
            gbStatus.Controls.Add(lblTotalFiles);
            gbStatus.Controls.Add(label3);
            gbStatus.Controls.Add(label2);
            gbStatus.Controls.Add(label1);
            gbStatus.Location = new Point(62, 377);
            gbStatus.Name = "gbStatus";
            gbStatus.Size = new Size(543, 116);
            gbStatus.TabIndex = 2;
            gbStatus.TabStop = false;
            gbStatus.Text = "Load status";
            // 
            // lblTotalKO
            // 
            lblTotalKO.AutoSize = true;
            lblTotalKO.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalKO.ForeColor = Color.Red;
            lblTotalKO.Location = new Point(173, 86);
            lblTotalKO.Name = "lblTotalKO";
            lblTotalKO.Size = new Size(14, 15);
            lblTotalKO.TabIndex = 5;
            lblTotalKO.Text = "0";
            // 
            // lblTotalOK
            // 
            lblTotalOK.AutoSize = true;
            lblTotalOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalOK.ForeColor = Color.ForestGreen;
            lblTotalOK.Location = new Point(173, 60);
            lblTotalOK.Name = "lblTotalOK";
            lblTotalOK.Size = new Size(14, 15);
            lblTotalOK.TabIndex = 4;
            lblTotalOK.Text = "0";
            // 
            // lblTotalFiles
            // 
            lblTotalFiles.AutoSize = true;
            lblTotalFiles.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalFiles.Location = new Point(173, 35);
            lblTotalFiles.Name = "lblTotalFiles";
            lblTotalFiles.Size = new Size(14, 15);
            lblTotalFiles.TabIndex = 3;
            lblTotalFiles.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(20, 86);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 2;
            label3.Text = "Total load error: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 1;
            label2.Text = "Total load successfully : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Total files: ";
            // 
            // grdAvFiles
            // 
            grdAvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdAvFiles.Location = new Point(41, 27);
            grdAvFiles.Name = "grdAvFiles";
            grdAvFiles.RowTemplate.Height = 25;
            grdAvFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdAvFiles.Size = new Size(592, 227);
            grdAvFiles.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 263);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 4;
            label4.Text = "Date filter";
            // 
            // calDate
            // 
            calDate.CustomFormat = "dd/MM/yyyy";
            calDate.Location = new Point(104, 260);
            calDate.Name = "calDate";
            calDate.Size = new Size(200, 23);
            calDate.TabIndex = 5;
            calDate.ValueChanged += calDate_ValueChanged;
            // 
            // frmLoadData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 522);
            Controls.Add(calDate);
            Controls.Add(label4);
            Controls.Add(grdAvFiles);
            Controls.Add(gbStatus);
            Controls.Add(prgLoad);
            Controls.Add(btnLoadFiles);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLoadData";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sessions manager";
            Load += frmLoadData_Load;
            gbStatus.ResumeLayout(false);
            gbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdAvFiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadFiles;
        private ProgressBar prgLoad;
        private GroupBox gbStatus;
        private Label lblTotalKO;
        private Label lblTotalOK;
        private Label lblTotalFiles;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView grdAvFiles;
        private Label label4;
        private DateTimePicker calDate;
        private CheckBox chkIntroData;
    }
}