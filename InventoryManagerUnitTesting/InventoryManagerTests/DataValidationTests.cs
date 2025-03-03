using NUnit.Framework;
using InventoryManager.InputValidation;

namespace InventoryManagerTests
{    
    [TestFixture]
    internal class DataValidationTests
    {
        DataValidation dataValidation = new DataValidation();

        [TestCase("123")]
        [TestCase("2345678")]
        [TestCase(" 0 ")]
        [Test]
        public void IsInputInt_ReturnsTrue_ForValidIntegerString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataInt(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("abcd")]
        [TestCase("ab123")]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase("@%^")]
        [Test]
        public void IsInputInt_ReturnsFalse_ForInvalidIntegerString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataInt(inputData);

            //Assert
            Assert.IsFalse(result);
        }


        [TestCase("21.67")]
        [TestCase("123")]
        [TestCase(" 0.0000 ")]
        [Test]
        public void IsInputDecimal_ReturnsTrue_ForValidDecimalString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputDecimal(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("ab123")]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase("@%^")]
        [Test]
        public void IsInputDecimal_ReturnsFalse_ForInvalidDecimalString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputDecimal(inputData);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void IsDataEmpty_ReturnsTrue_ForNullOrEmptyInputString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataEmpty(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("5435")]
        [TestCase("hello")]
        [TestCase("Welcome123")]
        [Test]
        public void IsDataEmpty_ReturnsFalse_ForValidInputString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataEmpty(inputData);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
