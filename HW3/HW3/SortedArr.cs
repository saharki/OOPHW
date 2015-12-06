using System;

namespace HW3
{
    class SortedArr<T>
    {
        private Func<object, object, bool> isEqual;
        private Func<object, object, bool> isGreater;
        private Type[] arr;
        private int indexer=0;
       private const int arrSize = 8;
        public SortedArr(Func<object, object, bool> isGreater, Func<object, object, bool> isEqual)
        {
            this.isGreater = isGreater;
            this.isEqual = isEqual;
            arr = new Type[arrSize];
        }

        public void add(Type v)
        {
            if (indexer >= 8)
            {
                return;
            }
            int foundplace = 0;
            Type tmp = null,tmp2=null;
            for (int i = 0; i < indexer; i++)
            {
                if (isGreater(arr[i],v ) && (tmp==null))
                {
                    tmp = arr[i];
                    arr[i] = v;
                }
                else if (tmp!=null)
                {
                    tmp2 = tmp;
                    tmp = arr[i];
                    arr[i] = tmp2;

                }
            }

            indexer++;
           
        }

        public bool delete(Type v)
        {
            if (indexer ==0)
            {
                return false;
            }
            int found=0;
            for (int i=0 ;i<indexer;i++)
            {
                if (isEqual(arr[i],v)&&(found==0))
                {
                    found = 1;
                }
                else if (found==1)
                {
                    arr[i-1] = arr[i];
                }
            }

            if (found == 0)
                return false;
      

            indexer--;
            return true;  
          
        }

        public Type Geti(int i)
        {
            return arr[i];
        }

        public int N { get { return arrSize; } }
    }
}