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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GanttChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GanttChart)).BeginInit();
            this.SuspendLayout();
            // 
            // GanttChart
            // 
            chartArea1.Name = "ChartArea1";
            this.GanttChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GanttChart.Legends.Add(legend1);
            this.GanttChart.Location = new System.Drawing.Point(39, 202);
            this.GanttChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GanttChart.Name = "GanttChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.Legend = "Legend1";
            series1.Name = "process";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series1.YValuesPerPoint = 2;
            this.GanttChart.Series.Add(series1);
            this.GanttChart.Size = new System.Drawing.Size(776, 308);
            this.GanttChart.TabIndex = 0;
            this.GanttChart.Text = "chart1";
            this.GanttChart.Click += new System.EventHandler(this.GanttChart_Click);
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(263, 95);
            this.textResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(265, 58);
            this.textResult.TabIndex = 1;
            this.textResult.TextChanged += new System.EventHandler(this.textResult_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(217, 31);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(337, 29);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Total Average Waiting Time";
            // 
            // resultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 524);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.GanttChart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "resultForm";
            this.Text = "resultForm";
            this.Load += new System.EventHandler(this.resultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GanttChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GanttChart;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Label lblResult;
    }
}