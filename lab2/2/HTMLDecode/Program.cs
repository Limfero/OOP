namespace HTMLDecode
{
    public class Program
    {
        private static readonly string WrongInputFormat = "Неверный ввод!";

        static void Main(string[] args)
        {
            //string codedHTML = Console.ReadLine();

            string codedHTML = "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s";

            if (IsNotCorrectInput(codedHTML)) Environment.Exit(1);

            string decodedHTML = HTMLDecode(codedHTML);

            Console.WriteLine(decodedHTML);
        }

        public static string HTMLDecode(string codedHTML)
        {
            if (codedHTML == "" || codedHTML == null) return "";

            string decodedHTML = "";

            string[] arrayLineDecodeHTML = codedHTML.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in arrayLineDecodeHTML)
            {
                string essenceHTML = ReadHTMLEntities(line);

                decodedHTML += ReplaceHTMLEntitiesWithSpecialSymbols(essenceHTML) + ("&" + line).Replace(essenceHTML, "");
            }

            return decodedHTML;
        }

        public static string ReplaceHTMLEntitiesWithSpecialSymbols(string essenceHTML)
        {
            return essenceHTML switch
            {
                "&quot;" => "\"",
                "&apos;" => "\'",
                "&lt;" => "<",
                "&gt;" => ">",
                "&amp;" => "&",
                _ => essenceHTML.Replace("&", ""),
            };
        }

        public static string ReadHTMLEntities(string stringHTMLEntites)
        {
            string essenceHTML = "&";

            if (stringHTMLEntites == "" || stringHTMLEntites == null) return essenceHTML;

            for (int i = 0; i < stringHTMLEntites.Length && i < 5; i++)
            {
                essenceHTML += stringHTMLEntites[i];

                if (stringHTMLEntites[i] == ';') break;
            }

            return essenceHTML;
        }

        public static bool IsNotCorrectInput(string input)
        {
            if (input is null || input.Trim() == "")
            {
                Console.WriteLine(WrongInputFormat);
                return true;
            }

            return false;
        }

    }
}