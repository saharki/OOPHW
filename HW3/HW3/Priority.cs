using System;

namespace HW3
{
    internal class Priority<Type> : SortedArr<Type>
    {


        public Priority(Func<object, object, bool> isGreater, Func<object, object, bool> isEqual) : base(isGreater,isEqual) // runs the father constructor
        {

       
        }

        public Type removeMax() //remove the max 
        { 

            object temp = Geti(indexer - 1);

           base.delete((Type) temp);
            return (Type)temp;
        }
    }
}