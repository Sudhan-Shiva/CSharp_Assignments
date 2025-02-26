using NUnit.Framework;
using InventoryManager.InputValidation;

namespace InventoryManagerTests
{    
    [TestFixture]
    internal class DataValidationTests
    {
        DataValidation dataValidation = new DataValidation();

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCase("abcd", false)]
        [TestCase("ab123", false)]
        [TestCase("", false)]
        [TestCase("     ", false)]
        [TestCase("@%^", false)]
        [TestCase("123", true)]
        [TestCase("2345678", true)]
        [TestCase(" 0 ", true)]
        [Test]
        public void IsInputInt_ReturnsTrue_ForValidInteger(string inputData, bool isInputInt)
        {
            bool result = dataValidation.IsDataInt(inputData);
            Assert.AreEqual(isInputInt, result);
        }


        [TestCase("21.67", true)]
        [TestCase("123", true)]
        [TestCase(" 0.0000 ", true)]
        [TestCase("ab123", false)]
        [TestCase("", false)]
        [TestCase("     ", false)]
        [TestCase("@%^", false)]
        [Test]
        public void IsInputDecimal_ReturnsTrue_ForValidDecimal(string inputData, bool isInputDecimal)
        {
            bool result = dataValidation.IsInputDecimal(inputData);
            Assert.AreEqual(isInputDecimal, result);
        }

        [TestCase("5435", false)]
        [TestCase(null, true)]
        [TestCase("hello", false)]
        [TestCase("", true)]
        [TestCase("Welcome123", false)]
        [Test]
        public void IsDataEmpty_ReturnsTrue_ForEmptyOrNullInput(string inputData, bool isDataEmpty)
        {
            bool result = dataValidation.IsDataEmpty(inputData);
            Assert.AreEqual(result, isDataEmpty);
        }
    }
}
