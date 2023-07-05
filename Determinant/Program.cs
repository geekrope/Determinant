namespace Determinant
{
    class Program
    {
        public static double[,] Exclude(double[,] matrix, int column, int row)
        {
            var columns = matrix.GetLength(0);
            var rows = matrix.GetLength(1);
            var result = new double[columns - 1, rows - 1];

            for (int currentColumn = 0; currentColumn < columns; currentColumn++)
            {
                for (int currentRow = 0; currentRow < rows; currentRow++)
                {
                    if (currentColumn != column && currentRow != row)
                    {
                        var newColumn = currentColumn < column ? currentColumn : currentColumn - 1;
                        var newRow = currentRow < row ? currentRow : currentRow - 1;

                        result[newColumn, newRow] = matrix[currentColumn, currentRow];
                    }
                }
            }

            return result;
        }

        public static double GetDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Not a square matrix");
            }

            if (matrix.Length == 1)
            {
                return matrix[0, 0];
            }
            else
            {
                var columns = matrix.GetLength(0);
                var sign = 1;
                double result = 0;

                for (int column = 0; column < columns; column++)
                {
                    var multiplier = matrix[column, 0];
                    var excludedMatrix = Exclude(matrix, column, 0);
                    var determinant = GetDeterminant(excludedMatrix);

                    result += multiplier * determinant * sign;
                    sign = -sign;
                }

                return result;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(GetDeterminant(new double[,] { { 2, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }));
        }
    }
}