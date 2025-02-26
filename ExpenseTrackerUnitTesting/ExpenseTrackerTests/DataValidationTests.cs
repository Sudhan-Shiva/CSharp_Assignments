using NUnit.Framework;
using ExpenseTracker.InputValidation;

namespace ExpenseTrackerTests
{
    [TestFixture]
    public class DataValidationTests
    {
        DataValidation dataValidation = new DataValidation();

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCase("123")]
        [TestCase("000234")]
        [TestCase("2345678")]
        [TestCase(" 0 ")]
        [Test]
        public void IsInputInt_ReturnsTrue_ForValidInputIntegerString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputInt(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("abcd")]
        [TestCase("ab123")]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase("@%^")]
        [Test]
        public void IsInputInt_ReturnsFalse_ForInvalidInputIntegerString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputInt(inputData);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void IsDataEmpty_ReturnsTrue_ForNullOrEmptyString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataEmpty(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("5435")]
        [TestCase("hello")]
        [TestCase("11.22.33.44")]
        [TestCase("Welcome123")]
        [Test]
        public void IsDataEmpty_ReturnsFalse_ForValidString(string inputData)
        {
            //Act
            bool result = dataValidation.IsDataEmpty(inputData);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase("1/1/1")]
        [TestCase("04/05/2004")]
        [TestCase("20-5-2004")]
        [Test]
        public void IsInputDate_ReturnsTrue_ForValidDateString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputDate(inputData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("5435")]
        [TestCase(null)]
        [TestCase("Welcome123")]
        [Test]
        public void IsInputDate_ReturnsFalse_ForInvalidDateString(string inputData)
        {
            //Act
            bool result = dataValidation.IsInputDate(inputData);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
