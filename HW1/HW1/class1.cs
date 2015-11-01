using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class class1
    {

        public static void Main()
        {

            SqrMatrix sm = new SqrMatrix(3);

            sm[0, 0] = 2.0;
            sm[0, 1] = 8.0;
            sm[1, 0] = 8.0;
            sm[1, 1] = 2.0;
            sm[2, 0] = 1.0;
            sm[2, 2] = 1.0;

            SqrMatrix invSm, tester;

            invSm = SqrMatrix.inv(sm);

            Console.WriteLine("Original Matrix");
            sm.print();
            Console.WriteLine("Inverted Matrix");
            invSm.print();

            Console.WriteLine("Test Matrix");
            tester = sm * invSm;
            tester.print();

        } // Main


    } // class1

}
