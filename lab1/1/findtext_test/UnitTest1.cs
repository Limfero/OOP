using findtext;

namespace findtext_test
{
    public class Tests
    {
        [TestCase("привет", "wordAtBeginning.txt", new int[] { 1 })]
        [TestCase("привет", "wordAtEnd.txt", new int[] { 1 })]
        [TestCase("привет", "wordAtMiddle.txt", new int[] { 1 })]
        [TestCase("привет мир", "severalWords.txt", new int[] { 2 })]
        [TestCase("привет мир", "wordsInSeveralLine.txt", new int[] {1, 2, 6, 7})]
        [TestCase("", "nullFindWord.txt", new int[] { })]
        [TestCase("привет", "nullFile.txt", new int[] { })]
        [TestCase("привет", "fileNotExist.txt", new int[] { })]
        [TestCase("и", "heavyFile.txt", new int[] { })]
        public void FindWordInString(string stringToSearch, string pathToFile, int[] inputResult)
        {
            List<int> correctResult = new();

            if (inputResult != null) correctResult = inputResult.ToList();
            if (File.Exists(pathToFile.Replace(".txt", "Output.txt")))
                correctResult = File.ReadAllLines(pathToFile.Replace(".txt", "Output.txt")).Select(line => int.Parse(line)).ToList();

            List<int> listLineNumbers = Program.GetIndexList(stringToSearch, pathToFile);
          
            Assert.That(correctResult, Is.EqualTo(listLineNumbers));
        }


    }
}