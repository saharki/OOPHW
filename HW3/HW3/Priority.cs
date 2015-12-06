using System;

namespace HW3
{
    internal class Priority<Type> : SortedArr<Type>
    {


        public Priority(Func<object, object, bool> isGreater, Func<object, object, bool> isEqual) : base(isGreater,isEqual)
        {

       
        }

        public Type removeMax()
        { 
          //  if (indexer <=0)
          //    return (Type)null;
            object temp = Geti(indexer - 1);

           base.delete((Type) temp);
            return (Type)temp;
        }
    }
}