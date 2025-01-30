using NUnit.Framework;
using InventoryManager.InputValidation;
using Moq;
using InventoryManager.UserInterface;
using InventoryManager.Model;

namespace InventoryManagerTests
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

        [TestCaseSource(nameof(GetUserOptionsTestCases))]
        [Test]
        public void GetUserOptions_ShallReturnInput_IfInputIsBetween0And6(StringReader inputUserOptions)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputUserOptions);
            int result = inputManager.GetUserOptions();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 6));
                Assert.AreEqual(consoleOuput, $"\nHello!\nWhat do you want to do?\n[0] {ApplicationOptions.ViewProducts}\n[1] {ApplicationOptions.AddProduct}\n[2] {ApplicationOptions.DeleteProduct}\n[3] {ApplicationOptions.EditProduct}\n[4] {ApplicationOptions.SearchProduct}\n[5] {ApplicationOptions.SortProducts}\n[6] {ApplicationOptions.Exit}\nType your Choice: ");
            });
        }

        private static IEnumerable<object> GetUserOptionsTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("3") },
             new object[] { new StringReader("2") },
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") },
             new object[] { new StringReader("6") },
             new object[] { new StringReader("5") },
            };
        }

        [TestCaseSource (nameof(GetEditFieldTestCases))]
        [Test]
        public void GetEditField_ShallReturnInput_IfInputIsBetween0And3(StringReader inputEditField)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputEditField);
            int result = inputManager.GetEditField();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result>=0) && (result<=3));    
                Assert.AreEqual(consoleOuput, $"Choose the Information that must be edited : \n[0] {UserEditChoice.EditProductName}\n[1] {UserEditChoice.EditProductId}\n[2] {UserEditChoice.EditProductPrice}\n[3] {UserEditChoice.EditProductQuantity} \nType your Choice: ");
            });
        }

        private static IEnumerable<object> GetEditFieldTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("3") },
             new object[] { new StringReader("2") },
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") }

            };
        }

        [TestCaseSource(nameof(GetActionFieldTestCases))]
        [Test]
        public void GetActionField_ShallReturnInput_IfInputIsBetween0And1(StringReader inputActionField)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputActionField);
            int result = inputManager.GetActionField();
            var consoleOuput = stringWriter.ToString();
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 1));
                Assert.AreEqual(consoleOuput, $"[0] {NameOrIdChoice.ByName}\n[1] {NameOrIdChoice.ById}\nPerform the action by Name or ID : ");
            });
        }

        private static IEnumerable<object> GetActionFieldTestCases()
        {
            return new[]
            {
             new object[] { new StringReader("0") },
             new object[] { new StringReader("1") }
            };
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetUniqueProductName_ShallReturnInput_IfInputGiven(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.GetUniqueProductName();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "The Product Name is Already Present !\nGive a new Product name : ");
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void ReplaceInvalidInput_ShallReturnInput_IfInputGiven(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.ReplaceInvalidInput();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "The Provided input is invalid !!\nProvide the Input again :");
        }

        private static IEnumerable<object> InputManagerStringMethodsTestCases()
        {
            return new[]
            {
                new object[] { new StringReader("Hi") },
                new object[] { new StringReader("Welcome") },
                new object[] { new StringReader("0000") },
                new object[] { new StringReader("123abc") }
            };
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetUniqueProductId_ShallReturnInput_IfInputGivenIsInt(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.GetUniqueProductId();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "The Product ID is Already Present !\nGive a new Product ID : ");
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetProductName_ShallReturnInput_IfInputGiven(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.GetProductName();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "Enter the Product Name :  ");
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetProductId_ShallReturnInput_IfInputGivenIsInt(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.GetProductId();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "Enter the Product ID :  ");
        }

        [TestCaseSource(nameof(GetProductPriceTestCases))]
        [Test]
        public void GetProductPrice_ShallReturnInput_IfInputGivenIsDecimal(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            var result = inputManager.GetProductPrice();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "Enter the Product Price :  ");
        }

        private static IEnumerable<object> GetProductPriceTestCases()
        {
            return new[]
            {
                new object[] {new StringReader("54.34") },
                new object[] {new StringReader("0.0000000") },
                new object[] {new StringReader("5") },
                new object[] {new StringReader("12") }
            };
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetProductQuantity_ShallReturnInput_IfInputGivenIsInt(StringReader stringReader)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);
            int result = inputManager.GetProductQuantity();
            string ConsoleOutput = stringWriter.ToString();
            Assert.AreEqual(ConsoleOutput, "Enter the Product Quantity :  ");
        }

        private static IEnumerable<object> InputManagerIntegerMethodsTestCases()
        {
            return new[]
            {
                new object[] { new StringReader("3")},
                new object[] { new StringReader("90234")},
                new object[] { new StringReader("0000")},
                new object[] { new StringReader("1230987")}
            };
        }
    }
}
