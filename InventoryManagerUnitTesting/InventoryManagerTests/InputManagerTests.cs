using NUnit.Framework;
using InventoryManager.InputValidation;
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
            DataValidation dataValidation = new DataValidation();
            inputManager = new InputManager(dataValidation);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(GetUserOptionsTestCases))]
        [Test]
        public void GetUserOptions_ReturnsUserOptionAsInt_ForIntegerInputBetween0And6(StringReader inputUserOptions)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputUserOptions);

            //Act
            int result = inputManager.GetUserOptions();
            var consoleOutput = stringWriter.ToString();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 6));
                Assert.AreEqual(consoleOutput, $"\nHello!\nWhat do you want to do?\n[0] {ApplicationOptions.ViewProducts}\n[1] {ApplicationOptions.AddProduct}\n[2] {ApplicationOptions.DeleteProduct}\n[3] {ApplicationOptions.EditProduct}\n[4] {ApplicationOptions.SearchProduct}\n[5] {ApplicationOptions.SortProducts}\n[6] {ApplicationOptions.Exit}\nType your Choice: ");
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
        public void GetEditField_ReturnsEditFieldAsInt_ForIntegerInputBetween0And3(StringReader inputEditField)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputEditField);

            //Act
            int result = inputManager.GetEditField();
            var consoleOutput = stringWriter.ToString();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.True((result>=0) && (result<=3));    
                Assert.AreEqual(consoleOutput, $"Choose the Information that must be edited : \n[0] {UserEditChoice.EditProductName}\n[1] {UserEditChoice.EditProductId}\n[2] {UserEditChoice.EditProductPrice}\n[3] {UserEditChoice.EditProductQuantity} \nType your Choice: ");
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
        public void GetActionField_ReturnsActionFieldAsInt_ForIntegerInputAs1Or0(StringReader inputActionField)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(inputActionField);

            //Act
            int result = inputManager.GetActionField();
            var consoleOutput = stringWriter.ToString();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.True((result >= 0) && (result <= 1));
                Assert.AreEqual(consoleOutput, $"[0] {NameOrIdChoice.ByName}\n[1] {NameOrIdChoice.ById}\nPerform the action by Name or ID : ");
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
        public void GetUniqueProductName_ReturnsInputString_ForValidString(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetUniqueProductName();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
            Assert.AreEqual(ConsoleOutput, "The Product Name is Already Present !\nGive a new Product name : ");
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void ReplaceInvalidInput_ReturnsInputString_ForValidString(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.ReplaceInvalidInput();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
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
        public void GetUniqueProductId_ReturnsInputStringAsInt_ForValidInputInteger(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetUniqueProductId();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
            Assert.AreEqual(ConsoleOutput, "The Product ID is Already Present !\nGive a new Product ID : ");
        }

        [TestCaseSource(nameof(InputManagerStringMethodsTestCases))]
        [Test]
        public void GetProductName_ReturnsInputString_ForValidInputString(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetProductName();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
            Assert.AreEqual(ConsoleOutput, "Enter the Product Name :  ");
        }

        [TestCaseSource(nameof(InputManagerIntegerMethodsTestCases))]
        [Test]
        public void GetProductId_ReturnsInputStringAsInt_ForValidInputInteger(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetProductId();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
            Assert.AreEqual(ConsoleOutput, "Enter the Product ID :  ");
        }

        [TestCaseSource(nameof(GetProductPriceTestCases))]
        [Test]
        public void GetProductPrice_ReturnsInputStringAsDecimal_ForValidInputDecimal(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            var result = inputManager.GetProductPrice();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
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
        public void GetProductQuantity_ReturnsInputStringAsInt_ForValidInputInteger(StringReader stringReader)
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetProductQuantity();
            string ConsoleOutput = stringWriter.ToString();

            //Assert
            Assert.AreEqual(ConsoleOutput, "Enter the Product Quantity :  ");
        }
        [TestCaseSource(nameof(GetValidIntegerTestCases))]
        [Test]
        public void GetValidInteger_ReturnsInputStringAsInteger_ForValidInputInteger(StringReader stringReader, int expectedResult)
        {
            //Arrange
            Console.SetIn(stringReader);

            //Act
            int result = inputManager.GetValidInteger(Console.ReadLine());

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

        [TestCaseSource(nameof(GetValidDecimalTestCases))]
        [Test]
        public void GetValidDate_ReturnsInputStringAsDecimal_ForValidInputDecimal(StringReader stringReader, decimal expectedResult)
        {
            //Arrange
            Console.SetIn(stringReader);

            //Act
            decimal result = inputManager.GetValidDecimal(Console.ReadLine());

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object> GetValidDecimalTestCases()
        {
            return new[]
            {
                new object[] { new StringReader("a\nab12\n11.23") , decimal.Parse("11.23")},
                new object[] { new StringReader("a\na\n*abc\n12") , decimal.Parse("12")},
                new object[] { new StringReader("12.234455") , decimal.Parse("12.234455")},
                new object[] { new StringReader("ac23\nsd\n0") , decimal.Parse("0")},
            };
        }

        [TestCaseSource(nameof(GetValidInputTestCases))]
        [Test]
        public void GetValidInput_ReturnsInputString_ForValidInputString(StringReader stringReader, string expectedResult)
        {
            //Arrange
            Console.SetIn(stringReader);
            //Act
            string result = inputManager.GetValidInput(Console.ReadLine());
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<object> GetValidInputTestCases()
        {
            return new[]
            {
                new object[] { new StringReader($"{null}\n\n123") , "123"},
                new object[] { new StringReader("Hi") , "Hi"},
                new object[] { new StringReader($"{null}\n{null}\n{null}789") , "789"},
                new object[] { new StringReader("\n\n100") , "100"},
            };
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
