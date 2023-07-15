using car;

namespace car_test
{
    public class EngineTests
    {
        [Test]
        public void RigthEngineOnTest()
        {
            Car car = new();

            Assert.That(car.TurnOnEngine(), Is.EqualTo(true));
        }

        [Test]
        public void WrongEngineOffTest()
        {
            Car car = new();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(10);

            Assert.That(car.TurnOffEngine, Is.EqualTo(false));

            car.SetSpeed(0);

            Assert.That(car.TurnOffEngine, Is.EqualTo(false));
        }

        [Test]
        public void RigthEngineOffTest()
        {
            Car car = new();
            car.TurnOnEngine();
            car.SetGear(0);

            Assert.That(car.TurnOffEngine, Is.EqualTo(true));
        }
    }

    public class GearTest
    {
        [Test]
        public void ShiftingToRightGearTest()
        {
            Car car = new();
            car.TurnOnEngine();

            Assert.That(car.SetGear(1), Is.EqualTo(true));
        }


        [Test]
        public void ShiftingToWrongGearTest()
        {
            Car car = new();

            Assert.That(car.SetGear(5), Is.EqualTo(false));
        }
    }
    public class SpeedTest
    {
        [Test]
        public void ShiftingToRightSpeedTest()
        {
            Car car = new();
            car.TurnOnEngine();
            car.SetGear(1);

            Assert.That(car.SetSpeed(10), Is.EqualTo(true));
        }

        [Test]
        public void ShiftingToWrongSpeedTest()
        {
            Car car = new();
            Assert.That(car.SetSpeed(100), Is.EqualTo(false));
        }
    }

    public class DirectionTest
    {
        [Test]
        public void StandingStillTest()
        {
            Car car = new();
            car.TurnOnEngine();

            Assert.That(car.GetDirection(), Is.EqualTo(Car.Directions[0]));
        }

        [Test]
        public void ForwardTest()
        {
            Car car = new();
            car.TurnOnEngine();
            car.SetGear(1);
            car.SetSpeed(10);

            Assert.That(car.GetDirection(), Is.EqualTo(Car.Directions[1]));
        }

        [Test]
        public void BackTest()
        {
            Car car = new();
            car.TurnOnEngine();
            car.SetGear(-1);
            car.SetSpeed(10);

            Assert.That(car.GetDirection(), Is.EqualTo(Car.Directions[2]));
        }
    }
}