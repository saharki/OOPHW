using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_2010_1_sahar
{
    class Program
    {
        static void Main(string[] args)
        {
            dual_nature x, y, z;
            int i, j, k;
            String str1, str2;
            str1 = "12345";
            x = 543210;
            y = str1;
            z = x + y;
            Console.WriteLine("x={0},y={1},z={2}",x.StringValue,y.StringValue,z.StringValue);
            Console.WriteLine("x.Substring(2,3) = " + x.Substring(2, 3));
            dual_nature u = new dual_nature("1234");
            str2 = Convert.ToString("12abc5");
            dual_nature v = new dual_nature(str2);

            try
            {
                z = u + v;
            }
            catch(InvalidDualValueExcepetion e)
            {
                Console.WriteLine("Exception" + e.Message);

            }
            i = u;
            j = x.IntValue;
            k = i + j;
            Console.WriteLine("i={0},j={1},k={2}", i, j, k);
        }
    }
}
