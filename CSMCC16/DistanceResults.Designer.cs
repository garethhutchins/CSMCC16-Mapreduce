namespace CSMCC16
{
    partial class DistanceResults
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FlightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FlightsTable = new System.Windows.Forms.DataGridView();
            this.Flight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PassengerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PassengerTable = new System.Windows.Forms.DataGridView();
            this.Passenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassengerDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlightsChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlightsTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerChart)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(22, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 412);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.FlightsChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Flights Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FlightsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.FlightsChart.ChartAreas.Add(chartArea1);
            this.FlightsChart.Location = new System.Drawing.Point(7, 7);
            this.FlightsChart.Name = "FlightsChart";
            this.FlightsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.FlightsChart.Series.Add(series1);
            this.FlightsChart.Size = new System.Drawing.Size(732, 359);
            this.FlightsChart.TabIndex = 0;
            this.FlightsChart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FlightsTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flights Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FlightsTable
            // 
            this.FlightsTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FlightsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlightsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Flight,
            this.Distance});
            this.FlightsTable.Location = new System.Drawing.Point(7, 7);
            this.FlightsTable.Name = "FlightsTable";
            this.FlightsTable.ReadOnly = true;
            this.FlightsTable.Size = new System.Drawing.Size(732, 373);
            this.FlightsTable.TabIndex = 0;
            // 
            // Flight
            // 
            this.Flight.HeaderText = "Flight";
            this.Flight.Name = "Flight";
            this.Flight.ReadOnly = true;
            // 
            // Distance
            // 
            this.Distance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Distance.HeaderText = "Distance";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            this.Distance.Width = 74;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PassengerChart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(745, 386);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Passenger Chart";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PassengerChart
            // 
            chartArea2.Name = "ChartArea1";
            this.PassengerChart.ChartAreas.Add(chartArea2);
            this.PassengerChart.Location = new System.Drawing.Point(4, 14);
            this.PassengerChart.Name = "PassengerChart";
            this.PassengerChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.PassengerChart.Series.Add(series2);
            this.PassengerChart.Size = new System.Drawing.Size(726, 361);
            this.PassengerChart.TabIndex = 0;
            this.PassengerChart.Text = "chart1";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.PassengerTable);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(745, 386);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Passenger Table";
            // 
            // PassengerTable
            // 
            this.PassengerTable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.PassengerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PassengerTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Passenger,
            this.PassengerDistance});
            this.PassengerTable.Location = new System.Drawing.Point(4, 4);
            this.PassengerTable.Name = "PassengerTable";
            this.PassengerTable.ReadOnly = true;
            this.PassengerTable.Size = new System.Drawing.Size(738, 379);
            this.PassengerTable.TabIndex = 0;
            // 
            // Passenger
            // 
            this.Passenger.HeaderText = "Passenger";
            this.Passenger.Name = "Passenger";
            this.Passenger.ReadOnly = true;
            // 
            // PassengerDistance
            // 
            this.PassengerDistance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PassengerDistance.HeaderText = "Distance";
            this.PassengerDistance.Name = "PassengerDistance";
            this.PassengerDistance.ReadOnly = true;
            this.PassengerDistance.Width = 74;
            // 
            // DistanceResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "DistanceResults";
            this.Text = "Distance Results";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlightsChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlightsTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PassengerChart)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PassengerTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public  System.Windows.Forms.DataVisualization.Charting.Chart FlightsChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        public  System.Windows.Forms.DataGridView FlightsTable;
        public System.Windows.Forms.DataVisualization.Charting.Chart PassengerChart;
        public System.Windows.Forms.DataGridView PassengerTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
    }
}