using findtext;

namespace findtext_test
{
    public class Tests
    {
        [TestCase("������", "wordAtBeginning.txt", new int[] { 1 })]
        [TestCase("������", "wordAtEnd.txt", new int[] { 1 })]
        [TestCase("������", "wordAtMiddle.txt", new int[] { 1 })]
        [TestCase("������ ���", "severalWords.txt", new int[] { 2 })]
        [TestCase("������ ���", "wordsInSeveralLine.txt", new int[] {1, 2, 6, 7})]
        [TestCase("", "nullFindWord.txt", new int[] { })]
        [TestCase("������", "nullFile.txt", new int[] { })]
        [TestCase("������", "fileNotExist.txt", new int[] { })]
        [TestCase("�", "heavyFile.txt", new int[] { })]
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