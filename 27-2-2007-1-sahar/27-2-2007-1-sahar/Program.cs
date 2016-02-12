using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_2_2007_1_sahar
{
    class Program
    {
        public static int Main()
        {
            int x, y;
            binary_number bn1 = new binary_number();
            binary_number bn2 = new binary_number();
            binary_number bn3 = new binary_number();

            double d = 52.8;

            x = 765;

            bn1 = x;
            bn2 = (binary_number)d;

            Console.WriteLine("bn1 = ");
            bn1.print();
            y = bn1;
            Console.WriteLine("\n value bn1 = {0} ", y);

            Console.WriteLine("\nbn2 = ");
            bn2.print();
            y = bn2;
            Console.WriteLine("\n value bn2 = {0} ", y);

            bn3 = bn1 + bn2;
            Console.WriteLine("\nbn3 = ");
            bn3.print();
            y = bn3;
            Console.WriteLine("\nvalue bn3 = {0} ", y);

            return 0;
        } // main
    } // MainClass

}

