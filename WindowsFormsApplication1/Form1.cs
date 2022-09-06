using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static double TimeQuantum;
        public static double AverageWaitingTime;
        public static double AverageTurnAroundTime;
        public static int numberOFProcesses;

        //array for Processes & RR Schudling Resulet values for each process to use in Gantt chart in another form
        List<Process> processesDataList;
        public static List<ganttChartC> ganttChartResultList;

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NumOfProcesses_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (txtbox_number_processes.Text != "")
            {
                numberOFProcesses = Convert.ToInt32(txtbox_number_processes.Text);

                for (int i = 0; i < numberOFProcesses; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
        }


        private void SubmitProcessesDataBtn_Click(object sender, EventArgs e)
        {
            resultForm SchudilingResults = new resultForm();

            processesDataList = new List<Process>();
            ganttChartResultList = new List<ganttChartC>();
            Queue<Process> processesQueue = new Queue<Process>(numberOFProcesses);

            //Fill Processes List with the data in  Grid View
            for (int i = 0; i < numberOFProcesses; i++)
            {
                string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();

                //creating object A in class process
                Process A = new Process(textProcess);
                A.Arrival = Convert.ToDouble(textArrival);
                A.Burst = Convert.ToDouble(textBurst);
                A.oldBurst = Convert.ToDouble(textBurst);
                processesDataList.Add(A);
            }

            //sort Processes according to arrival
            processesDataList = processesDataList.OrderBy(process => process.Arrival).ToList();

            double lastArrival = processesDataList[0].Arrival;
            for (int i = 0; i < processesDataList.Count(); i++)
            {
                Process temp = processesDataList[i];
                ganttChartC G = new ganttChartC(temp.Name);
                G.start = lastArrival;
                //first process
                if (i == 0)
                {
                    //then it needs only one round
                    if (temp.Burst <= TimeQuantum)
                    {
                        G.finish = processesDataList[0].Burst;
                        ganttChartResultList.Add(G);
                        lastArrival = G.finish;
                        processesDataList[i].setExitTime(lastArrival);
                    }
                    else
                    {
                        G.finish = TimeQuantum;
                        lastArrival = G.finish;
                        processesDataList[i].setExitTime(lastArrival);
                        double newBurst = processesDataList[i].Burst - TimeQuantum;
                        temp.Burst = newBurst;
                        processesQueue.Enqueue(temp);
                        ganttChartResultList.Add(G);
                    }
                }
                else
                {
                    //then it needs only one round
                    if (temp.Burst <= TimeQuantum)
                    {
                        G.finish = processesDataList[i].Burst + lastArrival;
                        ganttChartResultList.Add(G);
                        lastArrival = G.finish;
                        processesDataList[i].setExitTime(lastArrival);

                    }
                    else
                    {
                        G.finish = TimeQuantum + lastArrival;
                        lastArrival = G.finish;
                        processesDataList[i].setExitTime(lastArrival);
                        double newBurst = processesDataList[i].Burst - TimeQuantum;
                        temp.Burst = newBurst;
                        processesQueue.Enqueue(temp);
                        ganttChartResultList.Add(G);
                    }
                }
            }

            while (processesQueue.Count() > 0)
            {
                Process temp = processesQueue.Dequeue();
                ganttChartC G = new ganttChartC(temp.Name);
                G.start = lastArrival;
                //then it needs only one round
                if (temp.Burst <= TimeQuantum)
                {
                    G.finish = temp.Burst + lastArrival;
                    ganttChartResultList.Add(G);
                    lastArrival = G.finish;
                    for (int i = 0; i < processesDataList.Count(); i++)
                    {
                        if (temp.Name == processesDataList[i].Name && temp.Arrival == processesDataList[i].Arrival)
                        {
                            processesDataList[i].setExitTime(lastArrival);
                        }
                    }

                }
                else
                {
                    G.finish = TimeQuantum + lastArrival;
                    lastArrival = G.finish;
                    for (int i = 0; i < processesDataList.Count(); i++)
                    {
                        if (temp.Name == processesDataList[i].Name && temp.Arrival == processesDataList[i].Arrival)
                        {
                            processesDataList[i].setExitTime(lastArrival);
                        }
                    }
                    double newBurst = temp.Burst - TimeQuantum;
                    temp.Burst = newBurst;
                    processesQueue.Enqueue(temp);
                    ganttChartResultList.Add(G);
                }
            }

            //to count average Turn Around time
            for (int i = 0; i < processesDataList.Count(); i++)
            {
                double tat = processesDataList[i].getExitTime() - processesDataList[i].Arrival;
                processesDataList[i].setTurnAroundTime(tat);
                AverageTurnAroundTime += processesDataList[i].getTurnAroundTime();
                Console.WriteLine("Turn Around Time " + processesDataList[i].Name);
                Console.WriteLine(tat.ToString());
            }
            AverageTurnAroundTime /= numberOFProcesses;
            Console.WriteLine("Average Turn Around Time");
            Console.WriteLine(AverageTurnAroundTime);

            //to count average waiting time
            for (int i = 0; i < processesDataList.Count(); i++)
            {
                double wt = processesDataList[i].getTurnAroundTime() - processesDataList[i].oldBurst;
                processesDataList[i].setWaitingTime(wt);
                AverageWaitingTime += processesDataList[i].getWaitingTime();
                Console.WriteLine("Waiting Times " + processesDataList[i].Name);
                Console.WriteLine(wt.ToString());
            }
            AverageWaitingTime /= numberOFProcesses;
            Console.WriteLine("Average Waiting Time");
            Console.WriteLine(AverageWaitingTime);

            SchudilingResults.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtQuantum_TextChanged(object sender, EventArgs e)
        {
            TimeQuantum = Convert.ToInt32(txtQuantum.Text);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
    class Process
    {
        public string Name;
        public double Arrival;
        public double Burst;
        public double oldBurst;
        private double ExitTime;
        private double TurnAroundTime;
        private double WaitingTime;

        public Process(string n)
        {
            Name = n;
            Arrival = 0;
            Burst = 0;
            oldBurst = 0;
            ExitTime = 0;
            TurnAroundTime = 0;
            WaitingTime = 0;
        }

        public void setExitTime(double a) { ExitTime = a; }
        public void setTurnAroundTime(double a) { TurnAroundTime = a; }
        public void setWaitingTime(double a) { WaitingTime = a; }

        public double getExitTime() { return ExitTime; }
        public double getTurnAroundTime() { return TurnAroundTime; }
        public double getWaitingTime() { return WaitingTime; }

        public bool inList(List<Process> li, string name)
        {
            for (int i = 0; i < li.Count(); i++)
            {
                if (li[i].Name == name) return true;
            }
            return false;
        }
    };



    public class ganttChartC
    {
        public string name;
        public double start, finish;

        public ganttChartC(string _name)
        {
            name = _name;
            start = 0;
            finish = 0;
        }
    };
}
