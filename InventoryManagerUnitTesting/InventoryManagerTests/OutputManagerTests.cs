using InventoryManager.Model;
using NUnit.Framework;
using InventoryManager.UserInterface;
using ConsoleTables;

namespace InventoryManagerTests
{
    public class OutputManagerTests
    {

        [TearDown]
        public void TearDown()
        {
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
        }

        [TestCaseSource(nameof(SpecificProductInformationTestCases))]
        [Test]
        public void SpecificProductInformation_ShallPrintProductInformation_IfProductListAndProductIndexGiven(List<Product> _productList, int productIndex)
        {
            OutputManager outputManager = new OutputManager();
            var expectedConsoleTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            expectedConsoleTable.AddRow(_productList[productIndex].ProductName, _productList[productIndex].ProductId, _productList[productIndex].ProductPrice, _productList[productIndex].ProductQuantity);
            ConsoleTable outputConsoleTable = outputManager.SpecificProductInformation(_productList, productIndex);
            Assert.AreEqual(expectedConsoleTable.ToString(),outputConsoleTable.ToString());
        }

        private static IEnumerable<object> SpecificProductInformationTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) }, 2 },
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) }, 1 },
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) }, 0 }
            };
        }

        [TestCaseSource(nameof(ProductListTestCases))]
        [Test]
        public void ProductList_ShallPrintProductList_IfProductListGiven(List<Product> _productList)
        {
            OutputManager outputManager = new OutputManager();
            var expectedConsoleTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            foreach (var product in _productList)
            {
                expectedConsoleTable.AddRow(product.ProductName, product.ProductId, product.ProductPrice, product.ProductQuantity);
            }
            ConsoleTable outputConsoleTable = outputManager.ProductList(_productList);
            Assert.AreEqual(expectedConsoleTable.ToString(), outputConsoleTable.ToString());
        }

        private static IEnumerable<object> ProductListTestCases()
        {
            return new[]
            {
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } },
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) , new Product(3, "TOMATO", 200, 39) , new Product(4, "POTATO", 400, 30) } },
               new object[] {new List<Product> { new Product(1,"BANANA",2,3) , new Product(2, "APPLE", 20, 31) }}
            };
        }
    }
}
