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
        public static int schedulerIndicator;
        public static int numberOFProcesses;
        public static string[] processName; //array for names and first-last values for each process to use in Gantt chart in another form
        public static double[,] first_last;
         List<process> myList;
        public Form1()
        {
            InitializeComponent();
            schedulerIndicator = 0;
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

        private void fCFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 1;
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "FCFS";
            Process.Visible = true;
            Burst_Time.Visible = true;
            Arrival_Time.Visible = true;
          
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void sJFpreemptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 2;
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "SJF_preemptive";
            Process.Visible = true;
            Burst_Time.Visible = true;
            Arrival_Time.Visible = true;
            Priority.Visible = false;
           
        }

        private void sJFnonpreemptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 3;
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "SJF_non_preemptive";
            Process.Visible = true;
            Burst_Time.Visible = true;
            Arrival_Time.Visible = true;
            
          
        }

        private void prioritypreemptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 4;
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "PRIORITY_preemptive";
            Process.Visible = true;
            Arrival_Time.Visible = true;
            Priority.Visible = true;
            Burst_Time.Visible = true; 
        }

        private void prioritynonpreemptiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 5;
            chkBox_Scheduler.Checked = true;
            chkBox_Scheduler.Text = "PRIORITY_non_preemptive";
            Burst_Time.Visible = true;
            txtQuantum.Visible = false;
            lblQuantum.Visible = false;
            Process.Visible = true;     
            Arrival_Time.Visible = true;
            Priority.Visible = true;
        }

        private void rRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schedulerIndicator = 6;
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
              switch(schedulerIndicator)
              {   case 1: //FCFS
                      myList = new List<process>();
                      for (int i = 0; i < numberOFProcesses; i++)
                      {

                          string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                          string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                          string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();

                          process A = new process(textProcess); //creating object A in class process
                          A.setArrival(Convert.ToDouble((textArrival)) );
                          A.setBurst(Convert.ToDouble(textBurst));
                          myList.Add(A);

                      }

                     for (int i = 0; i < myList.Count()-1; i++)  //sort according to arrival
                      {
                        
                         for (int j = i+1; j < myList.Count(); j++)
                         {

                             if (myList[i].getArrival() >myList[j].getArrival() ) //swap 
                             {
                                process temp = myList[i];
                                myList[i]=myList[j];
                                myList[j] = temp;
                             }
                         }
                     }

                     int countElements = myList.Count();
                     double lastFinish = 0;
                     for (int i = 0; i < countElements; i++) //to set start and finish values
                     {
                         if (i == 0) //first process
                         {
                             myList[i].setStart(myList[i].getArrival());
                             myList[i].setFinish(myList[i].getArrival() + myList[i].getBurst());
                             lastFinish = myList[i].getFinish();
                         }
                         else
                         {
                             myList[i].setStart(lastFinish);
                             myList[i].setFinish ((myList[i].getStart() + myList[i].getBurst()));
                             lastFinish = myList[i].getFinish();


                         }


                     }
                      
                    processName = new string[countElements]; 
                    first_last = new double[countElements, countElements];
                    AverageWaitingTime = 0;
                    for (int i = 0; i < countElements; i++)
                    {

                        processName[i] = myList[i].getName();
                        first_last[i, 0] = myList[i].getStart();
                        first_last[i, 1] = myList[i].getFinish();
                        AverageWaitingTime += myList[i].getStart() - myList[i].getArrival();


                    }
                      AverageWaitingTime /= countElements;  
                    
                       f.ShowDialog();

                      break;
                  case 2: //SJF preemptive
                      List<process> copyList = new List<process>();
                      myList = new List<process>();
                     for (int i = 0; i < numberOFProcesses; i++)
                     {
                       
                        
                         string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                         string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                         string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();

                         process A = new process(textProcess); //creating object A in class process
                         A.setArrival(Convert.ToDouble(textArrival));
                         A.setBurst(Convert.ToDouble(textBurst));                    
                         myList.Add(A);
                         copyList.Add(A);
                   
                     }                           

                    for (int i = 0; i < myList.Count()-1; i++)  //sort according to arrival
                    {
                        
                        for (int j = i+1; j < myList.Count(); j++)
                        {

                            if (myList[i].getArrival() > myList[j].getArrival() || ( myList[i].getArrival() == myList[j].getArrival() && myList[i].getBurst()>myList[j].getBurst() )) //swap 
                            {
                                process temp = myList[i];
                                myList[i]=myList[j];
                                myList[j] = temp;
                            }
                        }
                    }
                    //copyList.Add(myList[myList.Count() - 1]);
                    List<process> waitingList = new List<process>();
                    List<ganttChartC> resultList=new List<ganttChartC>();
                   
                    int count_time = 0;
                    double lastArrival = myList[0].getArrival();
                    for (int i = 0; i < myList.Count(); i++)   //counting number of different Arrival times in the list 
                    {
                        if(i==0)
                        {
                            count_time++;

                            continue;
                        }
                        else if (myList[i].getArrival() != lastArrival)
                        {
                            count_time++;
                            lastArrival = myList[i].getArrival();
                        }
                    }
                   
                    
                    double next_Executed_Arrival = 0;
                   // int min;
                  
                    for (int i = 0; i < count_time; i++)
                    {
                        double arrivedT = myList[0].getArrival();                 
                        waitingList.Add(myList[0]);
                        myList.Remove(myList[0]);
                        if (myList.Count() > 0)
                        {
                            while (myList[0].getArrival() == arrivedT) //take each arrived one to the waiting  list
                            {

                                waitingList.Add(myList[0]);
                                myList.Remove(myList[0]);
                                if (myList.Count() < 1) break;

                            }
                        }
                        if (i != 0) //first time is already sorted
                        {
                            for (int j = 0; j < waitingList.Count() - 1; j++) //sort waiting list
                            {
                                for (int k = j + 1; k < waitingList.Count(); k++)
                                {
                                    if (waitingList[j].getBurst() > waitingList[k].getBurst())
                                    {
                                        process temp = waitingList[j];
                                        waitingList[j] = waitingList[k];
                                        waitingList[k] = temp;
                                    }
                                }
                            }

                            //check whether it's the same process or not
                            string lastExecutedProcessName = resultList[resultList.Count() - 1].name;
                            if (waitingList[0].getName() == lastExecutedProcessName) //same process
                            {
                                if (i + 1 < count_time) //still there's another process to arrive
                                {
                                    next_Executed_Arrival = myList[0].getArrival();
                                    next_Executed_Arrival -= resultList[resultList.Count() - 1].finish;
                                    if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                    {
                                        resultList[resultList.Count() - 1].finish += waitingList[0].getBurst();
                                        waitingList.Remove(waitingList[0]);
                                    }
                                    else
                                    {
                                        resultList[resultList.Count() - 1].finish += next_Executed_Arrival;
                                        double newBurst = waitingList[0].getBurst(); //editing burst time of executed process
                                        newBurst -= next_Executed_Arrival;
                                        waitingList[0].setBurst(newBurst);
                                    }
                                }

                                else  //no new process to arrive , so it becomes non preemptive
                                {
                                    resultList[resultList.Count() - 1].finish += waitingList[0].getBurst();                                 
                                    waitingList.Remove(waitingList[0]);
                                }

                            }
                            else
                            {
                                ganttChartC S = new ganttChartC(waitingList[0].getName());
                                S.start = waitingList[0].getArrival();
                                if (i + 1 < count_time) //still there's another process to arrive
                                {
                                    next_Executed_Arrival = myList[0].getArrival();
                                    next_Executed_Arrival -= resultList[resultList.Count() - 1].finish;
                                    if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                    {
                                        S.finish = S.start + waitingList[0].getBurst();
                                        resultList.Add(S);
                                        waitingList.Remove(waitingList[0]);
                                    }
                                    else
                                    {
                                        S.finish =S.start+ next_Executed_Arrival;
                                        resultList.Add(S);
                                        double newBurst = waitingList[0].getBurst();
                                        newBurst -= next_Executed_Arrival;
                                        waitingList[0].setBurst(newBurst);
                                    }

                                   
                                }

                                else  //no new process to arrive , so it becomes non preemptive
                                {
                                    S.finish = S.start+waitingList[0].getBurst();
                                    resultList.Add(S);
                                    waitingList.Remove(waitingList[0]);
                                }



                            }
                        }
                        else  //first time
                        {
                            ganttChartC S = new ganttChartC(waitingList[0].getName());
                            S.start = waitingList[0].getArrival();
                            if (i + 1 < count_time) //still there's another process to arrive
                            {
                                next_Executed_Arrival = myList[0].getArrival();

                                if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                {
                                    S.finish = S.start+waitingList[0].getBurst();

                                    resultList.Add(S);
                                    waitingList.Remove(waitingList[0]);
                                }
                                else
                                {
                                    S.finish =S.start+ next_Executed_Arrival;

                                    resultList.Add(S);
                                    double newBurst = waitingList[0].getBurst();
                                    newBurst -= next_Executed_Arrival;
                                    waitingList[0].setBurst(newBurst);
                                }

                            }

                            else 
                            {
                                S.finish = S.start+waitingList[0].getBurst();
                                resultList.Add(S);
                                waitingList.Remove(waitingList[0]);
                            }

                        }
                    }
                    while (waitingList.Count() > 0) //now they are sorted in the waiting list and non preemptive
                    {

                        ganttChartC S = new ganttChartC(waitingList[0].getName());
                        S.start = resultList[resultList.Count() - 1].finish;
                        S.finish = S.start+waitingList[0].getBurst();
                        resultList.Add(S);
                        waitingList.Remove(waitingList[0]);


                    }
                     countElements = resultList.Count();
                     processName = new string[countElements]; 
                    first_last = new double[countElements, countElements];
                    for (int i = 0; i < countElements;i++ ) //fill array for gantt chart
                    {
                        processName[i]=resultList[i].name;
                        first_last[i, 0] = resultList[i].start;
                        first_last[i, 1] = resultList[i].finish;
                    }

                    //to find average Waiting time
                    
                    AverageWaitingTime = 0;int index=0;
                    for (int i = 0; i < countElements; i++)
                    {
                        for (int j = 0; j < copyList.Count(); j++)
                        {
                            if (copyList[j].getName() == processName[i])
                            {
                                index = j;

                            }
                        }


                       AverageWaitingTime += first_last[i, 0] - copyList[index].getArrival(); //start time-arrival time
                      
                        copyList[index].setArrival(resultList[i].finish); //new arrival time in the waiting queue
                      


                    }
                    
                   AverageWaitingTime /= (double)numberOFProcesses;
                                                  
                    f.ShowDialog();
                  
                
                 break;
                 case 3: //SJF non_preemptive  //same arrival time is ok


                 List<process> priorityList = new List<process>(numberOFProcesses);
                 myList = new List<process>();
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

                 for (int j =0 ; j < myList.Count(); j++)  //choosing first arrived process with less Burst time to start
                  {

                      if ((myList[0].getArrival() > myList[j].getArrival()) || (myList[0].getArrival() == myList[j].getArrival() && myList[0].getBurst() > myList[j].getBurst())) //swap 
                       {
                             process temp = myList[0];
                             myList[0] = myList[j];
                             myList[j] = temp;
                       }
                  }
                     priorityList.Add(myList[0]); //this list contains processes in the desired Burst order
                     myList.Remove(myList[0]);
                 for (int i = 0; i < myList.Count() - 1; i++)  //sort according to burst
                 {
                     for (int j = i + 1; j < myList.Count(); j++)
                     {

                             if ((myList[i].getBurst() > myList[j].getBurst()) ) //swap 
                             {
                                 process temp = myList[i];
                                 myList[i] = myList[j];
                                 myList[j] = temp;
                             }
                    }
                }
               double doneBurst = priorityList[0].getBurst(); //passed time on processes
               int  myIndex = 0;
               while (myList.Count() > 1)
               {          
                     myIndex = 0;
                     while (myList[myIndex].getArrival() > doneBurst)
                     {
                         myIndex++;

                     }
                     //process  with higher priority arrived and exists in  myList[ myIndex ]
                     priorityList.Add(myList[myIndex]);
                     doneBurst += myList[myIndex].getBurst();
                     myList.Remove(myList[myIndex]);

              }

               //one process remained, ensure its arrival
             priorityList.Add(myList[0]); 
             myList.Remove(myList[myIndex]);                 
             lastFinish = 0;
             for (int i = 0; i < priorityList.Count(); i++) //to set start and finish values
             {
                     if (i == 0) //first process
                      {
                          priorityList[i].setStart(priorityList[i].getArrival());
                          priorityList[i].setFinish(priorityList[i].getArrival() + priorityList[i].getBurst());
                          lastFinish = priorityList[i].getFinish();
                       }
                       else
                       {
                             
                           priorityList[i].setStart(lastFinish);
                           priorityList[i].setFinish ((priorityList[i].getStart() + priorityList[i].getBurst()));
                           lastFinish = priorityList[i].getFinish();


                       }


               }
               countElements = priorityList.Count();
               processName = new string[countElements]; 
               first_last = new double[countElements, countElements];
               AverageWaitingTime = 0;
               for (int i = 0; i < countElements; i++)
               {

                        processName[i] = priorityList[i].getName();
                        first_last[i, 0] = priorityList[i].getStart();
                        first_last[i, 1] = priorityList[i].getFinish();
                        AverageWaitingTime += priorityList[i].getStart() - priorityList[i].getArrival();


                }
                AverageWaitingTime /= countElements;  
                     
                    
                f.ShowDialog();

                 break;

                 case 4:  //priority preemptive
                     copyList = new List<process>();
                     myList = new List<process>();
                     for (int i = 0; i < numberOFProcesses; i++)
                     {
                       
                        
                         string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                         string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                         string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();
                         string textPriority = dataGridView1.Rows[i].Cells[3].Value.ToString();
                         process A = new process(textProcess); //creating object A in class process
                         A.setArrival(Convert.ToDouble(textArrival));
                         A.setBurst(Convert.ToDouble(textBurst));
                         A.setPriority(Convert.ToDouble(textPriority));
                         myList.Add(A);
                         copyList.Add(A);
                   
                     }

                    for (int i = 0; i < myList.Count()-1; i++)  //sort according to arrival
                     {                     
                        for (int j = i+1; j < myList.Count(); j++)
                        {

                            if (myList[i].getArrival() > myList[j].getArrival() || (myList[i].getArrival() == myList[j].getArrival() && myList[i].getPriority() > myList[j].getPriority())) //swap 
                            {
                                process temp = myList[i];
                                myList[i]=myList[j];
                                myList[j] = temp;
                            }
                        }
                    }
                    
                    waitingList = new List<process>();
                    resultList=new List<ganttChartC>();
                   count_time = 0;
                   lastArrival = myList[0].getArrival();
                   for (int i = 0; i < myList.Count(); i++)   //counting number of different Arrival times in the list 
                   {
                      if(i==0)
                      {
                          count_time++;
                          continue;
                      }
                     else if (myList[i].getArrival() != lastArrival)
                     {
                         count_time++;
                         lastArrival = myList[i].getArrival();
                     }

                   }
                   
                    
                  next_Executed_Arrival = 0;
                  for (int i = 0; i < count_time; i++)
                  {
                      double arrivedT = myList[0].getArrival();                 
                      waitingList.Add(myList[0]);
                      myList.Remove(myList[0]);
                     if (myList.Count() > 0)
                      {
                         while (myList[0].getArrival() == arrivedT) //take each arrived one to the waiting  list
                         {

                             waitingList.Add(myList[0]);
                             myList.Remove(myList[0]);
                             if (myList.Count() < 1) break;

                         }
                     }
                    if (i != 0) //first time is already sorted
                    {
                        for (int j = 0; j < waitingList.Count() - 1; j++) //sort waiting list according to priority
                        {
                             for (int k = j + 1; k < waitingList.Count(); k++)
                             {
                                    if (waitingList[j].getPriority() > waitingList[k].getPriority())
                                    {
                                        process temp = waitingList[j];
                                        waitingList[j] = waitingList[k];
                                        waitingList[k] = temp;
                                    }
                                }
                       }

                            //check whether it's the same process or not
                            string lastExecutedProcessName = resultList[resultList.Count() - 1].name;
                            if (waitingList[0].getName() == lastExecutedProcessName) //same process
                            {
                                if (i + 1 < count_time) //still there's another process to arrive
                                {
                                    next_Executed_Arrival = myList[0].getArrival();
                                    next_Executed_Arrival -= resultList[resultList.Count() - 1].finish;
                                    if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                    {
                                        resultList[resultList.Count() - 1].finish += waitingList[0].getBurst();
                                        waitingList.Remove(waitingList[0]);
                                    }
                                    else
                                    {
                                        resultList[resultList.Count() - 1].finish += next_Executed_Arrival;
                                        double newBurst = waitingList[0].getBurst(); //editing burst time of executed process
                                        newBurst -= next_Executed_Arrival;
                                        waitingList[0].setBurst(newBurst);
                                    }
                                }

                                else  //no new process to arrive , so it becomes non preemptive
                                {
                                    resultList[resultList.Count() - 1].finish += waitingList[0].getBurst();                                 
                                    waitingList.Remove(waitingList[0]);
                                }

                            }
                            else
                            {
                                ganttChartC S = new ganttChartC(waitingList[0].getName());
                                S.start = waitingList[0].getArrival();
                                if (i + 1 < count_time) //still there's another process to arrive
                                {
                                    next_Executed_Arrival = myList[0].getArrival();
                                    next_Executed_Arrival -= resultList[resultList.Count() - 1].finish;
                                    if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                    {
                                        S.finish = S.start + waitingList[0].getBurst();
                                        resultList.Add(S);
                                        waitingList.Remove(waitingList[0]);
                                    }
                                    else
                                    {
                                        S.finish =S.start+ next_Executed_Arrival;
                                        resultList.Add(S);
                                        double newBurst = waitingList[0].getBurst();
                                        newBurst -= next_Executed_Arrival;
                                        waitingList[0].setBurst(newBurst);
                                    }

                                   
                                }

                                else  //no new process to arrive , so it becomes non preemptive
                                {
                                    S.finish = S.start+waitingList[0].getBurst();
                                    resultList.Add(S);
                                    waitingList.Remove(waitingList[0]);
                                }



                            }
                        }
                        else  //first time
                        {
                            ganttChartC S = new ganttChartC(waitingList[0].getName());
                            S.start = waitingList[0].getArrival();
                            if (i + 1 < count_time) //still there's another process to arrive
                            {
                                next_Executed_Arrival = myList[0].getArrival();

                                if (next_Executed_Arrival >= waitingList[0].getBurst()) // it means process has finished
                                {
                                    S.finish = S.start+waitingList[0].getBurst();

                                    resultList.Add(S);
                                    waitingList.Remove(waitingList[0]);
                                }
                                else
                                {
                                    S.finish =S.start+ next_Executed_Arrival;

                                    resultList.Add(S);
                                    double newBurst = waitingList[0].getBurst();
                                    newBurst -= next_Executed_Arrival;
                                    waitingList[0].setBurst(newBurst);
                                }

                            }

                            else 
                            {
                                S.finish = S.start+waitingList[0].getBurst();
                                resultList.Add(S);
                                waitingList.Remove(waitingList[0]);
                            }

                        }
                    }
                    while (waitingList.Count() > 0) //now they are sorted in the waiting list and non preemptive
                    {

                        ganttChartC S = new ganttChartC(waitingList[0].getName());
                        S.start = resultList[resultList.Count() - 1].finish;
                        S.finish = S.start+waitingList[0].getBurst();
                        resultList.Add(S);
                        waitingList.Remove(waitingList[0]);


                    }
                     countElements = resultList.Count();
                     processName = new string[countElements]; 
                    first_last = new double[countElements, countElements];
                    for (int i = 0; i < countElements;i++ ) //fill array for gantt chart
                    {
                        processName[i]=resultList[i].name;
                        first_last[i, 0] = resultList[i].start;
                        first_last[i, 1] = resultList[i].finish;
                    }

                    //to find average Waiting time
                      
                    AverageWaitingTime = 0; index=0;
                    for (int i = 0; i < countElements; i++)
                    {
                        for (int j = 0; j < copyList.Count(); j++)
                        {
                            if (copyList[j].getName() == processName[i])
                            {
                                index = j;

                            }
                        }


                       AverageWaitingTime += first_last[i, 0] - copyList[index].getArrival(); //start time-arrival time
                      
                        copyList[index].setArrival(resultList[i].finish); //new arrival time in the waiting queue                     

                    }
                    
                   AverageWaitingTime /= (double)numberOFProcesses;
                   f.ShowDialog();
                 break;

                 case 5: //priority non_preemptive  .

                 priorityList= new List<process>(numberOFProcesses);
                 myList = new List<process>();
                 for (int i = 0; i < numberOFProcesses; i++)
                 {
                     string textProcess = dataGridView1.Rows[i].Cells[0].Value.ToString();
                     string textBurst = dataGridView1.Rows[i].Cells[1].Value.ToString();
                     string textArrival = dataGridView1.Rows[i].Cells[2].Value.ToString();   
                     string textPriority= dataGridView1.Rows[i].Cells[3].Value.ToString();   
                     process A = new process(textProcess); //creating object A in class process
                     A.setArrival(Convert.ToDouble(textArrival));
                     A.setPriority(Convert.ToDouble(textPriority));
                     A.setBurst(Convert.ToDouble(textBurst));
                     myList.Add(A);
                     

                 }


               
                     for (int j =0 ; j < myList.Count(); j++)  //choosing first arrived process with higher priority to start
                     {

                         if ((myList[0].getArrival() > myList[j].getArrival()) || (myList[0].getArrival() == myList[j].getArrival() && myList[0].getPriority() > myList[j].getPriority())) //swap 
                         {
                             process temp = myList[0];
                             myList[0] = myList[j];
                             myList[j] = temp;
                         }
                     }
                     priorityList.Add(myList[0]); //this list contains processes in the desired priority order
                     myList.Remove(myList[0]);
                 
                for (int i = 0; i < myList.Count() - 1; i++)  //sort mylist  according to priority
                 {

                     for (int j = i + 1; j < myList.Count(); j++)
                     {

                         if ((myList[i].getPriority() > myList[j].getPriority()) ) //swap 
                         {
                             process temp = myList[i];
                             myList[i] = myList[j];
                             myList[j] = temp;
                         }
                     }
                 }

                  doneBurst = priorityList[0].getBurst(); //passed time on processes
                   myIndex = 0;
                 while (myList.Count() > 1)
                 {
                     //for (int i = 1; i <= myList.Count(); i++) //checking that elements with higher priority are arrived ,and put them in the priority queue with order

                     myIndex = 0;
                     while (myList[myIndex].getArrival() > doneBurst)
                     {
                         myIndex++;

                     }
                     //process  with higher priority arrived and exists in  myList[ myIndex ]
                     priorityList.Add(myList[myIndex]);
                     doneBurst += myList[myIndex].getBurst();
                     myList.Remove(myList[myIndex]);

                 }

               //one process remained, ensure its arrival
                 priorityList.Add(myList[0]); 
                 myList.Remove(myList[myIndex]);

                 
                 lastFinish = 0;
                     for (int i = 0; i < priorityList.Count(); i++) //to set start and finish values
                     {
                         if (i == 0) //first process
                         {
                             priorityList[i].setStart(priorityList[i].getArrival());
                             priorityList[i].setFinish(priorityList[i].getArrival() + priorityList[i].getBurst());
                             lastFinish = priorityList[i].getFinish();
                         }
                         else
                         {
                             
                             priorityList[i].setStart(lastFinish);
                             priorityList[i].setFinish ((priorityList[i].getStart() + priorityList[i].getBurst()));
                             lastFinish = priorityList[i].getFinish();


                         }


                     }
                     countElements = priorityList.Count();
                    processName = new string[countElements]; 
                    first_last = new double[countElements, countElements];
                    AverageWaitingTime = 0;
                    for (int i = 0; i < countElements; i++)
                    {

                        processName[i] = priorityList[i].getName();
                        first_last[i, 0] = priorityList[i].getStart();
                        first_last[i, 1] = priorityList[i].getFinish();
                        AverageWaitingTime += priorityList[i].getStart() - priorityList[i].getArrival();


                    }
                      AverageWaitingTime /= countElements;  
                   
                       f.ShowDialog();

                 break;
                 case 6: //RR
                     myList = new List<process>();
                     Queue<process> queue = new Queue<process>(numberOFProcesses);
                     resultList = new List<ganttChartC>();
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


                    for (int i = 0; i < myList.Count()-1; i++)  //sort according to arrival
                    {
                        
                        for (int j = i+1; j < myList.Count(); j++)
                        {

                            if (myList[i].getArrival() > myList[j].getArrival()) //swap 
                            {
                                process temp = myList[i];
                                myList[i]=myList[j];
                                myList[j] = temp;
                            }
                        }
                    }

                    lastArrival = myList[0].getArrival();
                    int count = myList.Count();
                    for (int i = 0; i < count; i++)
                    {
                        ganttChartC G = new ganttChartC( myList[i].getName());
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
                                double newBurst = myList[i].getBurst() - Q ;
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
                            double newBurst =temp.getBurst() - Q;
                            temp.setBurst(newBurst);
                            queue.Enqueue(temp);
                            resultList.Add(G);                          

                        }
                    }
                         countElements = resultList.Count();
                     processName = new string[countElements]; 
                    first_last = new double[countElements, countElements];
                    for (int i = 0; i < countElements;i++ ) //fill array for gantt chart
                    {
                        processName[i]=resultList[i].name;
                        first_last[i, 0] = resultList[i].start;
                        first_last[i, 1] = resultList[i].finish;
                    }
                    AverageWaitingTime = 0; //to count average waiting time
                    for (int i = 0; i < countElements; i++)
                    {
                        string name=resultList[i].name;
                        int j;
                        for( j=0;j<numberOFProcesses;j++)
                        {
                            if( myList[j].getName()== name)
                                break;
                        }
                        AverageWaitingTime+=resultList[i].start - myList[j].getArrival()  ; //start time-Arrival time
                        myList[j].setArrival(resultList[i].finish);
                    }

                    AverageWaitingTime /= numberOFProcesses;

                    f.ShowDialog();                 
                 break;
                                  
           }
                

            
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
        private double priority;
        private double Start;
        private double Finish;
        public process(string n) { name = n; Arrival = 0; Burst = 0; ;Finish = 0; priority = 0; Start = 0; }
        public void setArrival(double a) { Arrival = a; }
        public void setBurst(double a) { Burst = a; }
        public void setFinish(double a) { Finish = a; }
        public void setStart(double a) { Start = a; }
        public void setPriority(double a) { priority = a; }
        public string getName() { return name; }
        public double getArrival() { return Arrival; }
        public double getBurst() { return Burst; }
        public double getPriority() { return priority; }
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
    public static class MyStaticClass
    {
        public static double lastFinalValue = 0;


        public static double MyLastFinalValue { get; set; }
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
