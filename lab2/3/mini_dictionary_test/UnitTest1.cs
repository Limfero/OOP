using mini_dictionary;

namespace mini_dictionary_test
{
    public class Tests
    {
        [TestCase("home", "[house, home] ���, �����")]
        [TestCase("�����", "[house, home] ���, �����")]
        [TestCase("", "")]
        public void FindInDictionaryTest(string searchString, string correctResult)
        {
            Dictionary<List<string>, List<string>> dictionary = new() { { new() { "house", "home"}, new() { "���", "�����" } } };

            KeyValuePair<List<string>, List<string>> actualResultInPaar = Program.FindInDictionary(dictionary, searchString);

            string actualResult = string.Empty;

            if (!(actualResultInPaar.Key == null))
                actualResult = string.Format("[{0}] {1}", string.Join(", ", actualResultInPaar.Key), string.Join(", ", actualResultInPaar.Value));

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [TestCase("home", "���, �����")]
        [TestCase("�����", "house, home")]
        [TestCase("", "")]
        public void TranslatorTest(string translationString, string correctResult)
        {
            Dictionary<List<string>, List<string>> dictionary = new() { { new() { "house", "home" }, new() { "���", "�����" } } };

            string actualResult = Program.Translate(dictionary, translationString);

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [TestCase("empty.txt", new string[] {})]
        [TestCase("dictionary.txt", new[] { "[house, home] ���, �����", "[cat] �����, ���" })]
        public void InitializeDictionaryFromFileTest(string pathToFile, string[] correctResult)
        {
            Dictionary<List<string>, List<string>> dictionary = Program.InitializeDictionaryFromFile(pathToFile);

            List<string> actualResult = new();

            foreach (var item in dictionary)
                actualResult.Add(string.Format("[{0}] {1}", string.Join(", ", item.Key), string.Join(", ", item.Value)));

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [TestCase("home", "���, �������", new[] { "[house, home] ���, �����, �������" })]
        [TestCase("�������", "house, home", new[] { "[house, home] ���, �����, �������" })]
        [TestCase("cat", "���, �����", new[] { "[house] ���, �����", "[cat] ���, �����" })]
        [TestCase("������", "cat, cats", new[] { "[house] ���, �����", "[cat, cats] ������" })]
        [TestCase("", "", new[] { "[house] ���, �����" })]
        public void SaveEntryInDictionaryTest(string newKey, string newValue, string[] correctResult)
        {
            Dictionary<List<string>, List<string>> dictionary = new() { { new() { "house" }, new() { "���", "�����" } } };

            List<string> actualResult = new();

            if (newKey != "")
            {
                if (newKey[0] >= 'a' && 'z' <= newKey[0])
                    Program.SaveEntryInDictionary(dictionary, newValue, newKey);
                else
                    Program.SaveEntryInDictionary(dictionary, newKey, newValue);
            }

            foreach (var item in dictionary)
                actualResult.Add(string.Format("[{0}] {1}", string.Join(", ", item.Key), string.Join(", ", item.Value)));


            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [TestCase("test.txt", new[] { "[house] ���, �����",  "[cat] �����, ���" })]
        public void SaveDictionaryInFileTest(string pathToFile, string[] correctResult)
        {
            Dictionary<List<string>, List<string>> dictionary = new() { { new() { "house" }, new() { "���", "�����" } },
                                                                        { new() { "cat" }, new() { "�����, ���" } } 
                                                                      };

            Program.SaveDictionaryInFile(dictionary, pathToFile);

            string[] actualResult = File.ReadAllLines(pathToFile);

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }
    }
}
