using MockFramework;
using Xunit;

namespace MockTestFramework
{
    public class MockTest
    {
        private InstanceCreator _instanceCreator;
        private IMockInterface _mockInterface;

        public MockTest()
        {
            _instanceCreator = new InstanceCreator();
            _mockInterface = _instanceCreator.CreateDynamicTypeInstance() as IMockInterface;
        }

        [Theory]
        [InlineData("Circle")]
        [InlineData("Square")]
        [InlineData("Rectangle")]
        [InlineData("Triangle")]
        public void GetNoOfSides_ReturnsDefaultValue_ForShapeName(string shapeName)
        {
            var result = _mockInterface.GetNoOfSides(shapeName);
            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(10, 20)]
        [InlineData(20, 30)]
        [InlineData(30, 40)]
        [InlineData(40, 50)]
        public void CalculateArea_ReturnsDefaultValue_ForFirstSideAndSecondSide(int firstSide, int secondSide)
        {
            var result = _mockInterface.CalculateArea(firstSide, secondSide);
            Assert.Equal(10.50, result);
        }

        [Fact]
        public void GetShapeName_ReturnsDefaultValue_WhenInterfaceMethodIsCalled()
        {
            var result = _mockInterface.GetShapeName();
            Assert.Equal("Default", result);
        }
    }
}