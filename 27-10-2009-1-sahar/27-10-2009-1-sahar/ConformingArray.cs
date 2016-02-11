using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_10_2009_1_sahar
{
    class ConformingArray
    {
        private double [] arr;
		int highest=100;
		int min,max;
        public ConformingArray()
        {
			arr = new double[100];
			for(int i=0;i<100;i++)
			{
				arr[i]=0;
			}
			highest=100;
			min=-1;
			max=-1;
        }
		
		private void extend()
		{
			highest+=100;
			double [] temp = new double [highest];
			for(int i=0;i<highest;i++)
			{
				temp[i]=0;
			}
			for(int i=0;i<highest-100;i++)
			{
				temp[i]=arr[i];
			}
			
			arr=temp;			
		}
		
		public double this[int i]
		{
			get
			{
				while(i>=highest)
					extend();
				
				return arr[i];
			}
			set
			{
				while(i>=highest)
					extend();
				arr[i]=value;
                if (value != 0)
                {
                    if (i < min || min == -1)
                        min = i;
                    if (i > max)
                        max = i;
                }
			}
			
		}
		
		public int MinIndex
		{
			get
			{
				return min;
			}
		}
		public int MaxIndex
		{
			get
			{
				return max;
			}
		}
		
		public static ConformingArray operator +(ConformingArray A, ConformingArray B)
		{
			ConformingArray C = new ConformingArray();
            int max;
            if (A.MaxIndex > B.MaxIndex)
            {
                max = A.MaxIndex;
            }
            else
                max = B.MaxIndex;

			for(int i=0;i<=max;i++)
			{
				C[i]=A[i]+B[i];
			}
			
			return C;
		}

    }
}
