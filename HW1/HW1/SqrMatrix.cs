using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class SqrMatrix
    {
        private double [,] matrix ;
        private int n;
        public int N
           {
                get
                 {
                    return n;
                }

            }


        public double this[int i,int j]
    {
        get
        {
            return matrix[i,j];
        }
        set
        {
            matrix[i,j] = value;
        }
    }

        public SqrMatrix (int n)
        {
            matrix = new double[n,n];
            for(int i=0;i<n;i++)
                for(int j=0;j<n;j++)
                    matrix[i,j]=0.0;

            this.n=n;
        }



        static public SqrMatrix inv(SqrMatrix source)
        {
               SqrMatrix A = new SqrMatrix(source.N-1);
               SqrMatrix B = new SqrMatrix(source.N-1);
               SqrMatrix A = new SqrMatrix(source.N-1);
               SqrMatrix A = new SqrMatrix(source.N-1);

               invA = inv(A);
               invDCAB = inv(D-C*invA*B);   

               iA = invA + invA*B*invDCAB*C*invA;
               iB = -invA*B*invDCAB;
               iC = -invDCAB*C*invA;
               iD = invDCAB
        }


        public static SqrMatrix operator+(SqrMatrix left, SqrMatrix right)
        {

            if (left.N != right.N)
                return null;

            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = left[i, j] + right[i, j];

            return c;
        }

        public static SqrMatrix operator -(SqrMatrix left, SqrMatrix right)
        {

            if (left.N != right.N)
                return null;

            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = left[i, j] - right[i, j];

            return c;
        }

        public static SqrMatrix operator -(SqrMatrix left)
        {
            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = -left[i, j] ;

            return c;
        }

        public static SqrMatrix operator *(SqrMatrix left, SqrMatrix right)
        {

            if (left.N != right.N)
                return null;

            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
            {
                for (int j = 0; j < left.N; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < left.N; k++) 
                        c[i, j] = c[i, j] + left[i, k] * right[k, j];
                }
            }
            return c;
        }

        public void print()
        {
            for (int i = 0; i < this.N; i++)
            {
                for (j = 0; j < this.N; j++)
                    Console.Write(this[i, j]+" ");
                Console.WriteLine("");
            }
        }
    }
}
