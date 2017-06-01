//Matrix operator overloading
//Author: Daniel Lee

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Tester
    {
        private static Matrix M1;
        private static Matrix M2;
        private static Matrix M3;

        static void Main(string[] args)
        {
            createMatrices();

            while(true)
            {
                Console.WriteLine(@"
Enter 0 to exit the program
Enter 1 if you want to add the matrices
Enter 2 if you want to multiply the matrices
Enter 3 if you want to transpose the first matrix
Enter 4 if you want to get the trace of the first matrix
Enter 5 if you want to display the two matrices
Enter 6 to generate new matrices:");
                int choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                } catch(FormatException fe)
                {
                    Console.WriteLine("Error: " + fe);
                    continue;
                }
                switch(choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        System.Environment.Exit(1);
                        break;
                    case 1:
                        Console.WriteLine("Added Matrix:");
                        if ((M1.Rows != M2.Rows) && (M1.Cols != M2.Cols))
                        {
                            Console.WriteLine("Rows and columns of first and second matrix must be equal");
                            break;
                        }
                        M3 = M1 + M2;
                        M3.PrintMatrix();
                        
                        break;
                    case 2:
                        
                        Console.WriteLine("Multiplied Matrix:");
                        if(M1.Cols != M2.Rows)
                        {
                            Console.WriteLine("Number of columns in first Matrix must be equal to rows in the 2nd");
                            break;
                        }
                        M3 = M1 * M2;
                        M3.PrintMatrix();
                       
                        break;
                    case 3:
                        Console.WriteLine("Transposed Matrix:");
                        M3 = !M1;
                        M3.PrintMatrix();
                        break;
                    case 4:
                        Console.WriteLine("Trace of a Matrix:");
                        if(M1.Rows != M1.Cols)
                        {
                            Console.WriteLine("It must be a n by n matrix");
                            break;
                        }
                        M3 = --M1;
                        Console.WriteLine(M3.Sum);
                        break;
                    case 5:
                        Console.WriteLine("Matrix 1: ");
                        M1.PrintMatrix();
                        Console.WriteLine("Matrix 2: ");
                        M2.PrintMatrix();
                        break;
                    case 6:
                        createMatrices();
                        break;
                    default:
                        continue;
                }
            }
        }

        public static void createMatrices()
        {
            int row1 = 0;
            int col1 = 0;
            int row2 = 0;
            int col2 = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter number of rows for matrix 1: ");
                    row1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter number of cols for matrix 1: ");
                    col1 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter number of rows for matrix 2: ");
                    row2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter number of cols for matrix 2: ");
                    col2 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Error: " + fe);
                    continue;
                }
            }

            //I created two Matrix instances
            M1 = new Matrix(row1, col1);
            //I filled the matrix with random values up to 10 using my method
            M1.FillMatrix();

            M2 = new Matrix(row2, col2);
            M2.FillMatrix();

            M3 = new Matrix();

            Console.WriteLine("Matrix 1: ");
            M1.PrintMatrix();
            Console.WriteLine("Matrix 2: ");
            M2.PrintMatrix();
        }
    }
}
