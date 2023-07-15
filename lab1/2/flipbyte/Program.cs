using System.Text;

namespace flipbyte
{
    public static class Program
    {
        private static readonly string WrongInputFormatError = "Wrong input format! Format: <input byte>";
        private static readonly string NotNumberError = "Not a number is entered!";
        private static readonly string NumberOutsideRangeError = "A number outside the range 0-255";

        static int Main(string[] args)
        {
            if (IsNotCorrectInput(args))
                return 1;

            byte userByte = byte.Parse(args[0]);

            ReverseBits(userByte);

            return 0;
        }

        static void ReverseBits(byte inputByte)
        {
            byte reversedByte = 0;

            for (int i = 0; i < 8; i++)
            {
                reversedByte <<= 1;
                reversedByte |= (byte)(inputByte & 1);
                inputByte >>= 1;
            }

            Console.WriteLine(reversedByte);
        }

        public static bool IsNotCorrectInput(string[] input)
        {
            if (input.Length == 0 || input.Length > 1)
            {
                Console.WriteLine(WrongInputFormatError);
                return true;
            }

            if (!int.TryParse(input[0], out int userInt))
            {
                Console.WriteLine(NotNumberError);
                return true;
            }

            if (userInt < 0 || userInt > 255)
            {
                Console.WriteLine(NumberOutsideRangeError);
                return true;
            }

            return false;
        }
    }
}
