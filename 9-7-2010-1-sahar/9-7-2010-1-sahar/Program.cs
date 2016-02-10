using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9_7_2010_1_sahar
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = 43;
            ulong result;
            Console.WriteLine(DateTime.Now.TimeOfDay);
            result = fibo(n);
            Console.WriteLine(DateTime.Now.TimeOfDay);
            Console.WriteLine(result);
        }
        static ulong rfibo(ulong n)
        {
            if (n <= 2)
                return 1;
            
            return (rfibo(n - 1) + rfibo(n - 2));
        }

        static ulong fibo(ulong n)
        {
            ulong value1=0,value2=0 ;
            Thread t1 = new Thread(()=> { value1 += rfibo(n - 1);  });
            Thread t2 = new Thread(() => { value2 += rfibo(n - 2); });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            return (value1 + value2);
        }
    }
}
