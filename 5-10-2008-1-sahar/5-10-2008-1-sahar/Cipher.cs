using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_10_2008_1_sahar
{
    class Cipher:Code
    {
        delegate String cip(String str);
        cip e, d;
         public Cipher(cip e,cip d)
        {
            this.e = e;
            this.d = d;
        }
        public String encryptMessage(String str)
        {
            return e(str);
        }
        public String decryptMessage(String str)
        {
            return d(str);
        }
    }
}
