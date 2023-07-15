using flipbyte;

namespace flipbyte_test
{
    public class Tests
    {

        [TestCase(6)]
        [TestCase(254)]
        [TestCase(0)]
        [TestCase(480)]
        public void DecimalNumberConvertToBinaryTest(int decimalNumber)
        {
            Assert.That(Convert.ToString(decimalNumber, 2), Is.EqualTo(Program.ConvertFromDecimalToBinary(decimalNumber)));
        }

        [TestCase(1100)]
        [TestCase(11111111)]
        [TestCase(0)]
        [TestCase(280)]
        public void BinaryNumberConvertToDecimalTest(int binaryNumber)
        {
            bool isBinaryNumber = true;

            foreach (var ch in binaryNumber.ToString())
                if (ch != '1' && ch != '0') isBinaryNumber = false;

            if (isBinaryNumber)
                Assert.That(Convert.ToInt32(binaryNumber.ToString(), 2).ToString(), Is.EqualTo(Program.ConvertFromBinaryToDecimal(binaryNumber.ToString())));
            else
                Assert.That(binaryNumber.ToString(), Is.EqualTo(Program.ConvertFromBinaryToDecimal(binaryNumber.ToString())));

        }

        [TestCase("")]
        [TestCase("01000100")]
        [TestCase("абвгд")]
        public void ReverseStringTest(string stringToReverse)
        {
            char[] stringArray = stringToReverse.ToCharArray();
            Array.Reverse(stringArray);
            string reversedStr = new(stringArray);

            Assert.That(reversedStr, Is.EqualTo(Program.ReverseString(stringToReverse)));
        }

        [TestCase(6)]
        [TestCase(254)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(280)]
        public void FlipByteTest(int decimalNumber)
        {
            if (!(0 < decimalNumber && decimalNumber < 255))
                Assert.That("Число должно быть в интервале (0, 255)", Is.EqualTo(Program.GetFlipByte(decimalNumber).ToString()));
            else
                Assert.That(File.ReadAllText(decimalNumber.ToString() + ".txt"), Is.EqualTo(Program.GetFlipByte(decimalNumber).ToString()));

        }

    }
}