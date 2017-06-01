using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        private int theRows;
        private int theCols;
        private int[,] aMatrix;
        Random random = new Random();

        public Matrix() {}

        public Matrix(int rows, int cols)
        {
            NewMatrix = new int[rows,cols];
            Rows = rows;
            Cols = cols;
            
        }

        // Destructor
        ~Matrix() 
        {
            GC.Collect();
            Console.WriteLine("Finished!");
        }

        public int Sum { get; set; }
        //Default properties possible here
        public int Rows 
        { 
            get
            {
                return theRows;
            }
            set
            {
                theRows = value;
            }
        
        }

        public int Cols
        {
            get
            {
                return theCols;
            }
            set
            {
                theCols = value;
            }

        }

        public int[,] NewMatrix
        {
            get {
                return aMatrix; 
            }
            set {
                aMatrix = value;
            }
        }
        //Method that Fill our Matrix with random integers
        public void FillMatrix()
        {   
            for(int i = 0; i < this.Rows; i++)
            {
                for(int j = 0; j < this.Cols; j++)
                {
                    this.NewMatrix[i, j] = this.random.Next(0,10);
                }
            }
        }
        //Displays our lovely Matrix to console
        public void PrintMatrix()
        {
            for (int i = 0; i < this.NewMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.NewMatrix.GetLength(1); j++)
                {
                    Console.Write(this.NewMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //Adding two matrices
        public static Matrix operator +(Matrix m1, Matrix m2)
        { 
            //m1 since both matrices have the same rows and cols anyways
            Matrix temp = new Matrix(m1.Rows, m1.Cols);
            int result;
            for(int i = 0; i < m1.NewMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < m1.NewMatrix.GetLength(1); j++)
                {
                    result = m1.NewMatrix[i, j] + m2.NewMatrix[i, j];
                    temp.NewMatrix[i,j] = result;
                }
            }
            return temp;
        }

        
        //Multiplying two matrices
        
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix temp = new Matrix(m1.Rows, m2.Cols);
            
            for (int row = 0; row < m1.NewMatrix.GetLength(0); row++)
            {
                for(int col = 0; col < m2.NewMatrix.GetLength(1); col++)
                {
                    int sum = 0;
                    for(int acols = 0; acols < m1.NewMatrix.GetLength(1); acols++)
                    {
                        sum += m1.NewMatrix[row, acols] * m2.NewMatrix[acols, col]; 
                    }
                    temp.NewMatrix[row, col] = sum;
                }
            } 
            return temp;
        }
         
        //Transpose Matrix
        public static Matrix operator !(Matrix m)
        {
            Matrix temp = new Matrix(m.Cols,m.Rows);
            for (int i = 0; i < m.NewMatrix.GetLength(0);i++)
            {
                for (int j = 0; j < m.NewMatrix.GetLength(1);j++)
                {
                    temp.NewMatrix[j,i] = m.NewMatrix[i,j];
                }
            }
            return temp;
        }
        //Trace of a Matrix
        public static Matrix operator --(Matrix m)
        {
            Matrix temp = new Matrix(m.Rows,m.Cols);
            
            int sum = 0;
            int rowcount = 0;
            
            for (int i = 0; i  < m.NewMatrix.GetLength(0);i++)
            {
                for(int j = 0; j < m.NewMatrix.GetLength(1);j++)
                {
                    temp.NewMatrix[i, j] = m.NewMatrix[i, j];
                    if (j == rowcount)
                    {
                        sum += m.NewMatrix[i, j];
                        
                    }
                }
                rowcount++;
            }

            temp.Sum = sum;
            return temp;
        }
    }
}
