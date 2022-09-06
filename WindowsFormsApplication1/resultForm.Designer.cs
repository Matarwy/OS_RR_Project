namespace WindowsFormsApplication1
{
    partial class resultForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GanttChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ATATResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.AWTResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GanttChart)).BeginInit();
            this.SuspendLayout();
            // 
            // GanttChart
            // 
            chartArea3.Name = "ChartArea1";
            this.GanttChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.GanttChart.Legends.Add(legend3);
            this.GanttChart.Location = new System.Drawing.Point(39, 108);
            this.GanttChart.Margin = new System.Windows.Forms.Padding(4);
            this.GanttChart.Name = "GanttChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series3.Legend = "Legend1";
            series3.Name = "process";
            series3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series3.YValuesPerPoint = 2;
            this.GanttChart.Series.Add(series3);
            this.GanttChart.Size = new System.Drawing.Size(776, 402);
            this.GanttChart.TabIndex = 0;
            this.GanttChart.Text = "chart1";
            this.GanttChart.Click += new System.EventHandler(this.GanttChart_Click);
            // 
            // ATATResult
            // 
            this.ATATResult.Location = new System.Drawing.Point(577, 51);
            this.ATATResult.Margin = new System.Windows.Forms.Padding(4);
            this.ATATResult.Multiline = true;
            this.ATATResult.Name = "ATATResult";
            this.ATATResult.ReadOnly = true;
            this.ATATResult.Size = new System.Drawing.Size(150, 34);
            this.ATATResult.TabIndex = 1;
            this.ATATResult.TextChanged += new System.EventHandler(this.ATATResult_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(490, 9);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(325, 29);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Average Turn around Time";
            // 
            // AWTResult
            // 
            this.AWTResult.Location = new System.Drawing.Point(90, 51);
            this.AWTResult.Margin = new System.Windows.Forms.Padding(4);
            this.AWTResult.Multiline = true;
            this.AWTResult.Name = "AWTResult";
            this.AWTResult.ReadOnly = true;
            this.AWTResult.Size = new System.Drawing.Size(129, 34);
            this.AWTResult.TabIndex = 3;
            this.AWTResult.TextChanged += new System.EventHandler(this.AWTResult_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Average Waiting Time";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // resultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AWTResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.ATATResult);
            this.Controls.Add(this.GanttChart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "resultForm";
            this.Text = "resultForm";
            this.Load += new System.EventHandler(this.resultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GanttChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GanttChart;
        private System.Windows.Forms.TextBox ATATResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox AWTResult;
        private System.Windows.Forms.Label label1;
    }
}