using bodies;

namespace bodies_test
{
    public class Tests
    {
        [Test]
        public void SphereVolumeTest()
        {
            CSphere sphere = new(2.0, 1000.0);
            double expectedVolume = 33.5103;
            double actualVolume = sphere.Volume;
            Assert.That(actualVolume, Is.EqualTo(expectedVolume).Within(0.0001));
        }

        [Test]
        public void ParallelepipedMassTest()
        {
            CParallelepiped parallelepiped = new(2.0, 3.0, 4.0, 1500.0);
            double expectedMass = 36000.0;
            double actualMass = parallelepiped.Mass;
            Assert.That(actualMass, Is.EqualTo(expectedMass).Within(0.0001));
        }

        [Test]
        public void CompoundAverageDensityTest()
        {
            CCompound compound = new();
            compound.AddBody(new CSphere(2.0, 1000.0));
            compound.AddBody(new CParallelepiped(2.0, 3.0, 4.0, 1000.0));

            double expectedDensity = 1000.0;
            double actualDensity = compound.Mass / compound.Volume;
            Assert.That(actualDensity, Is.EqualTo(expectedDensity).Within(0.0001));
        }

        [Test]
        public void GetHeaviestBodyTest()
        {
            CSphere sphere = new(2.0, 1000.0);
            CParallelepiped parallelepiped = new(2.0, 3.0, 4.0, 1500.0);
            CCompound compound = new();
            compound.AddBody(sphere);
            compound.AddBody(parallelepiped);

            List<CBody> bodies = new() { sphere, parallelepiped, compound };
            CBody heaviestBody = Program.GetHeaviestBody(bodies);

            Assert.That(heaviestBody, Is.EqualTo(compound));
        }

        [Test]
        public void GetLightestBodyInWaterTest()
        {
            CSphere sphere = new(2.0, 1000.0);
            CParallelepiped parallelepiped = new(2.0, 3.0, 4.0, 1500.0);
            CCompound compound = new();
            compound.AddBody(sphere);
            compound.AddBody(parallelepiped);

            List<CBody> bodies = new() { sphere, parallelepiped, compound };
            CBody lightestBodyInWater = Program.GetLightestBodyInWater(bodies);

            Assert.That(lightestBodyInWater, Is.EqualTo(sphere));
        }

        [Test]
        public void GetHeaviestBody_NoBodiesTest()
        {
            List<CBody> bodies = new();
            CBody heaviestBody = Program.GetHeaviestBody(bodies);

            Assert.That(heaviestBody, Is.Null);
        }

        [Test]
        public void GetLightestBodyInWater_NoBodiesTest()
        {
            List<CBody> bodies = new();
            CBody lightestBodyInWater = Program.GetLightestBodyInWater(bodies);

            Assert.That(lightestBodyInWater, Is.Null);
        }

        [Test]
        public void CompoundAverageDensity_EmptyCompoundTest()
        {
            CCompound compound = new();
            double expectedDensity = 0.0; 
            double actualDensity = compound.Density;
            Assert.That(actualDensity, Is.EqualTo(expectedDensity).Within(0.0001));
        }

        public void TestCompoundAddSelf()
        {
            CCompound compound = new();
            compound.AddBody(compound);
            Assert.That(compound.Bodies.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestCompoundAddChildCompound()
        {
            CCompound compound = new();
            CCompound childCompound = new();
            compound.AddBody(childCompound);
            Assert.That(compound.Bodies.Count, Is.EqualTo(1));
        }
    }
}