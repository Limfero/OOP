using multmatrix;

namespace multmatrix_test
{
    public class Tests
    {

        [TestCase("1.txt")]
        [TestCase("2.txt")]
        public void InitializationMatrixFromFileTest(string pathToFile)
        {
            double[,] resultMatrix = Program.InitializationMatrixFromFile(pathToFile);

            Program.WriteMatrix(resultMatrix);

            Assert.That(File.ReadAllText(pathToFile), Is.EqualTo(File.ReadAllText("output.txt")));
        }

        [TestCase("1.txt", "2.txt")]
        public void MultiplicationMatrixTest(string pathToFirstFile, string pathToSecondFile)
        {
            double[,] firstMatrix = Program.InitializationMatrixFromFile(pathToFirstFile);
            double[,] secondMatrix = Program.InitializationMatrixFromFile(pathToSecondFile);

            string correctResult = File.ReadAllText(pathToFirstFile.Split(".")[0] + pathToSecondFile.Split(".")[0] + ".txt");

            Program.WriteMatrix(Program.MultiplicationMatrix(firstMatrix, secondMatrix));
            string result = File.ReadAllText("output.txt");

            Assert.AreEqual(result, correctResult);
        }
    }
}