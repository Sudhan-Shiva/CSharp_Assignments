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

        [SetUp]
        public void SetUp()
        {
            Mock<DataValidation> dataValidation = new Mock<DataValidation>();
            Mock<InputManager> mockInputManager = new Mock<InputManager>(dataValidation.Object);
            Mock<OutputManager> mockOutputManager = new Mock<OutputManager>();
            _transactionsManager = new TransactionsManager(mockInputManager.Object, mockOutputManager.Object);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(TrackerListAddTestCases))]
        [Test]
        public void AddTransaction_ShallAddNewTransaction_WhenNewTransactionDetailsGiven(List<Transaction> transactionList, StringReader stringReader, int transactionType)
        {
            //Arrange
            Console.SetIn(stringReader);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.AddTransaction();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue((transactionType == 0) ? (_transactionsManager.transactionRepository()[listCount] is Income) : (_transactionsManager.transactionRepository()[listCount] is Expense));
                Assert.AreEqual(listCount+1, _transactionsManager.transactionRepository().Count);
            });
        }

        private static IEnumerable<object> TrackerListAddTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, new StringReader("0\n12\n12/12/12\nSalary"), 0 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },new StringReader("1\n1000\n1/1/1\nFood"), 1 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },new StringReader("0\n120\n1/1/2012\nRent"), 0 },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },new StringReader("1\n999\n02/12/2002\nMovie"), 1 },
            };
        }

        [TestCaseSource(nameof(TrackerListDeleteTestCases))]
        [Test]
        public void DeleteTransaction_ShallDeleteTransaction_WhenTransactionDetailsGiven(List<Transaction> transactionList, StringReader stringReader)
        {
            //Arrange
            Console.SetIn(stringReader);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.DeleteTransaction();

            //Assert
            Assert.AreEqual(listCount - 1, _transactionsManager.transactionRepository().Count);

        }

        private static IEnumerable<object> TrackerListDeleteTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, new StringReader("0\n12/12/12\n2") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") },new StringReader("1\n12/12/12\n1") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },new StringReader("1\n01/1/2001\n3") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },new StringReader("0\n12/12/2012\n1") },
            };
        }

        [TestCaseSource(nameof(TrackerListEditTestCases))]
        [Test]
        public void ModifyTransaction_ShallModifyTransaction_WhenEditingDetailsGiven(List<Transaction> transactionList, StringReader stringReader, int inputIndex, int editField, string editedField)
        {
            //Arrange
            Console.SetIn(stringReader);
            _transactionsManager.transactionRepository().AddRange(transactionList);
            int listCount = transactionList.Count;

            //Act
            _transactionsManager.ModifyTransaction();

            //Assert
            if(editField == 0)
            {
                Assert.AreEqual(editedField, _transactionsManager.transactionRepository()[inputIndex].Type);
            }
            else if (editField == 1)
            {
                Assert.AreEqual(int.Parse(editedField), _transactionsManager.transactionRepository()[inputIndex].Amount);
            }
            else if (editField == 2)
            {
                Assert.AreEqual(DateOnly.Parse(editedField), _transactionsManager.transactionRepository()[inputIndex].DateOfTransaction);
            }
            else if (editField == 3)
            {
                if (_transactionsManager.transactionRepository()[inputIndex] is Income income)
                {
                    Assert.AreEqual(editedField, income.Source);
                }
                else if (_transactionsManager.transactionRepository()[inputIndex] is Expense expense)
                {
                    Assert.AreEqual(editedField, expense.Category);
                }
            }
        }

        private static IEnumerable<object> TrackerListEditTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, new StringReader("0\n12/12/12\n2\n1\n1000") , 2, 1, "1000"},
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") },new StringReader("1\n12/12/12\n1\n0\n0\nBONUS") , 1, 0 , "INCOME"},
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },new StringReader("1\n1/1/1\n3\n2\n12/12/12"), 3, 2, "12/12/12" },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },new StringReader("0\n12/12/2012\n1\n3\nSHOP RENT"), 0, 3, "SHOP RENT" },
            };
        }

        [TestCaseSource(nameof(TrackerListSummaryTestCases))]
        [Test]
        public void GetSummaryOfTransaction_ShallPrintTransactionSummary_WhenTrackerListIsGiven(List<Transaction> transactionList, string expectedTransactionSummary)
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
        public void SearchTransaction_ShallSearchForSpecificTransaction_WhenTransactionDetailsGiven(List<Transaction> trackerList, StringReader stringReader)
        {
            //Arrange
            Console.SetIn(stringReader);

            //Act
            _transactionsManager.transactionRepository().AddRange(trackerList);

            //Assert
            Assert.DoesNotThrow(() => _transactionsManager.SearchTransaction());
        }

        private static IEnumerable<object> TrackerListSearchTestCases()
        {
            return new[]
            {
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Income("INCOME", 1200, DateOnly.Parse("12/12/2012"), "RENT") }, new StringReader("0\n12/12/12") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("12/12/12"), "FOOD") },new StringReader("1\n12/12/12") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD"), new Expense("EXPENSE", 1, DateOnly.Parse("1/1/1"), "FOOD") },new StringReader("1\n01/1/2001") },
                new object[] {new List<Transaction> { new Income ( "INCOME", 100, DateOnly.Parse("12/12/12"), "SALARY") },new StringReader("0\n12/12/2012") },
            };
        }
    }
}
