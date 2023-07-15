using time;

namespace time_test
{
    [TestFixture]
    public class CTimeTests
    {
        [Test]
        public void Constructor_ValidArguments_Success()
        {
            var time = new CTime(23, 59, 59);

            Assert.Multiple(() =>
            {
                Assert.That(time.Hours, Is.EqualTo(23));
                Assert.That(time.Minutes, Is.EqualTo(59));
                Assert.That(time.Seconds, Is.EqualTo(59));
            });
        }

        [Test]
        public void Constructor_InvalidArguments_InvalidTime()
        {
            Assert.Throws<ArgumentException> (() => new CTime(25, 60, 60));
        }

        [Test]
        public void Parse__InvalidArguments_InvalidTime()
        {
            Assert.Throws<ArgumentException>(() => Is.EqualTo((CTime)"25:25:25"));
        }

        [Test]
        public void Add_TimeOverflow_ReturnsWrappedTime()
        {
            var time1 = new CTime(23, 59, 59);
            var time2 = new CTime(0, 0, 2);

            var result = time1 + time2;

            Assert.Multiple(() =>
            {
                Assert.That(result.Hours, Is.EqualTo(0));
                Assert.That(result.Minutes, Is.EqualTo(0));
                Assert.That(result.Seconds, Is.EqualTo(1));
            });
        }

        [Test]
        public void Subtract_TimeUnderflow_ReturnsWrappedTime()
        {
            var time1 = new CTime(0, 0, 5);
            var time2 = new CTime(0, 0, 10);

            var result = time1 - time2;

            Assert.Multiple(() =>
            {
                Assert.That(result.Hours, Is.EqualTo(23));
                Assert.That(result.Minutes, Is.EqualTo(59));
                Assert.That(result.Seconds, Is.EqualTo(55));
            });
        }

        [Test]
        public void Increment_Prefix_MaxTime_WrapsToMinTime()
        {
            var maxTime = new CTime(23, 59, 59);

            ++maxTime;

            Assert.Multiple(() =>
            {
                Assert.That(maxTime.Hours, Is.EqualTo(0));
                Assert.That(maxTime.Minutes, Is.EqualTo(0));
                Assert.That(maxTime.Seconds, Is.EqualTo(0));
            });
        }

        [Test]
        public void Decrement_Postfix_MinTime_WrapsToMaxTime()
        {
            var minTime = new CTime(0, 0, 0);
            
            minTime--;

            Assert.Multiple(() =>
            {
                Assert.That(minTime.Hours, Is.EqualTo(23));
                Assert.That(minTime.Minutes, Is.EqualTo(59));
                Assert.That(minTime.Seconds, Is.EqualTo(59));
            });
        }


        [Test]
        public void MultiplyByInteger_MultiplierZero_ReturnsZeroTime()
        {
            var time = new CTime(12, 30, 0);
            int multiplier = 0;

            var result = time * multiplier;

            Assert.Multiple(() =>
            {
                Assert.That(result.Hours, Is.EqualTo(0));
                Assert.That(result.Minutes, Is.EqualTo(0));
                Assert.That(result.Seconds, Is.EqualTo(0));
            });
        }

        [Test]
        public void DivideByInteger_DivisorZero_ThrowsDivideByZeroException()
        {
            var time = new CTime(10, 45, 0);
            int divisor = 0;

            Assert.Throws<DivideByZeroException> (() => Is.EqualTo(time / divisor));
        }
    }

}