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


        public double this[int i, int j] // overload operators [,]
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

        private static bool IsPowerOfTwo(ulong x) // check if the number is power of 2
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
        private static SqrMatrix completeMatrix(SqrMatrix mat) // complete values to exp of 2
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

        private static SqrMatrix deleteComplete(SqrMatrix mat,int origN) // removing complete to exp of 2
        {
       

            SqrMatrix temp = new SqrMatrix(origN);

           

            for (int j = 0; j < origN; j++)
                for (int k = 0; k < origN; k++)
                {
                    temp[j, k] = mat[j, k];
                }

            return temp;

        }

        static public SqrMatrix inv(SqrMatrix source) // make the invertion
        {
            if (!IsPowerOfTwo((ulong)source.N)) // if the dimension is not a pow of 2
            {
                SqrMatrix result1;
               result1= inv( completeMatrix(source));
               return deleteComplete(result1,source.N);

            }

         //   source.print();

            SqrMatrix result;
            if (source.N == 1) // break condition when reaching 1
            {
                
                result = new SqrMatrix(1);
                result[0,0]=1/source[0,0];
                return result;
                
            }
               SqrMatrix A = new SqrMatrix(source.N / 2);
               SqrMatrix B = new SqrMatrix(source.N / 2);
               SqrMatrix C = new SqrMatrix(source.N / 2);
               SqrMatrix D = new SqrMatrix(source.N / 2);
               SqrMatrix iA,iB,iC,iD,invDCAB,invA;
               for (int i = 0; i < A.N; i++) // putting values back to matrixes A,B,C,D
                   for (int j = 0; j < A.N; j++)
                   {
                       A[i, j] = source[i, j];
                       B[i, j] = source[i, j + B.N];
                       C[i, j] = source[i + C.N, j];
                       D[i, j] = source[i + D.N, j + D.N];
                   }

              // according to the formula
               invA = inv(A);
               invDCAB = inv(D-C*invA*B);   

               iA = invA + invA*B*invDCAB*C*invA;
               iB = -invA*B*invDCAB;
               iC = -invDCAB*C*invA;
               iD = invDCAB;

               result = new SqrMatrix(source.N);
            for(int i=0;i<iA.N;i++)   // putting values to a bigger matrix
                for(int j =0;j<iA.N;j++)
                {
                    result[i,j]=iA[i,j];
                    result[i, j + iB.N] = iB[i, j];
                    result[i + iC.N, j] = iC[i, j];
                    result[i + iD.N, j + iD.N] = iD[i, j];
                }


            return result;
            
        }


        public static SqrMatrix operator +(SqrMatrix left, SqrMatrix right) // operator +
        {

            if (left.N != right.N)
                return null;

            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = left[i, j] + right[i, j];

            return c;
        }

        public static SqrMatrix operator -(SqrMatrix left, SqrMatrix right) // operator -
        {

            if (left.N != right.N)
                return null;

            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = left[i, j] - right[i, j];

            return c;
        }

        public static SqrMatrix operator -(SqrMatrix left) //unary operator -
        {
            SqrMatrix c = new SqrMatrix(left.N);

            for (int i = 0; i < left.N; i++)
                for (int j = 0; j < left.N; j++)
                    c[i, j] = -left[i, j] ;

            return c;
        }

        public static SqrMatrix operator *(SqrMatrix left, SqrMatrix right) //operator *
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

        public void print() //printing matrix value
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
