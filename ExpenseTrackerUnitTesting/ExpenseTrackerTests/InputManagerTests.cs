using NUnit.Framework;
using ExpenseTracker.ConsoleUI;
using ExpenseTracker.InputValidation;
using ExpenseTracker.Model;
using Moq;

namespace ExpenseTrackerTests
{
    [TestFixture]
    public class InputManagerTests
    {
        private InputManager _inputManager;
        private Mock<DataValidation> _dataValidation;

        [SetUp]
        public void SetUp()
        {
            _dataValidation = new Mock<DataValidation>();
            _inputManager = new InputManager(_dataValidation.Object);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetUserOptions_ReturnsInputStringAsApplicationOptions_ForValidInputInteger(string inputUserOptions)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputUserOptions);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            ApplicationOptions result = _inputManager.GetUserChoice();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual((ApplicationOptions)int.Parse(inputUserOptions), result);
                Assert.AreEqual($"\n[0] {ApplicationOptions.ViewTransaction}\n[1] {ApplicationOptions.AddTransaction}\n[2] {ApplicationOptions.DeleteTransaction}\n[3] {ApplicationOptions.EditTransaction}\n[4] {ApplicationOptions.SearchTransaction}\n[5] {ApplicationOptions.ViewTransactionSummary}\n[6] {ApplicationOptions.Exit}\nSelect the action to be performed :", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetModifyChoice_ReturnsInputStringAsModifyChoice_ForValidInputInteger(string inputEditField)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputEditField);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            UserEditChoice result = _inputManager.GetModifyChoice();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual((UserEditChoice)int.Parse(inputEditField), result);
                Assert.AreEqual($"\n[0] {UserEditChoice.EditTransactionType}\n[1] {UserEditChoice.EditTransactionAmount}\n[2] {UserEditChoice.EditTransactionDate}\n[3] {UserEditChoice.EditTransactionDetails}\nSelect the field to edit :", stringWriter.ToString());
            });
        }

        [TestCase("0")]
        [TestCase("1")]
        [Test]
        public void GetTransactionType_ReturnsInputStringAsTransactionType_ForValidInputInteger(string inputTransactionType)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionType);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            TransactionType result = _inputManager.GetTransactionType();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual((TransactionType)int.Parse(inputTransactionType), result);
                Assert.AreEqual($"[0] {TransactionType.Income}\n[1] {TransactionType.Expense}\nEnter the Transaction Type :  ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void ReplaceInvalidInput_ReturnsInputString_ForValidInputString(string inputValidInput)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputValidInput);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = _inputManager.ReplaceInvalidInput();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputValidInput, result);
                Assert.AreEqual("The Provided input is invalid !!\nProvide the Input again :", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetExpenseCategory_ReturnsInputString_ForValidInputString(string inputExpenseCategory)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputExpenseCategory);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = _inputManager.GetExpenseCategory();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputExpenseCategory, result);
                Assert.AreEqual("Enter the Category of expense : ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetIncomeSource_ReturnsInputString_ForValidInputString(string inputIncomeSource)
        {
            //Arrange
            var stringReader = new StringReader(inputIncomeSource);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            string result = _inputManager.GetIncomeSource();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputIncomeSource, result);
                Assert.AreEqual("Enter the Source of Income : ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetTransactionAmount_ReturnInputStringAsInteger_ForValidInputInteger(string inputTransactionAmount)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionAmount);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = _inputManager.GetTransactionAmount();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(int.Parse(inputTransactionAmount), result);
                Assert.AreEqual("Enter the Transaction Amount :  ", stringWriter.ToString());
            });
        }
        [TestCase("5/5/5")]
        [TestCase("05/12/2024")]
        [TestCase("06/07/12")]
        [TestCase("12/12/2012")]
        [Test]
        public void GetTransactionDate_ReturnInputStringAsDate_ForValidInputDate(string inputTransactionDate)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionDate);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = _inputManager.GetTransactionDate();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(DateOnly.Parse(inputTransactionDate), result);
                Assert.AreEqual("Enter the Date of Transaction (DD/MM/YYYY) :  ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetTransactionIndex_ReturnInputStringAsInteger_ForValidInputInteger(string inputTransactionIndex)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionIndex);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = _inputManager.GetTransactionIndex();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(int.Parse(inputTransactionIndex), result);
                Assert.AreEqual("Select the transaction index : ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(GetValidIntegerTestCases))]
        [Test]
        public void GetValidInteger_ReturnsInputStringAsInteger_ForValidInputInteger(StringReader stringReader, int expectedResult)
        {
            //Arrange
            Console.SetIn(stringReader);

            //Act
            int result = _inputManager.GetValidInteger(Console.ReadLine());

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object> GetValidIntegerTestCases()
        {
            return new[]
            {
                new object[] { new StringReader("a\nab12\n123") , 123},
                new object[] { new StringReader("a\na\n*abc\n456") , 456},
                new object[] { new StringReader("789") , 789},
                new object[] { new StringReader("ac23\nsd\n100") , 100},
            };
        }

        [TestCaseSource(nameof(GetValidDateTestCases))]
        [Test]
        public void GetValidDate_ReturnsInputStringAsDate_ForValidInputDate(StringReader stringReader, DateOnly expectedResult)
        {
            //Arrange
            Console.SetIn(stringReader);

            //Act
            DateOnly result = _inputManager.GetValidDate(Console.ReadLine());

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object> GetValidDateTestCases()
        {
            return new[]
            {
                new object[] { new StringReader("a\nab12\n12/12/2021") , DateOnly.Parse("12/12/2021")},
                new object[] { new StringReader("a\na\n*abc\n12/12/2021") , DateOnly.Parse("12/12/2021")},
                new object[] { new StringReader("12/12/2021") , DateOnly.Parse("12/12/2021")},
                new object[] { new StringReader("ac23\nsd\n12/12/2021") , DateOnly.Parse("12/12/2021")},
            };
        }

        [Test]
        public void GetValidInput_ReturnsInputString_ForValidInputString()
        {
            //Arrange
            _dataValidation.Setup(i => i.IsDataEmpty(It.IsAny<string>())).Returns(false);
            string expectedResult = "Test";

            //Act
            string result = _inputManager.GetValidInput(expectedResult);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(nameof(GetValidInputTestCases))]
        [Test]
        public void GetValidInput_ReturnsInputStringAfterReplacement_ForInvalidInputString(string invalidString, StringReader validStringReader, string validString)
        {
            //Arrange
            _dataValidation.SetupSequence(i => i.IsDataEmpty(It.IsAny<string>())).Returns(true).Returns(false);
            Console.SetIn(validStringReader);

            //Act
            string result = _inputManager.GetValidInput(invalidString);

            //Assert
            Assert.AreEqual(validString, result);
        }

        private static IEnumerable<object> GetValidInputTestCases()
        {
            return new[]
            {
                new object[] { "", new StringReader("Test1"), "Test1" },
                new object[] { null, new StringReader("Test2"), "Test2" }
            };
        }

        private static IEnumerable<object> InputManagerStringMethodsTestCases()
        {
            return new[]
            {
                new object[] { new string("Hi") },
                new object[] { new string("Welcome") },
                new object[] { new string("Food") },
                new object[] { new string("123abc") },
                new object[] { new string("TIMETIME") },
                new object[] { new string("123456") }
            };
        }

        private static IEnumerable<object> InputManagerIntegerMethodsTestCases()
        {
            return new[]
            {
                new object[] { new string("90234")},
                new object[] { new string("0000")},
                new object[] { new string("1230987")},
                new object[] { new string("100") },
                new object[] { new string("60") },
                new object[] { new string("5") }

            };
        }
    }
}
