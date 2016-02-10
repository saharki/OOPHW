using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _27_7_2009_1_sahar
{
    class linear
    {

        static int finished(int[] x)
        {
            int i;
            int n;

            n = x.Length;
            for (i = 0; i < n; i++)
                if (x[i] != 1)
                    return 0;

            return 1;

        } // finished

        static int test(int[,] mat, int[] x, int[] b, int n, int m)
        {
            int i, j;
            int sum;

            for (i = 0; i < m; i++)
            {
                sum = 0;
                for (j = 0; j < n; j++)
                    sum += mat[i, j] * x[j];
                if (sum < b[i])
                    return 0;
            } // for
            return 1;
        } // test

        static void inc(int[] x, int n)
        {
            int carry, i;

            carry = 1;
            i = n - 1;
            while (carry == 1)
            {
                if (x[i] == 1)
                    x[i] = 0;
                else
                {
                    x[i] = 1;
                    carry = 0;
                } // else
                i--;
            } // while 

        }// inc
        static int []found;
        static Thread []myThread;
        static int[] x;
        static int intprog(int[,] mat, int[] b, int n, int m, int[] tx,int tnum)
        {
            int i;
            int  []myx= new int[n];
            myx[n - 1] = tnum;
            for (i = 0; i < n-1; i++)
                myx[i] = 0;
                
            found[tnum] = 0;
            do
            {
                found[tnum] =  test(mat, myx, b, n, m);
               
                if (found[tnum] == 0)
                    inc(myx, n-1);
                else
                {
                    lock(x)
                    {
                        x = myx;
                        myThread[tnum].Abort();
                    }
                }
            } while ((finished(myx) == 0) && (found[tnum] == 0));

            return found[tnum];
        } // intprog

        static int tintprog(int[,] mat, int[] b, int n, int m, int[] x)
        {
            myThread = new Thread[2];
            found = new int[2];
            found[1] = 0;
            found[0] = 0;
            myThread[1] = new Thread(() => intprog(mat, b, n, m, x,0));
            myThread[0] = new Thread(() => intprog(mat, b, n, m, x,1));
            myThread[0].Start();
            myThread[1].Start();
            myThread[0].Join();
            myThread[1].Join();
            return (found[0] | found[1]);
                
        } // tintprog

        public static void Main(string[] args)
        {
            int i, flag;
            const int n = 10, m = 8;
            int[,] mat = new int[m, n] {
                    {1, -1, 0, -1,  0, -1, 0,  -1, 0,  -1},
                    {0, -1, 1, -1,  0, -1, 0,  -1, 0,  -1},
                    {0, -1, 0, -1,  1, -1, 0,  -1, 0,  -1},
                    {0, -1, 0, -1,  0, -1, 1,  -1, 0,  -1},
                    {0, -1, 0, -1,  0, -1, 0,  -1, 1,  -1},
                    {0, -1, 1, -1,  0, -1, 0,  -1, 0,  -1},
                    {0, -1, 0, -1,  1, -1, 0,  -1, 0,  -1},
                    {0, -1, 0, -1,  0, -1, 1,  -1, 0,  -1}};



            int[] b = new int[m] { 1, 1, 1, 1, 1, 1, 1, 1 };
            x = new int[n];


            flag = tintprog(mat, b, n, m, x);

            if (flag == 1)
            {
                Console.WriteLine("Solution:\n");
                for (i = 0; i < n; i++)
                    Console.WriteLine("{0}", x[i]);
                Console.WriteLine("");
            }
            else
                Console.WriteLine("No solution");

        } // Main

    } // linear

}
