using System.Globalization;

namespace multmatrix
{
    public class Program
    {
        private static readonly string WrongInputFormatError = "Wrong input format! Format: <matrix file1> <matrix file2>";
        private static readonly string FileNotExistsError = "No access to files!";

        static int Main(string[] args)
        {
            if (IsNotCorrectInput(args)) return 1;

            double[,] firstMatrix = InitializationMatrixFromFile(args[0]);
            double[,] secondMatrix = InitializationMatrixFromFile(args[1]);

            double[,] resultMatrix = MultiplicationMatrix(firstMatrix, secondMatrix);

            WriteMatrix(resultMatrix);
            return 0;
        }

        public static double[,] MultiplicationMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] resultMatrix = new double[3, 3];

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                    for (int k = 0; k < secondMatrix.GetLength(0); k++)
                        resultMatrix[i, j] += Math.Round(firstMatrix[i, k] * secondMatrix[k, j], 3);

            return resultMatrix;
        }

        public static double[,] InitializationMatrixFromFile(string pathToFile)
        {
            double[,] matrix = new double[3, 3];

            string[] lineFromFile = File.ReadAllLines(pathToFile);

            for (int i = 0; i < lineFromFile.Length; i++)
            {
                string[] valuesInLine = lineFromFile[i].Split("\t");

                for (int j = 0; j < valuesInLine.Length; j++)
                    matrix[i, j] = double.Parse(valuesInLine[j], CultureInfo.InvariantCulture);
            }

            return matrix;
        }

        public static void WriteMatrix(double[,] matrix)
        {
            string result = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j != 0) result += "\t";
                    Console.Write("{0,-12:0.###}", matrix[i, j]);
                    result += string.Format("{0,-12:0.###}", matrix[i, j]);
                }

                Console.WriteLine();

                if(i != matrix.GetLength(0) - 1) result += "\r\n";
            }

            File.WriteAllText("output.txt", result.Replace(",", "."));
        }

        public static bool IsNotCorrectInput(string[] input)
        {
            if(input.Length < 2 || input.Length > 2)
            {
                Console.WriteLine(WrongInputFormatError);
                return true;
            }

            if (!File.Exists(input[0]) || !File.Exists(input[1]))
            {
                Console.WriteLine(FileNotExistsError);
                return true;
            }

            return false;
        }
    }
}