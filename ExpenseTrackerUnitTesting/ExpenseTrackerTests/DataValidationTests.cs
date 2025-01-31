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

        [TestCase("abcd", false)]
        [TestCase("ab123", false)]
        [TestCase("", false)]
        [TestCase("     ", false)]
        [TestCase("@%^", false)]
        [TestCase("123", true)]
        [TestCase("2345678", true)]
        [TestCase(" 0 ", true)]
        [Test]
        public void IsInputInt_ShallReturnTrue_IfInputIsInt(string inputData, bool isInputInt)
        {
            //Act
            bool result = dataValidation.IsInputInt(inputData);

            //Assert
            Assert.AreEqual(isInputInt, result);
        }

        [TestCase("5435", false)]
        [TestCase(null, true)]
        [TestCase("hello", false)]
        [TestCase("", true)]
        [TestCase("Welcome123", false)]
        [Test]
        public void IsDataEmpty_ShallReturnTrue_IfInputIsNullOrEmpty(string inputData, bool isDataEmpty)
        {
            //Act
            bool result = dataValidation.IsDataEmpty(inputData);

            //Assert
            Assert.AreEqual(result, isDataEmpty);
        }

        [TestCase("5435", false)]
        [TestCase("1/1/1", true)]
        [TestCase(null, false)]
        [TestCase("04/05/2004", true)]
        [TestCase("20-5-2004", true)]
        [TestCase("Welcome123", false)]
        [Test]
        public void IsInputDate_ShallReturnTrue_IfInputIsValidDate(string inputData, bool isInputValidDate)
        {
            //Act
            bool result = dataValidation.IsInputDate(inputData);

            //Assert
            Assert.AreEqual(result, isInputValidDate);
        }
    }
}
