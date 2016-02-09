using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_2015_1
{
   
    class Priority<Type> : SortedArr<Type>
    {
        public Priority(func isGreater, func isEqual):base(isGreater,isEqual)
        {
        
        }
       public Type removeMax()
        {
            Type temp= Geti(N - 1);
            base.delete(temp);
            return temp;
        }
    }
}
