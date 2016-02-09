using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_7_2014_1_sahar
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;
            n = 10;
            /***************************************************************
            **** Doesn't work, problem with ron's algorithm of "add" func ****
            ****************************************************************/
            ditree mytree = new ditree();
            for (i = 1; i <= n; i++)
                mytree.add(1.1 * i);
            Console.WriteLine("inorder_print:");

            mytree.inorder_print();


        } // Main
    }
}
