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
            textResult.Text = Form1.AverageWaitingTime.ToString();

            for (int i = 0; i < Form1.processName.Length; i++)
            {
                name = Form1.processName[i];
                first = Form1.first_last[i, 0];
                last = Form1.first_last[i, 1];

                this.GanttChart.Series["process"].Points.AddXY(name, first, last);
            }
        }

        private void textResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
