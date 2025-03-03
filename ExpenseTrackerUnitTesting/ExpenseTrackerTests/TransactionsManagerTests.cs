using ExpenseTracker.ConsoleUI;
using ExpenseTracker.InputValidation;
using Moq;
using NUnit.Framework;
using ExpenseTracker.Model;

namespace ExpenseTrackerTests
{
    public class TransactionsManagerTests
    {
        private TransactionsManager _transactionsManager;
        private DataValidation _dataValidation;
        private Mock<InputManager> _mockInputManager;
        private OutputManager _outputManager;

        [SetUp]
        public void SetUp()
        {
            _dataValidation = new DataValidation();
            _mockInputManager = new Mock<InputManager>(_dataValidation);
            _outputManager = new OutputManager();
            _transactionsManager = new TransactionsManager(_mockInputManager.Object, _outputManager);
        }

        [TestCaseSource(nameof(TrackerListAddTestCasesForIncome))]
        [Test]
        public void AddTransaction_AddsNewTransactionAsIncome_ForValidIncomeDetails(List<Transaction> transactionList, DateOnly transactionDate, int transactionAmount, string incomeSource)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Income);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(transactionDate);
            _mockInputManager.Setup(i => i.GetTransactionAmount()).Returns(transactionAmount);
            _mockInputManager.Setup(i => i.GetIncomeSource()).Returns(incomeSource);

            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = _transactionsManager.transactionRepository().Count;

            //Act
            _transactionsManager.AddTransaction();

