using MockFramework;
using NUnit.Framework;

namespace MockTestFramework
{
    public class MockTest
    {
        private InstanceCreator _instanceCreator;
        private IMockInterface _mockInterface;

        [SetUp]
        public void Setup()
        {
            _instanceCreator = new InstanceCreator();
            _mockInterface = _instanceCreator.CreateDynamicTypeInstance() as IMockInterface;
        }

        [TestCase("Circle")]
        [TestCase("Square")]
        [TestCase("Rectangle")]
        [TestCase("Triangle")]
        [Test]
        public void GetNoOfSides_ReturnsDefaultValue_ForShapeName(string shapeName)
        {
            var result = _mockInterface.GetNoOfSides(shapeName);
            Assert.AreEqual(10, result);
        }

        [TestCase(10, 20)]
        [TestCase(20, 30)]
        [TestCase(30, 40)]
        [TestCase(40, 50)]
        [Test]
        public void CalculateArea_ReturnsDefaultValue_ForFirstSideAndSecondSide(int firstSide, int secondSide)
        {
            var result = _mockInterface.CalculateArea(firstSide, secondSide);
            Assert.AreEqual(10.50, result);
        }

        [Test]
        public void GetShapeName_ReturnsDefaultValue_WhenInterfaceMethodIsCalled()
        {
            var result = _mockInterface.GetShapeName();
            Assert.AreEqual("Default", result);
        }
    }
}