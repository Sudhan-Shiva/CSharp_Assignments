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
        int listCount;

        [SetUp]
        public void SetUp()
        {
            Mock<DataValidation> dataValidation = new Mock<DataValidation>();
            Mock<InputManager> mockInputManager = new Mock<InputManager>(dataValidation.Object);
            Mock<OutputManager>  mockOutputManager = new Mock<OutputManager>();
            List<Product> _productList = new List<Product>();
            _productManager = new ProductManager(mockInputManager.Object, mockOutputManager.Object);
            listCount = 0;
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(ProductListAddTestCases))]
        [Test]
        public void AddProduct_ShallAddNewProduct_WhenNewProductDetailsGiven(StringReader stringReader)
        {
            Console.SetIn(stringReader);
            _productManager.AddProduct();
            listCount++;
            Assert.AreEqual(listCount, _productManager.productRepository().Count);
        }

        private static IEnumerable<object> ProductListAddTestCases()
        {
            return new[]
            {
               new object[] { new StringReader ("CARROT\n5\n700\n21") },
               new object[] { new StringReader ("RADISH\n45\n89\n45") },
               new object[] {  new StringReader ("BEETROOT\n20\n9003\n2781") },
               new object[] {  new StringReader ("TOMATO\n60\n90\n27") },
               new object[] {  new StringReader ("POTATO\n30\n3\n81") },
            };
        }

        [TestCaseSource(nameof(ProductListDeleteTestCases))]
        [Test]
        public void DeleteProduct_ShallDeleteProduct_WhenProductNameGiven(List<Product> productList, StringReader stringReader)
        {
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);
            listCount = _productManager.productRepository().Count - 1;
            _productManager.DeleteProduct();
            Assert.AreEqual(listCount, _productManager.productRepository().Count);
        }

        private static IEnumerable<object> ProductListDeleteTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("APPLE")},
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("POTATO")},
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "CARROT", 20, 31) }, new StringReader("CARROT") },
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "CARROT", 20, 31) }, new StringReader("BANANA") },
            };
        }

        [TestCaseSource(nameof(ProductListEditTestCases))]
        [Test]
        public void ModifyProduct_ShallEditProduct_WhenEditFieldGiven(List<Product> productList, StringReader editDetails, int productIndex, string editedName, int userEditChoice)
        {
            Console.SetIn(editDetails);
            _productManager.productRepository().AddRange(productList);
            _productManager.ModifyProduct();
            if (userEditChoice == 0)
            {
                Assert.AreEqual(_productManager.productRepository()[productIndex].ProductName, editedName);
            }
            else if (userEditChoice == 1)
            {
                Assert.AreEqual(_productManager.productRepository()[productIndex].ProductId, int.Parse(editedName));
            }
            else if (userEditChoice == 2)
            {
                Assert.AreEqual(_productManager.productRepository()[productIndex].ProductPrice, decimal.Parse(editedName));
            }
            else if (userEditChoice == 3)
            {
                Assert.AreEqual(_productManager.productRepository()[productIndex].ProductQuantity, int.Parse(editedName));
            }

        }

        private static IEnumerable<object> ProductListEditTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(10,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("APPLE\n0\nPEAR"), 1, "PEAR", 0},
               new object[] {new List<Product> { new Product(11,"DOG",2,3) , new Product(2, "CAT", 20, 31) , new Product(3, "MOUSE", 200, 39) , new Product(4, "COW", 400, 30) } , new StringReader ("COW\n1\n81"), 3, "81", 1},
               new object[] {new List<Product> { new Product(12,"BRINJAL",2,3) , new Product(2, "CARROT", 20, 31) }, new StringReader("CARROT\n2\n21.5"), 1 , "21.5", 2},
               new object[] {new List<Product> { new Product(13,"FROG",2,3) , new Product(2, "GOAT", 20, 31) }, new StringReader("GOAT\n3\n21"), 1 , "21", 3}
            };
        }

        [TestCaseSource(nameof(ProductListSortTestCases))]
        [Test]
        public void SortProduct_ShallSortProductList_WhenSortFieldGiven(List<Product> productList, StringReader stringReader, string firstProductName)
        {
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);
            _productManager.SortProduct();
            Assert.AreEqual(firstProductName, _productManager.productRepository()[0].ProductName);
        }

        private static IEnumerable<object> ProductListSortTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("0"), "APE"},
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("1"), "BANANA"},
               new object[] {new List<Product> { new Product(1,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, new StringReader("0") , "BAMBOO"},
               new object[] {new List<Product> { new Product(2,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, new StringReader("1") , "CARROT"},
            };
        }

        [TestCaseSource(nameof(ProductListSearchTestCases))]
        [Test]
        public void SearchProduct_ShallSearchForSpecificProduct_WhenProductDetailsGiven(List<Product> productList, StringReader stringReader)
        {
            Console.SetIn(stringReader);
            _productManager.productRepository().AddRange(productList);
            Assert.DoesNotThrow(() => _productManager.SearchProduct());
        }

        private static IEnumerable<object> ProductListSearchTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"ZEBRA",2,3) , new Product(2, "APE", 20, 31) , new Product(3, "TIGER", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("0\nA") },
               new object[] {new List<Product> { new Product(2,"APPLE", 20, 31), new Product(1,"BANANA",2,3)  , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } , new StringReader ("0\nTO") },
               new object[] {new List<Product> { new Product(19,"BAMBOO",2,3) , new Product(2, "CUCKOO", 20, 31) }, new StringReader("1\n19") },
               new object[] {new List<Product> { new Product(29,"BANANA",2,3) , new Product(1, "CARROT", 20, 31) }, new StringReader("1\n29") },
            };
        }
    }
}
