using System;

namespace HW3
{
    class SortedArr<Type>
    {
        private Func<object, object, bool> isEqual;
        private Func<object, object, bool> isGreater;
        private object[] arr;
        protected int indexer=0;
        public SortedArr(Func<object, object, bool> isGreater, Func<object, object, bool> isEqual)
        {
            this.isGreater = isGreater;
            this.isEqual = isEqual;
        }

        public void add(Type v)
        {
 
            indexer++;
            object []tmp= new object[indexer];
           

            //object tmp = null, tmp2 = null;

            if (indexer == 1)
            {
                tmp[0] = v;
                arr = tmp;
                return;
            }
            bool placed = false;
            int i = 0;
            while (!placed)
            {
               
                if (i<indexer-1 && isGreater((object)v,arr[i]))
                {
                    tmp[i] = arr[i];
                }
                else
                {
                    tmp[i] = v;
                    placed = true;
                }
                i++;
            }
            while (i < indexer)
            {
                tmp[i] = arr[i - 1];
                i++;
            }
        
            arr = tmp;
            
           
        }

        public bool delete(Type v)
        {
            if (indexer <=0)
            {
                return false;
            }
            int found=0;
            for (int i=0 ;i<indexer;i++)
            {
                if (isEqual(arr[i],(object) v)&&(found==0))
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
            object[] tmp = new object[indexer];
            for (int i = 0; i < indexer; i++)
                tmp[i] = arr[i];
            arr = tmp;
            return true;  
          
        }

        public Type Geti(int i)
        {
            return (Type)arr[i];
        }

        public int N { get { return indexer; } }
    }
}