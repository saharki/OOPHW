using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_10_2008_1_sahar
{
    class SubstituteCipher :Cipher
    {
        CharEncryption[] arr;
        int n;
        SubstituteCipher(CharEncryption[] arr,int n) :base(en,de)
        {
            this.n = n;
            this.arr = new CharEncryption[n];
            for (int i = 0; i < n; i++)
            {
                this.arr[i] = new CharEncryption(arr[i].source, arr[i].destination);
            }
        }
         static String en(String str)
        {
            return str;
        }
        static String de(String str)
        {
            return str;
        }
    }
}
