using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class SqrMatrix
    {

        public SqrMatrix (int n)
        {

        }

        static public SqrMatrix inv(SqrMatrix)
        {
               invA = inv(A);
               invDCAB = inv(D-C*invA*B);   

               iA = invA + invA*B*invDCAB*C*invA;
               iB = -invA*B*invDCAB;
               iC = -invDCAB*C*invA;
               iD = invDCAB
        }

        public void print()
        {

        }
    }
}
