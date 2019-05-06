namespace CSMCC16
{
    partial class AllFlightInformation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FlightID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassengerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepAPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestApt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FlightID,
            this.PassengerID,
            this.DepAPT,
            this.DestApt,
            this.DepartureTime,
            this.ArrivalTime,
            this.FlightTime});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 425);
            this.dataGridView1.TabIndex = 0;
            // 
            // FlightID
            // 
            this.FlightID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlightID.HeaderText = "Flight ID";
            this.FlightID.Name = "FlightID";
            this.FlightID.Width = 71;
            // 
            // PassengerID
            // 
            this.PassengerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PassengerID.HeaderText = "Passenger ID";
            this.PassengerID.Name = "PassengerID";
            this.PassengerID.Width = 96;
            // 
            // DepAPT
            // 
            this.DepAPT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DepAPT.HeaderText = "Departure Airport";
            this.DepAPT.Name = "DepAPT";
            this.DepAPT.Width = 103;
            // 
            // DestApt
            // 
            this.DestApt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DestApt.HeaderText = "Destination Airport";
            this.DestApt.Name = "DestApt";
            this.DestApt.Width = 108;
            // 
            // DepartureTime
            // 
            this.DepartureTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DepartureTime.HeaderText = "Departure Time";
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.Width = 96;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ArrivalTime.HeaderText = "Arrival Time";
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.Width = 80;
            // 
            // FlightTime
            // 
            this.FlightTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlightTime.HeaderText = "Flight Time";
            this.FlightTime.Name = "FlightTime";
            this.FlightTime.Width = 77;
            // 
            // AllFlightInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AllFlightInformation";
            this.Text = "All Flight Information";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepAPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestApt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightTime;
    }
}