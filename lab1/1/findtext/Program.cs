namespace findtext
{
    public class Program
    {
        static int Main(string[] args)
        {
            if (IsNotCorrectInput(args)) return 1;

            string pathToFile = args[0].Replace("\"", "");
            string textToSearch = args[1].Replace("\"", "");

            List<int> indexList = GetIndexList(textToSearch.Trim(), pathToFile);

            return WriteResultInConsole(indexList);
        }

        public static List<int> GetIndexList(string stringToSearch, string pathToTextFile)
        {
            List<int> listLineNumbers = new();

            if (stringToSearch == "") return listLineNumbers;

            string[] allLinesInFile = File.ReadAllLines(pathToTextFile);
            string[] allWordsInTextToSearch = stringToSearch.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allLinesInFile.Length; i++)
            {
                string[] allWordsInLine = allLinesInFile[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < allWordsInLine.Length; j++)
                    if (allWordsInLine[j] == allWordsInTextToSearch[0])
                        if (CheckWordMatches(allWordsInTextToSearch, allWordsInLine, j))
                        {
                            listLineNumbers.Add(i + 1);
                            break;
                        }
            }

            return listLineNumbers;
        }

        public static bool CheckWordMatches(string[] allWordsToCheck, string[] allWordsToMatch, int startPos)
        {
            int indexWords = startPos;

            foreach (var word in allWordsToCheck)
            {
                if (indexWords + 1 > allWordsToMatch.Length || word != allWordsToMatch[indexWords]) return false;

                indexWords++;
            }

            return true;
        }

        public static int WriteResultInConsole(List<int> listResults)
        {
            File.WriteAllLines("output.txt", listResults.Select(line => line.ToString()).ToArray());

            if (listResults.Count > 1)
            {
                foreach (var numberLine in listResults)
                    Console.WriteLine(numberLine);

                return 0;
            }

            Console.WriteLine("Text not found");
            return 1;
        }

        public static bool IsNotCorrectInput(string[] input)
        {
            if (input.Length < 2 || input.Length > 2)
            {
                Console.WriteLine("Wrong input format! Format: \"<file name>\" \"<text to search>\"");
                return true;
            }

            if (!File.Exists(input[0].Replace("\"", "")))
            {
                Console.WriteLine("Wrong file name or file does not exist!");
                return true;
            }

            return false;
        }
    }
}