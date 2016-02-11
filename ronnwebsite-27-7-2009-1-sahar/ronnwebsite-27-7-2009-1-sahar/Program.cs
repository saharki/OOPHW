using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ronnwebsite_27_7_2009_1_sahar
{
    class Class1
    {

        public static void Main(string[] args)
        {
            Picture x1 = new Picture("97512345.671964519"),
               x2 = new Picture("00000965.639321266");

            Picture x3 = x1 + x2;

            Console.WriteLine(x1.Picture2string() +
                       " + " + x2.Picture2string() + " = "
                                + x3.Picture2string());

            x1 = "07659.79354328778";
            x2 = "44321.59998766543";

            x3 = x1 + x2;

            Console.WriteLine(x1.Picture2string() +
                    " + " + x2.Picture2string() + " = "
                              + x3.Picture2string());

        } // Main

    }// Class1

}
