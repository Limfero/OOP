using HTMLDecode;

namespace HTMLDecode_test
{

    //тесты которые сломают много амперантов и т.д
    public class Tests
    {

        [TestCase("Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s", "Cat <says> \"Meow\". M&M\'s")]
        [TestCase("", "")]
        [TestCase(null, "")]
        public void HTMLDecodeTest(string codedHTML, string decodedHTML)
        {
            Assert.That(Program.HTMLDecode(codedHTML), Is.EqualTo(decodedHTML));
        }

        [TestCase("&quot;", "\"")]
        [TestCase("&apos;", "\'")]
        [TestCase("&lt;", "<")]
        [TestCase("&gt;", ">")]
        [TestCase("&amp;", "&")]
        [TestCase("&amb;", "amb;")]
        public void ReplaceHTMLEntitiesWithSpecialSymbolsTest(string HTMLEntity, string specialSymbols)
        {
            Assert.That(Program.ReplaceHTMLEntitiesWithSpecialSymbols(HTMLEntity), Is.EqualTo(specialSymbols));

        }

        [TestCase("quot;word", "&quot;")]
        [TestCase("apos;hello", "&apos;")]
        [TestCase("lp;lt", "&lp;")]
        [TestCase("helloword", "&hello")]
        [TestCase("", "&")]
        [TestCase(null, "&")]

        public void ReadHTMLEntitiesTest(string stringHTMLEntites, string HTMLEntites)
        {            
            Assert.That(Program.ReadHTMLEntities(stringHTMLEntites), Is.EqualTo(HTMLEntites));
        }


    }
}