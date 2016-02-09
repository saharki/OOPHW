using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_2015_1
{
    public delegate bool func(object x, object y);
    public class SortedArr<Type>
    {
		
        private func isBigger, isEqual;

        private Type [] arr=null;
		private int size;


        public SortedArr(func isGreater, func isEqual)
        {

            arr = null;
            this.isBigger = isGreater;
            this.isEqual = isEqual;
            size = 0;

        } //SortedArr()



        public void add(Type newMember)
		{
            size++;
            Type [] tmp = new Type[size];


            if (size == 1)
            {
                tmp[0] = newMember;
                arr = tmp;
                return;
            }
            bool placed = false;
            int i = 0;
            while (!placed)
            {

                if (i < size - 1 && isBigger((object)newMember, arr[i]))
                {
                    tmp[i] = arr[i];
                }
                else
                {
                    tmp[i] = newMember;
                    placed = true;
                }
                i++;
            }
            while (i < size)
            {
                tmp[i] = arr[i - 1];
                i++;
            }

            arr = tmp;

        }
        public bool delete(Type delMember)
		{
            if (size <= 0)
            {
                return false;
            }
            int found = 0;
            for (int i = 0; i < size; i++)
            {
                if (isEqual(arr[i], (object)delMember) && (found == 0))
                {
                    found = 1;
                }
                else if (found == 1)
                {
                    arr[i - 1] = arr[i];
                }
            }

            if (found == 0)
                return false;


            size--;
            Type[] tmp = new Type[size];
            for (int i = 0; i < size; i++)
                tmp[i] = arr[i];
            arr = tmp;
            return true;
        }
		public int N
		{
			get
			{
				return size;
			}
		}
		public Type Geti(int i)
		{
			if(size!=0)
				return arr[i];
			else
				return default(Type);
		}

 
    }
}
