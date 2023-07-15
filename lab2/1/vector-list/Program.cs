using System.Globalization;

namespace vector_list
{
    public class Program
    {
        private static readonly string WrongInputFormat = "Неверный ввод!";

        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();

            if (IsNotCorrectInput(userInput)) Environment.Exit(1);

            List<double> userList = InitializeList(userInput);

            AddToEachElementSumOfThreeMinElements(userList);

            WriteList(userList);
        }

        public static List<double> InitializeList(string inputString)
        {
            List<double> resultList = new();

            if (inputString == null || inputString.Trim() == "") return resultList;

            string[] array = inputString.Split(" ");

            foreach (var item in array)
                if(double.TryParse(item, NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                    resultList.Add(number);

            return resultList;
        }

        public static void AddToEachElementSumOfThreeMinElements(List<double> numberList)
        {
            if (numberList == null || numberList.Count == 0) return;

            double sumOfThreeMinElements = 0;

            if (numberList.Count > 3)
            {
                List<double> tempList = new();

                foreach (var number in numberList)
                    tempList.Add(number);

                tempList.Sort();

                for (int i = 0; i < tempList.Count && i < 3; i++)
                    sumOfThreeMinElements += tempList[i];
            }
            else
            {
                sumOfThreeMinElements = numberList.Sum();
            }

            for (int i = 0; i < numberList.Count; i++)
                numberList[i] += sumOfThreeMinElements;  
        }

        public static void WriteList(List<double> numberList)
        {
            string result = "";

            if (numberList == null || numberList.Count == 0 )
            {
                File.WriteAllText("output.txt", result.Trim());
                return;
            }

            List<double> tempList = ((double[])numberList.ToArray().Clone()).ToList();
            tempList.Sort();

            foreach (var number in tempList)
            {
                Console.Write("{0} ", number);
                result += number + " ";
            }

            File.WriteAllText("output.txt", result.Replace(",", ".").Trim());
        }

        private static bool IsNotCorrectInput(string input)
        {
            if(input is null || input.Trim() == "" || char.IsLetter(input[0]))
            {
                Console.WriteLine(WrongInputFormat);
                return true;
            }

            return false;
        }

    }
}