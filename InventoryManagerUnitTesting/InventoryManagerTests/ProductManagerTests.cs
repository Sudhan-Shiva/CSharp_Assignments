using Moq;
using InventoryManager.Model;
using InventoryManager.UserInterface;
using NUnit.Framework;
using InventoryManager.Utility;
using InventoryManager.InputValidation;

namespace InventoryManagerTests
{
    public class ProductManagerTests
    {
        private ProductManager _productManager;
        private List<Product> _productList;
        private Mock<InputManager> _mockInputManager;
        private OutputManager _outputManager;
        int listCount;

        [SetUp]
        public void SetUp()
        {
            DataValidation dataValidation = new DataValidation();
            _mockInputManager = new Mock<InputManager>(dataValidation);
            _outputManager = new OutputManager();
            List<Product> _productList = new List<Product>();
            _productManager = new ProductManager(_mockInputManager.Object, _outputManager);
            listCount = 0;
        }

        [TestCaseSource(nameof(ProductListTestCases))]
        [Test]
        public void AddProduct_ShallAddNewProduct_WhenNewProductDetailsGiven(List<Product> productList)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductName()).Returns("BOILER");
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductPrice()).Returns(5);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductQuantity()).Returns(700);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductId()).Returns(21);

            _productManager.productRepository().AddRange(productList);
            listCount = _productManager.productRepository().Count + 1;

            //Act
            _productManager.AddProduct();

            //Assert
            Assert.AreEqual(listCount, _productManager.productRepository().Count);
        }

        [TestCaseSource(nameof(ProductListTestCases))]
        [Test]
        public void DeleteProduct_ShallDeleteProduct_WhenProductNameGiven(List<Product> productList)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductName()).Returns("BANANA");

            _productManager.productRepository().AddRange(productList);
            listCount = _productManager.productRepository().Count - 1;

            //Act
            _productManager.DeleteProduct();

            //Assert
            Assert.AreEqual(listCount, _productManager.productRepository().Count);
        }

        private static IEnumerable<List<Product>> ProductListTestCases()
        {
            yield return new List<Product> { new Product(1, "BANANA", 2, 3), new Product(2, "APPLE", 20, 31), new Product(3, "TOMATO", 200, 39), new Product(4, "POTATO", 400, 30) };
            yield return new List<Product> { new Product(1, "BANANA", 2, 3), new Product(2, "APPLE", 20, 31), new Product(3, "TOMATO", 200, 39), new Product(4, "POTATO", 400, 30) };
            yield return new List<Product> { new Product(1, "BANANA", 2, 3), new Product(2, "CARROT", 20, 31) };
            yield return new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "CARROT", 20, 31) };
        }

        [TestCaseSource(nameof(ProductListEditTestCasesForProductName))]
        [Test]
        public void ModifyProduct_EditsProductName_ForNewInputProductName(List<Product> productList, string oldProductName, string editedProductName, int productIndex)
        {
            //Arrange
            _mockInputManager.SetupSequence(_mockInputManager => _mockInputManager.GetProductName()).Returns(oldProductName).Returns(editedProductName);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetEditField()).Returns(0);
            
            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.ModifyProduct();

            //Assert
            Assert.AreEqual(editedProductName, _productManager.productRepository()[productIndex].ProductName);
        }

        private static IEnumerable<object> ProductListEditTestCasesForProductName()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(10,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE", "PEAR", 1},
               new object[] {new List<Product> { new Product(11,"DOG",2,3) , new Product(2, "CAT", 20, 31) , new Product(3, "MOUSE", 200, 39) , new Product(4, "COW", 400, 30) } , "COW", "HORSE", 3},
               new object[] {new List<Product> { new Product(12,"BRINJAL",2,3) , new Product(2, "CARROT", 20, 31) }, "CARROT", "TOMATO", 1},
               new object[] {new List<Product> { new Product(13,"FROG",2,3) , new Product(2, "GOAT", 20, 31) }, "GOAT", "BOAT", 1}
            };
        }

        [TestCaseSource(nameof(ProductListEditTestCasesForProductId))]
        [Test]
        public void ModifyProduct_EditsProductId_ForNewInputProductId(List<Product> productList, string productName, int editedProductId, int productIndex)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductName()).Returns(productName);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetEditField()).Returns(1);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductId()).Returns(editedProductId);

            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.ModifyProduct();

            //Assert
            Assert.AreEqual(editedProductId, _productManager.productRepository()[productIndex].ProductId);
        }

        private static IEnumerable<object> ProductListEditTestCasesForProductId()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(10,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE", 77, 1},
               new object[] {new List<Product> { new Product(11,"DOG",2,3) , new Product(2, "CAT", 20, 31) , new Product(3, "MOUSE", 200, 39) , new Product(4, "COW", 400, 30) } , "COW", 89, 3},
               new object[] {new List<Product> { new Product(12,"BRINJAL",2,3) , new Product(2, "CARROT", 20, 31) }, "CARROT", 1000, 1},
               new object[] {new List<Product> { new Product(13,"FROG",2,3) , new Product(2, "GOAT", 20, 31) }, "GOAT", 10, 1}
            };
        }

        [TestCaseSource(nameof(ProductListEditTestCasesForProductPrice))]
        [Test]
        public void ModifyProduct_EditsProductPrice_ForNewInputProductPrice(List<Product> productList, string productName, decimal editedProductPrice, int productIndex)
        {
            //Arrange
            _mockInputManager.SetupSequence(_mockInputManager => _mockInputManager.GetProductName()).Returns(productName);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetEditField()).Returns(2);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductPrice()).Returns(editedProductPrice);

            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.ModifyProduct();

            //Assert
            Assert.AreEqual(editedProductPrice, _productManager.productRepository()[productIndex].ProductPrice);
        }

        private static IEnumerable<object> ProductListEditTestCasesForProductPrice()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(10,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE", (decimal) 76.12, 1},
               new object[] {new List<Product> { new Product(11,"DOG",2,3) , new Product(2, "CAT", 20, 31) , new Product(3, "MOUSE", 200, 39) , new Product(4, "COW", 400, 30) } , "COW", (decimal) 21.09, 3},
               new object[] {new List<Product> { new Product(12,"BRINJAL",2,3) , new Product(2, "CARROT", 20, 31) }, "CARROT", (decimal) 11, 1},
               new object[] {new List<Product> { new Product(13,"FROG",2,3) , new Product(2, "GOAT", 20, 31) }, "GOAT", (decimal) 1234.1234, 1}
            };
        }

        [TestCaseSource(nameof(ProductListEditTestCasesForProductQuantity))]
        [Test]
        public void ModifyProduct_EditsProductQuantity_ForNewInputProductQuantity(List<Product> productList, string productName, int editedProductQuantity, int productIndex)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductName()).Returns(productName);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetEditField()).Returns(3);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductQuantity()).Returns(editedProductQuantity);

            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.ModifyProduct();

            //Assert
            Assert.AreEqual(editedProductQuantity, _productManager.productRepository()[productIndex].ProductQuantity);
        }

        private static IEnumerable<object> ProductListEditTestCasesForProductQuantity()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(10,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE", 23, 1},
               new object[] {new List<Product> { new Product(11,"DOG",2,3) , new Product(2, "CAT", 20, 31) , new Product(3, "MOUSE", 200, 39) , new Product(4, "COW", 400, 30) } , "COW", 78, 3},
               new object[] {new List<Product> { new Product(12,"BRINJAL",2,3) , new Product(2, "CARROT", 20, 31) }, "CARROT", 123, 1},
               new object[] {new List<Product> { new Product(13,"FROG",2,3) , new Product(2, "GOAT", 20, 31) }, "GOAT", 90, 1}
            };
        }

        [TestCaseSource(nameof(ProductListSortTestCasesForProductName))]
        [Test]
        public void SortProduct_SortsProductListAccordingToProductName_ForInputActionFieldAs0(List<Product> productList, string firstProductName)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetActionField()).Returns(0);

            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.SortProduct();

            //Assert
            Assert.AreEqual(firstProductName, _productManager.productRepository()[0].ProductName);
        }

        private static IEnumerable<object> ProductListSortTestCasesForProductName()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } ,"APE"},
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE"},
               new object[] {new List<Product> { new Product(1,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) } , "BAMBOO"},
               new object[] {new List<Product> { new Product(2,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) } , "BANANA"},
            };
        }

        [TestCaseSource(nameof(ProductListSortTestCasesForProductId))]
        [Test]
        public void SortProduct_SortsProductListAccordingToProductId_ForInputActionFieldAs1(List<Product> productList, string firstProductName)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetActionField()).Returns(1);

            _productManager.productRepository().AddRange(productList);

            //Act
            _productManager.SortProduct();

            //Assert
            Assert.AreEqual(firstProductName, _productManager.productRepository()[0].ProductName);
        }

        private static IEnumerable<object> ProductListSortTestCasesForProductId()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } ,"ZEBRA"},
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "BANANA"},
               new object[] {new List<Product> { new Product(1,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) } , "BAMBOO"},
               new object[] {new List<Product> { new Product(2,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) } , "CARROT"},
            };
        }

        [TestCaseSource(nameof(ProductListSearchTestCasesByProductName))]
        [Test]
        public void SearchProduct_SearchesForSpecificProduct_ForInputAsPartialProductName(List<Product> productList, string productName, int matchingProductsCount)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetActionField()).Returns(0);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductName()).Returns(productName);

            _productManager.productRepository().AddRange(productList);

            //Act
            int numberOfMatches = _productManager.SearchProduct();

            //Assert
            Assert.AreEqual(matchingProductsCount, numberOfMatches);
        }
        private static IEnumerable<object> ProductListSearchTestCasesByProductName()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , "A", 3 },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "TO", 2 },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, "X", 0 },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, "M", 1 },
            };
        }

        [TestCaseSource(nameof(ProductListSearchTestCasesByProductId))]
        [Test]
        public void SearchProduct_SearchesForSpecificProductByProductId_ForInputAsProductId(List<Product> productList, int productId, int matchingProductsCount)
        {
            //Arrange
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetActionField()).Returns(1);
            _mockInputManager.Setup(_mockInputManager => _mockInputManager.GetProductId()).Returns(productId);

            _productManager.productRepository().AddRange(productList);

            //Act
            int numberOfMatches = _productManager.SearchProduct();

            //Assert
            Assert.AreEqual(matchingProductsCount, numberOfMatches);
        }
        private static IEnumerable<object> ProductListSearchTestCasesByProductId()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , 40, 0 },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , 3, 1 },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, 999, 0 },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, 29, 1 },
            };
        }

        [TestCaseSource(nameof(ReturnValidIndexTestCases))]
        [Test]
        public void ReturnValidIndex_ReturnsValidIndex_ForInputProductListAndProductIndex(List<Product> productList, string initialSearchName, StringReader stringReader, int expectedIndex)
        {
            //Arrange
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);

            //Act
            int actualIndex = _productManager.ReturnValidIndex(initialSearchName);

            //Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        private static IEnumerable<object> ReturnValidIndexTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , "ZOMATO", new StringReader("a\nAS\nPOTATO"), 3 },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "3", new StringReader("TOMATO"), 2 },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, "none", new StringReader("BAMBOO"), 0 },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, "Peas", new StringReader("q\nqw\nCARROT") , 1},
            };
        }

        [TestCaseSource(nameof(GetDistinctProductNameTestCases))]
        [Test]
        public void GetDistinctProductName_ReturnsDistinctProductName_ForInputProductList(List<Product> productList, string initialProductName, StringReader stringReader, string expectedProductName)
        {
            //Arrange
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);

            //Act
            string actualDistinctProductName = _productManager.GetDistinctProductName(initialProductName);

            //Assert
            Assert.AreEqual(expectedProductName, actualDistinctProductName);
        }

        private static IEnumerable<object> GetDistinctProductNameTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , "ZEBRA", new StringReader("APE\nPOTATO\nANIMAL"), "ANIMAL" },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , "APPLE", new StringReader("BANANA\nTOMATO\nZOMATO"), "ZOMATO" },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, "BAMBOO", new StringReader("CUCKOO\nBIRD"), "BIRD" },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, "BANANA", new StringReader("CARROT\nBIRD"), "BIRD" },
            };
        }

        [TestCaseSource(nameof(GetDistinctProductIdTestCases))]
        [Test]
        public void GetDistinctProductId_ReturnsDistinctProductId_ForInputProductList(List<Product> productList, int initialProductId, StringReader stringReader, int expectedProductId)
        {
            //Arrange
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);

            //Act
            int actualDistinctProductId = _productManager.GetDistinctProductId(initialProductId);

            //Assert
            Assert.AreEqual(expectedProductId, actualDistinctProductId);
        }

        private static IEnumerable<object> GetDistinctProductIdTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , 1, new StringReader("2\n3\n7"), 7 },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , 2, new StringReader("1\n3\n4\n5"), 5 },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, 19, new StringReader("2\n3"), 3 },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, 29, new StringReader("1\n2"), 2 },
            };
        }
    }
}
