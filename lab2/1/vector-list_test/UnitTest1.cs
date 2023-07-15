using vector_list;

namespace vector_list_test
{
    public class Tests
    {
        [TestCase("", new double[] { })]
        [TestCase(null, new double[] { })]
        [TestCase("2.3 gfsssgd 0.5 4.5", new[] {2.3, 0.5, 4.5})]
        [TestCase("2.3 0.5 4.5", new[] { 2.3, 0.5, 4.5 })]
        public void EmptyStringInitializeListTest(string inputString, double[] correctResult)
        {

            Assert.That(Program.InitializeList(inputString), Is.EqualTo(correctResult.ToList()));
        }

        [TestCase(new double[] { }, new double[] { })]
        [TestCase(null, null)]
        [TestCase(new[] { 2.3, 0.5, 4.5 }, new[] { 9.6, 7.8, 11.8 })]
        public void AddToEachElementListSumOfThreeMinElementsTest(double[] inputArray, double[] inputResult)
        {
            List<double> actualResult = null;
            List<double> correctResult = null;

            if (inputArray != null) actualResult = inputArray.ToList();
            if (inputResult != null) correctResult = inputResult.ToList();

            Program.AddToEachElementSumOfThreeMinElements(actualResult);

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [TestCase(new double[] { }, "")]
        [TestCase(null, "")]
        [TestCase(new[] { 9.6, 7.8, 11.8 }, "7.8 9.6 11.8")]
        public void ListWriteTest(double[] inputArray, string correctResult)
        {
            List<double> actualResult = null;

            if (inputArray != null) actualResult = inputArray.ToList();

            Program.WriteList(actualResult);

            Assert.That(File.ReadAllText("output.txt"), Is.EqualTo(correctResult));
        }
    }
}