namespace SetMatrixZeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = [[1, 1, 1], [1, 0, 1], [1, 1, 1]];
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void bruteApproach(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[][] matrixCopy = new int[m][];

            for (int i = 0; i < m; i++)
            {
                matrixCopy[i] = new int[n];
                Array.Copy(matrix[i], matrixCopy[i], n);
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrixCopy[i][j] == 0)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            matrix[k][j] = 0;
                        }
                        for (int l = 0; l < n; l++)
                        {
                            matrix[i][l] = 0;
                        }
                    }
                }
            }
        }

        static void betterApproach(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool[] rows = new bool[m];
            bool[] cols = new bool[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows[i] = true;
                        cols[j] = true;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rows[i] || cols[j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        static void OptimalApproach(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            bool firstRowZero = false;
            bool firstColZero = false;

            //Check if first row or first column should be zero
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    firstColZero = true;
                    break;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }

            //use first row and column as markers for zeroing other rows and columns
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            //Zero rows based markers in the first column
            for (int i = 1; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < n; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // Zero columns based on markers in the first row
            for (int j = 1; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < m; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // Zero the first row and first column if needed
            if (firstRowZero)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (firstColZero)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }

        }
    }
}
