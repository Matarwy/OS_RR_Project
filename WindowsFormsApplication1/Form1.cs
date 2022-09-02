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
    public partial class Form1 : Form
    {
        public static double AverageWaitingTime;
        public static int numberOFProcesses;
        public static string[] processName; //array for names and first-last values for each process to use in Gantt chart in another form
        public static double[,] first_last;
         List<process> myList;
        public Form1()
        {
            InitializeComponent();
            myList = new List<process>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chooseASchedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clickHereToChooseASchedulerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_number_processes.Text != "")
            {
                numberOFProcesses = Convert.ToInt32(txtbox_number_processes.Text);

                for (int i = 0; i < numberOFProcesses; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
        }

        private void rRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "RR";
            Process.Visible = true;
            Burst_Time.Visible = true;
            Arrival_Time.Visible = true;
            Priority.Visible = false;
            lblQuantum.Visible = true;
            txtQuantum.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultForm f = new resultForm();

            myList = new List<process>();
            Queue<process> queue = new Queue<process>(numberOFProcesses);
            List<ganttChartC> resultList = new List<ganttChartC>();
            int Q = Convert.ToInt32(AverageWaitingTime); //entered Quantum
            AverageWaitingTime = 0;

            for (int i = 0; i < numberOFProcesses; i++)
            {

                string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();

                process A = new process(textProcess); //creating object A in class process
                A.setArrival(Convert.ToDouble(textArrival));
                A.setBurst(Convert.ToDouble(textBurst));
                myList.Add(A);


            }


            for (int i = 0; i < myList.Count() - 1; i++)  //sort according to arrival
            {

                for (int j = i + 1; j < myList.Count(); j++)
                {

                    if (myList[i].getArrival() > myList[j].getArrival()) //swap 
                    {
                        process temp = myList[i];
                        myList[i] = myList[j];
                        myList[j] = temp;
                    }
                }
            }

            double lastArrival = myList[0].getArrival();
            int count = myList.Count();
            for (int i = 0; i < count; i++)
            {
                ganttChartC G = new ganttChartC(myList[i].getName());
                G.start = lastArrival;
                if (i == 0)  //first process
                {
                    if (myList[i].getBurst() <= Q) //then it needs only one round
                    {
                        G.finish = myList[0].getBurst();
                        resultList.Add(G);
                        lastArrival = G.finish;

                    }
                    else
                    {
                        G.finish = Q;
                        lastArrival = G.finish;
                        double newBurst = myList[i].getBurst() - Q;
                        myList[i].setBurst(newBurst);
                        queue.Enqueue(myList[0]);
                        resultList.Add(G);



                    }
                }
                else
                {

                    if (myList[i].getBurst() <= Q) //then it needs only one round
                    {
                        G.finish = myList[i].getBurst() + lastArrival;
                        resultList.Add(G);
                        lastArrival = G.finish;

                    }
                    else
                    {
                        G.finish = Q + lastArrival;
                        lastArrival = G.finish;
                        double newBurst = myList[i].getBurst() - Q;
                        myList[i].setBurst(newBurst);
                        queue.Enqueue(myList[i]);
                        resultList.Add(G);



                    }


                }
            }

            while (queue.Count() > 0)
            {
                process temp;
                temp = queue.Dequeue();
                ganttChartC G = new ganttChartC(temp.getName());
                G.start = lastArrival;
                if (temp.getBurst() <= Q) //then it needs only one round
                {
                    G.finish = temp.getBurst() + lastArrival;
                    resultList.Add(G);
                    lastArrival = G.finish;

                }
                else
                {
                    G.finish = Q + lastArrival;
                    lastArrival = G.finish;
                    double newBurst = temp.getBurst() - Q;
                    temp.setBurst(newBurst);
                    queue.Enqueue(temp);
                    resultList.Add(G);

                }
            }

            int countElements = myList.Count();
            countElements = resultList.Count();
            processName = new string[countElements];
            first_last = new double[countElements, countElements];
            for (int i = 0; i < countElements; i++) //fill array for gantt chart
            {
                processName[i] = resultList[i].name;
                first_last[i, 0] = resultList[i].start;
                first_last[i, 1] = resultList[i].finish;
            }
            AverageWaitingTime = 0; //to count average waiting time
            for (int i = 0; i < countElements; i++)
            {
                string name = resultList[i].name;
                int j;
                for (j = 0; j < numberOFProcesses; j++)
                {
                    if (myList[j].getName() == name)
                        break;
                }
                AverageWaitingTime += resultList[i].start - myList[j].getArrival(); //start time-Arrival time
                myList[j].setArrival(resultList[i].finish);
            }

            AverageWaitingTime /= numberOFProcesses;

            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtQuantum.Visible = false;
            lblQuantum.Visible = false;
            Process.Visible = false;
            Burst_Time.Visible = false;
            Arrival_Time.Visible = false;
            Priority.Visible = false;
        }

        private void txtQuantum_TextChanged(object sender, EventArgs e)
        {
            AverageWaitingTime = Convert.ToInt32(txtQuantum.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
           
            
        }

        private void chkBox_Scheduler_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    class process
    {
        private string name;
        private double Arrival;
        private double Burst;
        private double Start;
        private double Finish;

        public process(string n) {
            name = n;
            Arrival = 0;
            Burst = 0;
            ;Finish = 0;
            Start = 0;
        }

        public void setArrival(double a) { Arrival = a; }
        public void setBurst(double a) { Burst = a; }
        public void setFinish(double a) { Finish = a; }
        public void setStart(double a) { Start = a; }

        public string getName() { return name; }
        public double getArrival() { return Arrival; }
        public double getBurst() { return Burst; }
        public double getStart() { return Start; }
        public double getFinish() { return Finish; }

        public bool inList(List<process> li, string name)
        {
            for (int i = 0; i < li.Count(); i++)
            {
                if (li[i].getName() == name) return true;
            }
            return false;
        }
    };



    class ganttChartC
    {
        public string name;
        public double start, finish;

        public ganttChartC(string name2)
        {
            name = name2;
            start = 0;
            finish = 0;
        }
    };
}
