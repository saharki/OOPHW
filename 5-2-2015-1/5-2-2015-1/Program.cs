using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_2015_1
{
    class Class1
    {
        public static bool doubleIsGreater(object x, object y)
        {
            double u, v;

            u = (double)x;
            v = (double)y;

            return (u > v);
        }// doubleIsGreater 

        public static bool doubleIsEqual(object x, object y)
        {
            double u, v;

            u = (double)x;
            v = (double)y;

            return (u == v);
        }// doubleIsEqual 

        public static bool intIsGreater(object x, object y)
        {
            int u, v;

            u = (int)x;
            v = (int)y;

            return (u > v);
        }// doubleIsGreater 

        public static bool intIsEqual(object x, object y)
        {
            int u, v;

            u = (int)x;
            v = (int)y;

            return (u == v);
        }// intIsEqual 

        static void Main(string[] args)
        {
            int i;
            SortedArr<double> srt1 = new
               SortedArr<double>(doubleIsGreater, doubleIsEqual);

            srt1.add(22.2);
            srt1.add(66.6);
            srt1.add(22.2);
            srt1.add(33.3);
            srt1.add(55.5);
            srt1.add(77.7);
            srt1.add(11.1);
            srt1.add(44.4);
            srt1.delete(55.5);

            Console.WriteLine("\nsrt1:");
            for (i = 0; i < srt1.N; i++)
                Console.WriteLine(srt1.Geti(i));

            Priority<int> pri1 = new Priority<int>(intIsGreater, intIsEqual);
            pri1.add(11);
            pri1.add(33);
            pri1.add(77);
            pri1.add(44);
            pri1.add(55);
            pri1.add(66);
            pri1.add(22);

            Console.WriteLine("\npri1:");
            while (pri1.N > 0)
                Console.WriteLine(pri1.removeMax());
                

        } // Main
    } // Class1

}
