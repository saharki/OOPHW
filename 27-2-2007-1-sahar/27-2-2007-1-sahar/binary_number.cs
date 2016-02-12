using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_2_2007_1_sahar
{
    class binary_number
    {
        int[] arr;
        int lenght;
        int num;
        public binary_number()
        {
            arr = new int[128];
            for (int i = 0; i < 128; i++)
                arr[i] = 0;
        }
        public static implicit operator binary_number( int x)
        {
            binary_number temp = new binary_number();
            int i;
            temp.num = x;
            i = 127;
            while (x != 0)
            {
                temp.arr[i] = x % 2;
                x /= 2;
                i--;
            }
            temp.lenght = 127 - i;
            return temp;
        }
        public static implicit operator int(binary_number x)
        {
            return x.num;
        }
        public static implicit operator binary_number(double xd)
        {
            binary_number temp = new binary_number();
            int i,x;
            x = (int)xd;
            temp.num = x;
            i = 127;
            while (x != 0)
            {
                temp.arr[i] = x % 2;
                x /= 2;
                i--;
            }
            temp.lenght = 127 - i;
            return temp;
        }

        public static binary_number operator +(binary_number b1, binary_number b2)
        {
            binary_number temp = new binary_number();
            int i, x;
            x = b1.num + b2.num;
            temp.num = x;
            i = 127;
            while (x != 0)
            {
                temp.arr[i] = x % 2;
                x /= 2;
                i--;
            }
            temp.lenght = 127 - i;
            return temp;
        }

        public void print()
        {
            for (int i = lenght-1; i >= 0; i--)
                Console.Write(arr[127 - i]);
            
        }
    }
}
