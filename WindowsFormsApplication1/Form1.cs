using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
                // save number of processes
                numberOFProcesses = Convert.ToInt32(txtbox_number_processes.Text);
                //add number of rows to data grid view equle number of processes
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

            //Fill Processes List with data from  Grid View
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
                    if (temp.Burst <= TimeQuantum)
                    {
                        //it needs only one round
                        G.finish = processesDataList[0].Burst;
                        lastArrival = G.finish;
                        //add result to gantt chart array list
                        ganttChartResultList.Add(G);
                        //set exit time for current process
                        processesDataList[i].setExitTime(lastArrival);
                    }
                    else
                    {
                        G.finish = TimeQuantum;
                        lastArrival = G.finish;
                        //set exit time for current process
                        processesDataList[i].setExitTime(lastArrival);
                        double newBurst = processesDataList[i].Burst - TimeQuantum;
                        temp.Burst = newBurst;
                        //enqueue process to the queue for continu working on it lateer
                        processesQueue.Enqueue(temp);
                        //add result to gantt chart array list
                        ganttChartResultList.Add(G);
                    }
                }
                else
                {
                    if (temp.Burst <= TimeQuantum)
                    {
                        //it needs only one round
                        G.finish = processesDataList[i].Burst + lastArrival;
                        lastArrival = G.finish;
                        //add result to gantt chart array list
                        ganttChartResultList.Add(G);
                        //set exit time for current process
                        processesDataList[i].setExitTime(lastArrival);

                    }
                    else
                    {
                        G.finish = TimeQuantum + lastArrival;
                        lastArrival = G.finish;
                        //set exit time for current process
                        processesDataList[i].setExitTime(lastArrival);
                        double newBurst = processesDataList[i].Burst - TimeQuantum;
                        temp.Burst = newBurst;
                        //enqueue process to the queue for continu working on it lateer
                        processesQueue.Enqueue(temp);
                        //add result to gantt chart array list
                        ganttChartResultList.Add(G);
                    }
                }
            }

            while (processesQueue.Count() > 0)
            {

                Process temp = processesQueue.Dequeue();
                ganttChartC G = new ganttChartC(temp.Name);
                G.start = lastArrival;

                if (temp.Burst <= TimeQuantum)
                {
                    //it needs only one round
                    G.finish = temp.Burst + lastArrival;
                    lastArrival = G.finish;
                    //add result to gantt chart array list
                    ganttChartResultList.Add(G);
                    //set exit time for current process
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
                    //set exit time for current process
                    for (int i = 0; i < processesDataList.Count(); i++)
                    {
                        if (temp.Name == processesDataList[i].Name && temp.Arrival == processesDataList[i].Arrival)
                        {
                            processesDataList[i].setExitTime(lastArrival);
                        }
                    }

                    double newBurst = temp.Burst - TimeQuantum;
                    temp.Burst = newBurst;
                    //enqueue process to the queue for continu working on it lateer
                    processesQueue.Enqueue(temp);
                    //add result to gantt chart array list
                    ganttChartResultList.Add(G);
                }
            }

            //to count average Turn Around time
            for (int i = 0; i < processesDataList.Count(); i++)
            {
                double tat = processesDataList[i].getExitTime() - processesDataList[i].Arrival;
                processesDataList[i].setTurnAroundTime(tat);
                AverageTurnAroundTime += processesDataList[i].getTurnAroundTime();
                //show turn around time for each process in console app
                Console.WriteLine("Turn Around Time " + processesDataList[i].Name);
                Console.WriteLine(tat.ToString());
            }
            //calculate average turn around time   -- sum(turn around time for each process)/number of process --
            AverageTurnAroundTime /= numberOFProcesses;
            //show average turn around time in console app
            Console.WriteLine("Average Turn Around Time");
            Console.WriteLine(AverageTurnAroundTime);

            //to count average waiting time
            for (int i = 0; i < processesDataList.Count(); i++)
            {
                double wt = processesDataList[i].getTurnAroundTime() - processesDataList[i].oldBurst;
                processesDataList[i].setWaitingTime(wt);
                AverageWaitingTime += processesDataList[i].getWaitingTime();
                //show waiting time for each process in console app
                Console.WriteLine("Waiting Times " + processesDataList[i].Name);
                Console.WriteLine(wt.ToString());
            }
            //calculate average turn around time   -- sum(waiting time for each process)/number of process --
            AverageWaitingTime /= numberOFProcesses;
            //show average waiting time in console app
            Console.WriteLine("Average Waiting Time");
            Console.WriteLine(AverageWaitingTime);

            SchudilingResults.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // save time quantum to variable
        private void txtQuantum_TextChanged(object sender, EventArgs e)
        {
            TimeQuantum = Convert.ToInt32(txtQuantum.Text);
        }

        //reset data grid views rows and data
        private void resetBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }

    /*
        class process
        attributes :-
            1- name : save process name
            2- Arrival : save Arriveal Time
            3- Burst : Save Burst Time which decreasing by code processing
            4- oldBurst : Save Burst Time and not manupating it
            5- ExitTime : Save process schudeling exit time to calculate turn around time
            6- turnAroundTime : save turn around time to calculate waiting time
            7- waitingTime : calculate the waiting time for process
     */
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

    };

    /*
        class ganttchartC
        attributes
            1- name : save process name for each schduling entery
            2- start : save start time for entery - the time when schduling entery enter cpu
            3- finish : save finish time for entery - the time when schduling entery exit cpu
     */
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
