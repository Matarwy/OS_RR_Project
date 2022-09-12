﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Program
    {
        static int n = 5; // Number of processes
        static int m = 4; // Number of resources
        int[,] need = new int[n, m];
        int[,] max;
        int[,] alloc;
        int[] avail;
        int[] safeSequence = new int[n];

        void initializeValues()
        {
            // P0, P1, P2, P3, P4 are the Process
            // names here Allocation Matrix
            alloc = new int[,] {
                        { 0, 1, 1, 0 }, //P0
						{1,2,3,1 }, //P1
						{1,3,6,5 }, //P2
						{0,6,3,2 }, //P3
						{0,0,1,4 }};//P4

            // MAX Matrix
            max = new int[,] {
                    { 0,2,1,0 }, //P0
					{1,6,5,2 }, //P1
					{2,3,6,6 }, //P2
					{0,6,5,2 }, //P3
					{0,6,5,6 }};//P4

            // Available Resources
            avail = new int[] { 1, 5, 2, 0 };
        }

        void isSafe()
        {
            int count = 0;

            // visited array to find the
            // already allocated process
            Boolean[] visited = new Boolean[n];
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
            }

            // work array to store the copy of
            // available resources
            int[] work = new int[m];
            for (int i = 0; i < m; i++)
            {
                work[i] = avail[i];
            }

            while (count < n)
            {
                Boolean flag = false;
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == false)
                    {
                        int j;
                        for (j = 0; j < m; j++)
                        {
                            if (need[i, j] > work[j])
                                break;
                        }
                        if (j == m)
                        {
                            safeSequence[count++] = i;
                            visited[i] = true;
                            flag = true;
                            for (j = 0; j < m; j++)
                            {
                                work[j] = work[j] + alloc[i, j];
                            }
                        }
                    }
                }
                if (flag == false)
                {
                    break;
                }
            }
            if (count < n)
            {
                Console.WriteLine("The System is UnSafe!");
            }
            else
            {
                Console.WriteLine("Following is the SAFE Sequence");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("P" + safeSequence[i]);
                    if (i != n - 1)
                        Console.Write(" -> ");
                }
                Console.WriteLine("");
            }
        }

        void calculateNeed()
        {
            Console.WriteLine("NEED Matrix");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    need[i, j] = max[i, j] - alloc[i, j];
                    Console.Write(need[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        [STAThread]
        public static void Main(String[] args)
        {
            Program s = new Program();
            s.initializeValues();
            //Calculate the Need Matrix
            s.calculateNeed();
            // Check whether system is in safe state or not
            s.isSafe();

            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
