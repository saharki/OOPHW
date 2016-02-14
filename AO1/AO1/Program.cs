//AO1Array.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AO1
{
    abstract class AO1Array
    {
        protected object[] A;
        protected int[] B;
        protected int[] C;
        protected int top;
        public AO1Array(int n)
        {
            A = new object[n];
            B = new int[n];
            C = new int[n];
            top = 0;
        }/*end constructor*/
        public Boolean IsGarbage(int i)
        {
            if (C[B[i]] == i && ((B[i] <= top) && (B[i] >= 0)))
                return false;
            return true;
        }/*end IsGarbage*/
    }

    class DoubleO1Array : AO1Array
    {
        private double tmp;
        private int n;
        public DoubleO1Array(int n, double TMP) : base(n)
        {
            tmp = TMP;
            this.n = n;
        }/*end constructor*/

        public int Length
        {
            get
            {
                return n;
            }
        }
        public object this[int i]
        {
            get
            {
                if ((IsGarbage(i)) == true)
                    return tmp;
                return A[i];
            }/*end get*/

            set
            {
                if ((IsGarbage(i)) == false)
                    A[i] = value;
                else
                {
                    C[top] = i;
                    B[i] = top;
                    top++;
                    A[i] = value;
                }/*end else*/
            }/*end set*/
        }/*end this*/
    }

    class MainClass
    {
        public static void Main()
        {
            DoubleO1Array darr1, darr2;
            int i;
        const int n = 20;
            darr1 = new DoubleO1Array(n, 0.0);
            darr2 = new DoubleO1Array(n, 1.1);
            Console.WriteLine("\nLength.darr1 = {0}", darr1.Length);
            Console.WriteLine("\nLength.darr2 = {0}", darr2.Length);
            for (i = 0; i < n; i += 2)
            {
                darr1[i] = i * 10.0;
                darr2[i] = i * 100.0;
            } // for
            Console.WriteLine("\ndarr1 = ");
            for (i = 0; i < n; i++)
                Console.WriteLine("darr1[{0}] = {1} ", i, darr1[i]);
            Console.WriteLine("\ndarr2 = ");
            for (i = 0; i < n; i++)
                Console.WriteLine("darr2[{0}] = {1} ", i, darr2[i]);
        } // Main
    } // MainClass
}

