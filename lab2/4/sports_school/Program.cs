namespace sports_school
{
    public class Program
    {
        private static readonly string WrongInputError = "Неверный ввод!";
        private static readonly string FileNotExistsError = "Файд №{0} не найден!";

        public static void Main(string[] args)
        {
            string userInput = "VolleyballSection.txt SoccerSection.txt TennisSection.txt";

            if (IsNotCorrectInput(userInput)) Environment.Exit(1);

            SortedSet<string> studentsInSchool = GetAllStudentsInSchool(userInput);

            foreach (var student in studentsInSchool)
                Console.WriteLine(student);
        }

        public static SortedSet<string> GetSortedSetFromFile(string pathToFile)
        {
            SortedSet<string> set = new();

            if (!File.Exists(pathToFile)) return set;

            foreach (var element in File.ReadAllLines(pathToFile))
                set.Add(element);

            return set;
        }

        public static SortedSet<string> GetAllStudentsInSchool(string sectionFilePaths)
        {
            SortedSet<string> studentsInSchool = new();

            foreach (var sectionFilePath in sectionFilePaths.Split(" "))
                studentsInSchool.UnionWith(GetSortedSetFromFile(sectionFilePath));

            return studentsInSchool;
        }

        public static bool IsNotCorrectInput(string input)
        {
            if(input is null || input.Trim() == "")
            {
                Console.WriteLine(WrongInputError);
                return true;
            }

            string[] filePaths = input.Split(" ");

            for (int i = 0; i < filePaths.Length; i++)
                if (!File.Exists(filePaths[i]))
                {
                    Console.WriteLine(FileNotExistsError, i + 1);
                    return true;
                }

            return false;
        }
    }
}