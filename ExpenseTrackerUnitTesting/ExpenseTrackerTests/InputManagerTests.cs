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
        InputManager inputManager;

        [SetUp]
        public void SetUp()
        {
            Mock<DataValidation> _mockDataValidation = new Mock<DataValidation>();
            inputManager = new InputManager(_mockDataValidation.Object);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetUserOptions_ShallReturnInput_IfInputIsInt(string inputUserOptions)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputUserOptions);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetUserChoice();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(int.Parse(inputUserOptions), result);
                Assert.AreEqual($"\n[0] {ApplicationOptions.ViewTransaction}\n[1] {ApplicationOptions.AddTransaction}\n[2] {ApplicationOptions.DeleteTransaction}\n[3] {ApplicationOptions.EditTransaction}\n[4] {ApplicationOptions.SearchTransaction}\n[5] {ApplicationOptions.ViewTransactionSummary}\n[6] {ApplicationOptions.Exit}\nSelect the action to be performed :", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetModifyChoice_ShallReturnInput_IfInputIsInt(string inputEditField)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputEditField);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetModifyChoice();
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(int.Parse(inputEditField), result);
                Assert.AreEqual($"\n[0] {UserEditChoice.EditTransactionType}\n[1] {UserEditChoice.EditTransactionAmount}\n[2] {UserEditChoice.EditTransactionDate}\n[3] {UserEditChoice.EditTransactionDetails}\nSelect the field to edit :", stringWriter.ToString());
            });
        }

        [TestCase("0")]
        [TestCase("1")]
        [Test]
        public void GetTransactionType_ShallReturnInput_IfInputIsBetween0And1(string inputTransactionType)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionType);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetTransactionType();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue((result >=0) && (result <=1));
                Assert.AreEqual(int.Parse(inputTransactionType), result);
                Assert.AreEqual($"[0] {TransactionType.Income}\n[1] {TransactionType.Expense}\nEnter the Transaction Type :  ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void ReplaceInvalidInput_ShallReturnInput_IfInputGiven(string inputValidInput)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputValidInput);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.ReplaceInvalidInput();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputValidInput, result);
                Assert.AreEqual("The Provided input is invalid !!\nProvide the Input again :", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetExpenseCategory_ShallReturnInput_IfInputGivenIsNotNullOrEmpty(string inputExpenseCategory)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputExpenseCategory);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetExpenseCategory();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputExpenseCategory, result);
                Assert.AreEqual("Enter the Category of expense : ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetIncomeSource_ShallReturnInput_IfInputGivenIsNotNullOrEmpty(string inputIncomeSource)
        {
            //Arrange
            var stringReader = new StringReader(inputIncomeSource);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            string result = inputManager.GetIncomeSource();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(inputIncomeSource, result);
                Assert.AreEqual("Enter the Source of Income : ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetTransactionAmount_ShallReturnInput_IfInputGivenIsInt(string inputTransactionAmount)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionAmount);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetTransactionAmount();

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
        public void GetTransactionDate_ShallReturnInput_IfInputGivenIsDate(string inputTransactionDate)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionDate);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetTransactionDate();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(DateOnly.Parse(inputTransactionDate), result);
                Assert.AreEqual("Enter the Date of Transaction (DD/MM/YYYY) :  ", stringWriter.ToString());
            });
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetTransactionIndex_ShallReturnInput_IfInputGivenIsInt(string inputTransactionIndex)
        {
            //Arrange
            var stringWriter = new StringWriter();
            var stringReader = new StringReader(inputTransactionIndex);
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetTransactionIndex();

            //Assert
            Assert.Multiple(() => 
            { 
                Assert.AreEqual(int.Parse(inputTransactionIndex), result); 
                Assert.AreEqual("Select the transaction index : ", stringWriter.ToString()); 
            });
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
