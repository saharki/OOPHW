using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_10_2009_1_sahar
{
    public class Conforming_arr
    {
        static void Main(string[] args)
        {
            ConformingArray arr1, arr2, arr3;
            int i;

            arr1 = new ConformingArray();
            arr2 = new ConformingArray();

            for(i=2;i<33;i+=4)
            {
                arr1[i] = i * 1.01;
            }
            for (i = 3; i < 28; i += 3)
                arr2[i] = i * 1.001;
            arr3 = arr1 + arr2;

            Console.WriteLine("arr1.MinIndex = " + arr1.MinIndex);
            Console.WriteLine("arr1.MaxIndex = " + arr1.MaxIndex);
            Console.WriteLine("arr2.MinIndex = " + arr2.MinIndex);
            Console.WriteLine("arr2.MaxIndex = " + arr2.MaxIndex);
            Console.WriteLine("arr3.MinIndex = " + arr3.MinIndex);
            Console.WriteLine("arr3.MaxIndex = " + arr3.MaxIndex);

            Console.WriteLine(" arr1:");
            for (i = arr1.MinIndex; i < arr1.MaxIndex; i++)
                Console.Write(" " + arr1[i]);
            Console.WriteLine();
            Console.Write(" arr2:");

            for (i = arr2.MinIndex; i < arr2.MaxIndex; i++)
                Console.Write(" " + arr2[i]);
            Console.WriteLine();

            Console.WriteLine(" arr3:");
            for (i = arr3.MinIndex; i < arr3.MaxIndex; i++)
                Console.Write(" " + arr3[i]);
            Console.WriteLine();

        }
    }
}