            //Assert
            Assert.AreEqual(listCount + 1, _transactionsManager.transactionRepository().Count);
        }

        private static IEnumerable<object> TrackerListAddTestCasesForIncome()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, DateOnly.Parse("12/12/12") , 1000, "Rent" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },DateOnly.Parse("01/12/2012") , 100000, "Salary" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },DateOnly.Parse("2/2/2") , 0, "Shop" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },DateOnly.Parse("12/2/2000") , 400, "Salary" },
            };
        }

        [TestCaseSource(nameof(TrackerListAddTestCasesForExpense))]
        [Test]
        public void AddTransaction_AddsNewTransactionAsExpense_ForValidExpenseDetails(List<Transaction> transactionList, DateOnly transactionDate, int transactionAmount, string expenseCategory)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Expense);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(transactionDate);
            _mockInputManager.Setup(i => i.GetTransactionAmount()).Returns(transactionAmount);
            _mockInputManager.Setup(i => i.GetExpenseCategory()).Returns(expenseCategory);

            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = _transactionsManager.transactionRepository().Count;

            //Act
            _transactionsManager.AddTransaction();

            //Assert
            Assert.AreEqual(listCount + 1, _transactionsManager.transactionRepository().Count);
        }

        private static IEnumerable<object> TrackerListAddTestCasesForExpense()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, DateOnly.Parse("12/12/12") , 1000, "Food" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },DateOnly.Parse("01/12/2012") , 100000, "Entertainment" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },DateOnly.Parse("2/2/2") , 0, "Shop" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },DateOnly.Parse("12/2/2000") , 400, "Cinema" },
            };
        }

        [TestCaseSource(nameof(TrackerListDeleteTestCases))]
        [Test]
        public void DeleteTransaction_DeletesTransaction_ForValidTransactionDetails(List<Transaction> transactionList, TransactionType transactionType, DateOnly transactionDate, int transactionIndex)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(transactionType);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(transactionDate);
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(transactionIndex);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = _transactionsManager.transactionRepository().Count;

            //Act
            _transactionsManager.DeleteTransaction();

            //Assert
            Assert.AreEqual(listCount - 1, _transactionsManager.transactionRepository().Count);
        }

        private static IEnumerable<object> TrackerListDeleteTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") },TransactionType.Income, DateOnly.Parse("12/12/2012"), 2 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") }, TransactionType.Expense, DateOnly.Parse("12/12/2012"), 1 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") }, TransactionType.Expense, DateOnly.Parse("1/1/1"), 3 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") }, TransactionType.Income, DateOnly.Parse("12/12/2012"), 1 },
            };
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesTransactionTypeFromIncomeToExpense_ForValidIncomeChosenAndExpenseCategoryGiven(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.SetupSequence(i => i.GetTransactionType()).Returns(TransactionType.Income).Returns(TransactionType.Expense);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(DateOnly.Parse("12/12/12"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionType);
            _mockInputManager.Setup(i => i.GetExpenseCategory()).Returns("Food");
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("EXPENSE", _transactionsManager.transactionRepository()[3].Type);
                Assert.AreEqual("Food", ((Expense)_transactionsManager.transactionRepository()[3]).Category);
            });
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesTransactionTypeFromExpenseToIncome_ForValidExpenseChosenAndIncomeSourceGiven(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.SetupSequence(i => i.GetTransactionType()).Returns(TransactionType.Expense).Returns(TransactionType.Income);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(DateOnly.Parse("1/1/1"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionType);
            _mockInputManager.Setup(i => i.GetIncomeSource()).Returns("Salary");
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("INCOME", _transactionsManager.transactionRepository()[2].Type);
                Assert.AreEqual("Salary", ((Income)_transactionsManager.transactionRepository()[2]).Source);
            });
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesTransactionAmount_ForValidInputTransactionAmount(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Expense);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(DateOnly.Parse("1/1/1"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionAmount);
            _mockInputManager.Setup(i => i.GetTransactionAmount()).Returns(700);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.AreEqual(700, _transactionsManager.transactionRepository()[2].Amount);
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesTransactionDate_ForValidInputTransactionDate(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Expense);
            _mockInputManager.SetupSequence(i => i.GetTransactionDate()).Returns(DateOnly.Parse("1/1/1")).Returns(DateOnly.Parse("12/12/12"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionDate);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.AreEqual(DateOnly.Parse("12/12/12"), _transactionsManager.transactionRepository()[2].DateOfTransaction);
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesIncomeSource_ForValidIncomeChosenAndValidIncomeSourceGiven(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Income);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(DateOnly.Parse("12/12/12"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionDetails);
            _mockInputManager.Setup(i => i.GetIncomeSource()).Returns("Shop");
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.AreEqual("Shop", ((Income) _transactionsManager.transactionRepository()[3]).Source);
        }

        [TestCaseSource(nameof(TrackerListEditTestCase))]
        [Test]
        public void ModifyTransaction_ModifiesExpenseCategory_ForValidExpenseChosenAndValidExpenseCategoryGiven(List<Transaction> transactionList)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(TransactionType.Expense);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(DateOnly.Parse("1/1/1"));
            _mockInputManager.Setup(i => i.GetTransactionIndex()).Returns(2);
            _mockInputManager.Setup(i => i.GetModifyChoice()).Returns(UserEditChoice.EditTransactionDetails);
            _mockInputManager.Setup(i => i.GetExpenseCategory()).Returns("Travel");
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            Assert.AreEqual("Travel",((Expense) _transactionsManager.transactionRepository()[2]).Category);
        }

        private static IEnumerable<object> TrackerListEditTestCase()
        {
            return new[]
            {
                new object[] { new List<Transaction> {new Income("INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") } }
            };
        }

        [TestCaseSource(nameof(TrackerListSummaryTestCases))]
        [Test]
        public void GetSummaryOfTransaction_PrintsTransactionSummary_ForValidTrackerList(List<Transaction> transactionList, string expectedTransactionSummary)
        {
            //Arrange
            var transactionSummary = new StringWriter();
            Console.SetOut(transactionSummary);
            _transactionsManager.transactionRepository().AddRange(transactionList);

            //Act
            _transactionsManager.GetSummaryOfTransaction();

            //Assert
            Assert.AreEqual(expectedTransactionSummary, transactionSummary.ToString());

        }

        private static IEnumerable<object> TrackerListSummaryTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") } , $"Total Income : 1300{Environment.NewLine}Total Expense : 1{Environment.NewLine}Net Balance : 1299{Environment.NewLine}"  },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") }, $"Total Income : 100{Environment.NewLine}Total Expense : 1{Environment.NewLine}Net Balance : 99{Environment.NewLine}" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") }, $"Total Income : 100{Environment.NewLine}Total Expense : 3{Environment.NewLine}Net Balance : 97{Environment.NewLine}" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") }, $"Total Income : 100{Environment.NewLine}Total Expense : 0{Environment.NewLine}Net Balance : 100{Environment.NewLine}" }
            };
        }

        [TestCaseSource(nameof(TrackerListSearchTestCases))]
        [Test]
        public void SearchTransaction_SearchesForSpecificTransactionsAndReturnsCountOfMatchingTransactions_ForTransactionDetails(List<Transaction> trackerList, TransactionType transactionType, DateOnly transactionDate, int numberOfMatchingChoices)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetTransactionType()).Returns(transactionType);
            _mockInputManager.Setup(i => i.GetTransactionDate()).Returns(transactionDate);
            _transactionsManager.transactionRepository().AddRange(trackerList);

            //Act
            int matchedChoicesCount = _transactionsManager.SearchTransaction();

            //Assert
            Assert.AreEqual(numberOfMatchingChoices, matchedChoicesCount);
        }

        private static IEnumerable<object> TrackerListSearchTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, TransactionType.Income, DateOnly.Parse("12/12/12"), 2 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") }, TransactionType.Expense, DateOnly.Parse("12/12/12"), 1 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") }, TransactionType.Expense, DateOnly.Parse("1/1/1"), 3 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") }, TransactionType.Expense, DateOnly.Parse("12/12/12"), 0 }
            };
        }

        [TestCaseSource(nameof(TrackerListEditToExpenseTestCases))]
        [Test]
        public void EditToExpense_EditsToExpense_ForTransactionIndexAndExpenseCategory(List<Transaction> trackerList, int transactionIndex)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetExpenseCategory()).Returns("Shop");
            _transactionsManager.transactionRepository().AddRange(trackerList);

            //Act
            _transactionsManager.EditToExpense(transactionIndex);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Shop", ((Expense)(_transactionsManager.transactionRepository()[transactionIndex])).Category);
                Assert.IsTrue(_transactionsManager.transactionRepository()[transactionIndex] is Expense);
            });
        }

        private static IEnumerable<object> TrackerListEditToExpenseTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, 0  },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") }, 0 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") }, 0 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") }, 0 }
            };
        }

        [TestCaseSource(nameof(TrackerListEditToIncomeTestCases))]
        [Test]
        public void EditToIncome_EditsToIncome_ForTransactionIndexAndIncomeSource(List<Transaction> trackerList, int transactionIndex)
        {
            //Arrange
            _mockInputManager.Setup(i => i.GetIncomeSource()).Returns("Salary");
            _transactionsManager.transactionRepository().AddRange(trackerList);

            //Act
            _transactionsManager.EditToIncome(transactionIndex);

            //Assert
            {
                Assert.AreEqual("Salary", ((Income)(_transactionsManager.transactionRepository()[transactionIndex])).Source);
                Assert.IsTrue(_transactionsManager.transactionRepository()[transactionIndex] is Income);
            }
        }

        private static IEnumerable<object> TrackerListEditToIncomeTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, 1  },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") }, 1 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") }, 3 },
                new object[] {new List<Transaction> { new Income ( "EXPENSE", 100, DateOnly.Parse("12/12/12"), "SHOP") }, 0 }
            };
        }
    }
}
