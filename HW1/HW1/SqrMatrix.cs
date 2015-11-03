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

        private static bool IsPowerOfTwo(ulong x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
        private static SqrMatrix completeMatrix(SqrMatrix mat)
        {
            int i=mat.N;
            while (!IsPowerOfTwo((ulong)(i)))
            {
                i++;
            }

            SqrMatrix temp = new SqrMatrix(i);

            for(int j=0;j<i;j++)
              temp[j,j]=1;

            for(int j=0;j<mat.N;j++)
              for(int k=0;k<mat.N;k++)
            {
                temp[j, k] = mat[j, k];
            }

            return temp;

        }

        static public SqrMatrix inv(SqrMatrix source)
        {
            if (!IsPowerOfTwo((ulong)source.N))
            {
               return inv( completeMatrix(source));
            }

            SqrMatrix result;
            if (source.N == 1)
            {
                result = new SqrMatrix(1);
                result[0,0]=source[0,0];
                return result;
            }
               SqrMatrix A = new SqrMatrix(source.N / 2);
               SqrMatrix B = new SqrMatrix(source.N / 2);
               SqrMatrix C = new SqrMatrix(source.N / 2);
               SqrMatrix D = new SqrMatrix(source.N / 2);
               SqrMatrix iA,iB,iC,iD,invDCAB,invA;
               for (int i = 0; i < A.N; i++)
                   for (int j = 0; j < A.N; j++)
                   {
                       A[i, j] = source[i, j];
                       B[i, j] = source[i, j + B.N];
                       C[i, j] = source[i + C.N, j];
                       D[i, j] = source[i + D.N, j + D.N];
                   }
               invA = inv(A);
               invDCAB = inv(D-C*invA*B);   

               iA = invA + invA*B*invDCAB*C*invA;
               iB = -invA*B*invDCAB;
               iC = -invDCAB*C*invA;
               iD = invDCAB;
               result = new SqrMatrix(source.N);
            for(int i=0;i<A.N;i++)
                for(int j =0;j<A.N;j++)
                {
                    result[i,j]=A[i,j];
                    result[i, j + B.N] = B[i, j];
                    result[i + C.N, j] = C[i, j];
                    result[i + D.N, j + D.N] = D[i, j];
                }


            return result;
            
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
                for (int j = 0; j < this.N; j++)
               
                    Console.Write(this[i, j]+" ");
                Console.WriteLine("");
            }
        }
    }
}
