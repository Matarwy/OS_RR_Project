using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class resultForm : Form
    {
        public resultForm()
        {
            InitializeComponent();
        }

        private void GanttChart_Click(object sender, EventArgs e)
        {

        }

        private void resultForm_Load(object sender, EventArgs e)
        {
            string name;
            double first, last;
            AWTResult.Text = Form1.AverageWaitingTime.ToString();
            ATATResult.Text = Form1.AverageTurnAroundTime.ToString();

            for (int i = 0; i < Form1.ganttChartResultList.Count(); i++)
            {
                name = Form1.ganttChartResultList[i].name;
                first = Form1.ganttChartResultList[i].start;
                last = Form1.ganttChartResultList[i].finish;

                this.GanttChart.Series["process"].Points.AddXY(name, first, last);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ATATResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void AWTResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
