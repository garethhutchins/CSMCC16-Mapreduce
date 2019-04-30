namespace CSMCC16
{
    partial class MainForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.btn_apt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_apt = new System.Windows.Forms.TextBox();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pdf = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_output);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_output);
            this.groupBox1.Controls.Add(this.btn_apt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_apt);
            this.groupBox1.Controls.Add(this.btn_pdf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_pdf);
            this.groupBox1.Location = new System.Drawing.Point(26, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(406, 92);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 23);
            this.btn_output.TabIndex = 8;
            this.btn_output.Text = "Browse";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output Directory";
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(117, 96);
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(282, 20);
            this.txt_output.TabIndex = 6;
            // 
            // btn_apt
            // 
            this.btn_apt.Location = new System.Drawing.Point(405, 50);
            this.btn_apt.Name = "btn_apt";
            this.btn_apt.Size = new System.Drawing.Size(75, 23);
            this.btn_apt.TabIndex = 5;
            this.btn_apt.Text = "Browse";
            this.btn_apt.UseVisualStyleBackColor = true;
            this.btn_apt.Click += new System.EventHandler(this.btn_apt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Airport Data File";
            
            // 
            // txt_apt
            // 
            this.txt_apt.Location = new System.Drawing.Point(116, 54);
            this.txt_apt.Name = "txt_apt";
            this.txt_apt.Size = new System.Drawing.Size(282, 20);
            this.txt_apt.TabIndex = 3;
            // 
            // btn_pdf
            // 
            this.btn_pdf.Location = new System.Drawing.Point(403, 15);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(75, 23);
            this.btn_pdf.TabIndex = 2;
            this.btn_pdf.Text = "Browse";
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Passenger Data File";
            // 
            // txt_pdf
            // 
            this.txt_pdf.Location = new System.Drawing.Point(114, 19);
            this.txt_pdf.Name = "txt_pdf";
            this.txt_pdf.Size = new System.Drawing.Size(282, 20);
            this.txt_pdf.TabIndex = 0;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(188, 180);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(287, 180);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Exit";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(6, 19);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(512, 174);
            this.txt_log.TabIndex = 3;
            
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_log);
            this.groupBox2.Location = new System.Drawing.Point(28, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 199);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Reduce";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pdf;
        private System.Windows.Forms.Button btn_apt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_apt;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

