using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace compute_factors
{
    class Program
    {
        static int count = 0;
        static ulong n;
        static void tcompute_factors(ulong n, ulong[] q,ulong init)
        {
            ulong i = init;
            
            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    lock (q)
                    {
                        n /= i;
                   
                        q[count] = i;
                        count++;
                    }
                   
                }
                else
                    i+=4;
            }
            if (n % i == 0)
            {
                lock (q)
                {
                    q[count] = i;
                    count++;
                }
            }
          
        }


            static int compute_factors(ulong n, ulong[] q)
        {
            ulong i = 2,on=n;
            int count = 0;
            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    n /= i;
                    q[count] = i;
                    count++;
                }
                else
                    i++;
            }
            if (n % i == 0)
            {
                q[count] = i;
                count++;
            }
            return count;
        }
        
       /* static void Main(string[] args)
        {
        ulong n;
        int m, i;
        ulong [] arr = new ulong[100];
        n = 72;
        if ((m = compute_factors(n, arr)) == 0)
        Console.WriteLine("{0} is a prime.\n", n);
        else
        {
        Console.WriteLine("{0} is not a prime, it factors:\n", n);
        for(i=0; i < m; i++)
        Console.WriteLine("{0}\n", arr[i]);
        }
        }*/
    

    static void Main(string[] args)
    {
        
        ulong i = 2;
        ulong[] arr = new ulong[100];
        n = 72;
        int j = 0;


            Thread t1 = new Thread(()=>tcompute_factors(n,arr,3));
            Thread t2 = new Thread(() =>  tcompute_factors(n, arr, 5));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            if (count == 0)
                Console.WriteLine("{0} is a prime.\n", n);
            else
            {
                Console.WriteLine("{0} is not a prime, it factors:\n", n);
                for (int k = 0; k < count; k++)
                    Console.WriteLine("{0}\n", arr[k]);
            }
        }
    }

    

 }
