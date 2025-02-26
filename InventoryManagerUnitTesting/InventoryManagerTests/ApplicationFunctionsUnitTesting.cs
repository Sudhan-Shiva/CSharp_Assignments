using InventoryManager.InputValidation;
using InventoryManager.UserInterface;
using InventoryManager.Utility;
using Moq;
using NUnit.Framework;

namespace InventoryManagerTests
{
    internal class ApplicationFunctionsUnitTesting
    {
        private Mock<ProductManager> _mockProductManager;
        private ApplicationFunction _applicationFunction;
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private DataValidation _dataValidation;

        [SetUp]
        public void Setup()
        {
            _dataValidation = new DataValidation();
            _inputManager = new InputManager(_dataValidation);
            _outputManager = new OutputManager();
            _mockProductManager = new Mock<ProductManager>(_inputManager, _outputManager);
            _applicationFunction = new ApplicationFunction(_mockProductManager.Object);
        }

        [Test]
        public void AppFunctions_CallsViewProductMethod_ForIntegerInput0()
        {
            //Act
            _applicationFunction.AppFunctions(0);

            //Assert
            _mockProductManager.Verify(x => x.ViewProduct(), Times.Once);
        }

        [Test]
        public void AppFunctions_CallsAddProductMethod_ForIntegerInput1()
        {
            //Act
            _applicationFunction.AppFunctions(1);

            //Assert
            _mockProductManager.Verify(x => x.AddProduct(), Times.Once);
        }

        [Test]
        public void AppFunctions_CallsDeleteProductMethod_ForIntegerInput2()
        {
            //Act
            _applicationFunction.AppFunctions(2);

            //Assert
            _mockProductManager.Verify(x => x.DeleteProduct(), Times.Once);
        }

        [Test]
        public void AppFunctions_CallsModifyProductMethod_ForIntegerInput3()
        {
            //Act
            _applicationFunction.AppFunctions(3);

            //Assert
            _mockProductManager.Verify(x => x.ModifyProduct(), Times.Once);
        }

        [Test]
        public void AppFunctions_CallsSearchProductMethod_ForIntegerInput4()
        {
            //Act
            _applicationFunction.AppFunctions(4);

            //Assert
            _mockProductManager.Verify(x => x.SearchProduct(), Times.Once);
        }

        [Test]
        public void AppFunctions_CallsSortProductMethod_ForIntegerInput5()
        {
            //Act
            _applicationFunction.AppFunctions(5);

            //Assert
            _mockProductManager.Verify(x => x.SortProduct(), Times.Once);
        }
    }
}
