using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_10_2014_1_sahar
{
    class Program
    {
        public static void Main(string[] args)
        {
            Rational r1, r2, r3;

            r1 = (Rational)250;
            r2 = (Rational)(-43.642);

            r3 = r1 + r2;

            Console.WriteLine("(" + r1.Sign * r1.Num + " / " + r1.Denom + ") + (" +
                 r2.Sign * r2.Num + " / " + r2.Denom + ") = (" +
                          r3.Sign * r2.Num + " / " + r2.Denom + ")");

            r3 = r1 * r2;

            Console.WriteLine(r1.show() + " * " + r2.show() + " = " +
                          r3.show());

            r1 = (Rational)543.32;

            r3 = r1 - r2;

            Console.WriteLine(r1.show() + " - " + r2.show() + " = " +
                          r3.show());

            r1 = (Rational)34.13;
            r2 = (Rational)(-536.75);
            r3 = r1 + r2;
            Console.WriteLine(r1.show() + " + " + r2.show() + " = " +
                          r3.show());

            if (r1 > r2)
                Console.WriteLine(r1.show() + " > " + r2.show());


        } // Main

    }
}
