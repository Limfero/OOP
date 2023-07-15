using static mini_dictionary.ChangeColorCMD;

namespace mini_dictionary
{
    public class Program
    {
        private static readonly string PathToDictionary = "dictionary.txt";
        private static readonly string WrongInputError = "Неверная строка для перевода! Повторите ввод!";
        private static readonly string DictionaryHasChanged = "В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.";
        private static readonly string SaveChange = "Изменения сохранены.";
        private static readonly string NotSaveChange = "Изменения не сохранены.";
        private static readonly string Goodbye = "До свидания!";
        private static readonly string UnknownWord = "Неизвестное слово {0}. Введите перевод или пустую строку для отказа.";
        private static readonly string WordIgnored = "Слово проигнорированно.";
        private static readonly string WordSaved = "Слово {0} сохранено в словаре как {1}.";

        static void Main(string[] args)
        {
            Dictionary<List<string>, List<string>> miniDictionary = InitializeDictionaryFromFile(PathToDictionary);

            int countEntriesInOriginalDictionary = miniDictionary.Count;

            while (true)
            {
                string translationString = Console.ReadLine().Trim();

                switch (translationString)
                {
                    case "...":
                        ProgramExit(miniDictionary, countEntriesInOriginalDictionary);
                        Environment.Exit(0);
                        break;
                    case "":
                        WriteLine(WrongInputError, ConsoleColor.Red);
                        continue;
                    default:
                        break;
                }

                string translatedString = Translate(miniDictionary, translationString.ToLower());

                if (translatedString == "")
                    RecordUnknownWordInDictionary(miniDictionary, translationString);
                else
                    WriteLine(translatedString, ConsoleColor.Green);
            }
        }

        public static string Translate(Dictionary<List<string>, List<string>> dictionary, string translationString)
        {
            KeyValuePair<List<string>, List<string>> translationStringInDictionary = FindInDictionary(dictionary, translationString);

            if (translationStringInDictionary.Key == null) return "";

            if (translationString[0] >= 'a' && 'z' <= translationString[0]) 
                return string.Join(", ", translationStringInDictionary.Key);
            else 
                return string.Join(", ", translationStringInDictionary.Value);
        }

        public static KeyValuePair<List<string>, List<string>> FindInDictionary(Dictionary<List<string>, List<string>> dictionary, string stringToFind)
        {
            foreach (var item in stringToFind.Split(", "))
                foreach (var line in dictionary)
                    if (line.Value.Contains(item) || line.Key.Contains(item)) return line;

            return new();
        }

        public static Dictionary<List<string>, List<string>> InitializeDictionaryFromFile(string pathToFile)
        {
            string[] arrayLineInDictinary = File.ReadAllLines(pathToFile);

            Dictionary<List<string>, List<string>> dictionary = new();

            foreach (var line in arrayLineInDictinary) 
            {
                string[] wordInLine = line.Split("]");

                string[] engWords = wordInLine[0].Replace("[", "").Split(", ");
                string[] ruWords = wordInLine[1].Trim().Split(", ");

                dictionary[engWords.ToList()] = ruWords.ToList();
            }

            return dictionary;
        }

        public static void SaveEntryInDictionary(Dictionary<List<string>, List<string>> dictionary, string newKey, string newValue)
        {
            KeyValuePair<List<string>, List<string>>  lineValue = FindInDictionary(dictionary, newKey + ", " + newValue);

            if (lineValue.Key == null)
                dictionary[newKey.Split(", ").ToList()] = newValue.Split(", ").ToList();
            else
            {
                dictionary.Remove(lineValue.Key);

                List<string> addWord = lineValue.Key;

                foreach (var key in newKey.Split(", "))
                    if (!lineValue.Key.Contains(key)) 
                        addWord.Add(key);

                dictionary[addWord] = lineValue.Value;

                foreach (var value in newValue.Split(", ").ToArray())
                    if(!lineValue.Value.Contains(value))
                        dictionary[addWord].Add(value);
            }
        }

        public static void SaveDictionaryInFile(Dictionary<List<string>, List<string>> dictionary, string pathToFile)
        {
            List<string> recordData = new();

            foreach (var line in dictionary)
                recordData.Add(string.Format("[{0}] {1}", string.Join(", ", line.Key), string.Join(", ", line.Value)));

            File.WriteAllLines(pathToFile, recordData);
        }

        public static void ProgramExit(Dictionary<List<string>, List<string>> dictionary, int countEntriesInOriginalDictionary)
        {
            if ((countEntriesInOriginalDictionary != dictionary.Count))
            {
                WriteLine(DictionaryHasChanged, ConsoleColor.DarkYellow);
                ConsoleKey dataRetentionConfirmation = Console.ReadKey().Key;
                Console.Clear();

                if (dataRetentionConfirmation == ConsoleKey.Y)
                {
                    SaveDictionaryInFile(dictionary, PathToDictionary);
                    Write(SaveChange, ConsoleColor.DarkGreen);
                }
                else
                    Write(NotSaveChange, ConsoleColor.Red);
            }

            WriteLine(Goodbye, ConsoleColor.Green);
        }

        public static void RecordUnknownWordInDictionary(Dictionary<List<string>, List<string>> dictionary, string unknownWord)
        {
            WriteLine(string.Format(UnknownWord, unknownWord), ConsoleColor.DarkYellow);
            string translatedString = Console.ReadLine();

            if (translatedString == "" || translatedString == null)
                WriteLine(WordIgnored, ConsoleColor.Green);
            else
            {
                if (unknownWord[0] >= 'a' && 'z' <= unknownWord[0])
                    SaveEntryInDictionary(dictionary, translatedString, unknownWord.ToLower());

                else
                    SaveEntryInDictionary(dictionary, unknownWord.ToLower(), translatedString.ToLower());

                WriteLine(string.Format(WordSaved, unknownWord, translatedString), ConsoleColor.Green);
            }
        }
    }
}