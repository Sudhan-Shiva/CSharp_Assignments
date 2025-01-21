using InventoryManager.PrintInformation;
using InventoryManager.MatchIndex;
using InventoryManager.Model;
using InventoryManager.ValidInput;
using ConsoleTables;

namespace InventoryManager.AppFunctions
{
    public class ProductManager
    {
        private List<Product> _productList = [];
        //Create the required object references
        DataValidation dataValidation;
        IndexSearch indexSearch;
        ProductInformation productInformation;
        public ProductManager(DataValidation mainDataValidation, IndexSearch mainIndexSearch, ProductInformation mainProductInformation)
        {
            dataValidation = mainDataValidation ;
            indexSearch = mainIndexSearch;
            productInformation = mainProductInformation;
        }
        public bool IsListEmpty()
        {
            return _productList.Count == 0;
        }
        public string GetDistinctInputs(string inputParameter, bool isProductName)
        {
            //Loop till a unique input is received from the user
            while (ReturnIndex(inputParameter, isProductName) != -1)
            {
                Console.WriteLine("The Product Field is Already Present !");
                Console.Write("Give a new Field : ");
                inputParameter = Console.ReadLine();
            }
            return inputParameter;
        }
        public int GetValidInteger(string inputParameter)
        {          
            while (!dataValidation.IsDataValid(inputParameter))
            {
                OutputManager.PrintInvalidInput();
                inputParameter = Console.ReadLine();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }
        public decimal GetValidDecimal(string inputParameter)
        {
            while (!dataValidation.IsProductPriceValid(inputParameter))
            {
                OutputManager.PrintInvalidInput();
                inputParameter = Console.ReadLine();
            }
            decimal.TryParse(inputParameter, out decimal validData);
            return validData;
        }

        public int ReturnIndex(string inputParameter, bool isProductName)
        {
            foreach (Product product in _productList)
            {
                if (indexSearch.IsIdOrNamePresent(product, inputParameter, isProductName))
                {
                    //Return the INdex of the matched Product
                    return _productList.IndexOf(product);
                }
            }
            //If no matching product is found, -1 is returned.
            return -1;
        }
        public List<Product> GetProductRepository()
        {
            return _productList;
        }

        public ConsoleTable SpecificProductInformation(string viewProduct, bool isProductName)
        {
            int printIndex = ReturnIndex(viewProduct, isProductName);
            //If returned index is -1, it means that either the given input is invalid or it is not present in the list
            while (printIndex == -1)
            {
                OutputManager.PrintInvalidInput();
                viewProduct = Console.ReadLine();
                printIndex = ReturnIndex(viewProduct, isProductName);

            }
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            //Print the information of the product
            productTable.AddRow(_productList[printIndex].ProductName,
                                _productList[printIndex].ProductId,
                                _productList[printIndex].ProductPrice,
                                _productList[printIndex].ProductQuantity);
            return productTable;
        }

        public ConsoleTable ProductList()
        {
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            foreach (Product product in _productList)
            {
                productTable.AddRow(product.ProductName, product.ProductId, product.ProductPrice, product.ProductQuantity);
            }
            //Print the information of the product     
            return productTable;
        }
        //Method to add new products in the list
        public void AddProduct()
        {
            Console.Write("Enter the Product Name :  ");
            string productName = GetDistinctInputs(Console.ReadLine(), true);
            Console.Write("Enter the Product ID :  ");
            int productId = GetValidInteger(GetDistinctInputs(Console.ReadLine(), false));
            Console.Write("Enter the Product Price :  ");
            decimal productPrice = GetValidDecimal(Console.ReadLine());
            Console.Write("Enter the Product Quantity : ");
            int productQuantity = GetValidInteger(Console.ReadLine());
            Product product = new Product(productId, productName, productPrice, productQuantity);
            _productList.Add(product);
            Console.WriteLine("The Product Information has been successfully added.\n");
        }
        //Method to delete products in the list
        public void DeleteProduct()
        {
            if (_productList.Count > 0)
            {
                Console.Write("Enter the Name of the Product that must be deleted :  ");
                string deleteChoice = Console.ReadLine();
                int deleteIndex = ReturnIndex(deleteChoice, true);
                while (deleteIndex == -1)
                {
                    OutputManager.PrintInvalidInput();
                    deleteChoice = Console.ReadLine();
                    deleteIndex = ReturnIndex(deleteChoice, true);
                }
                Console.WriteLine($"The Product Information of {deleteChoice} has been deleted successfully.");
                _productList.RemoveAt(deleteIndex);
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }
        //Method to modify product information in the list
        public void ModifyProduct()
        {
            if (_productList.Count > 0)
            {
                Console.WriteLine("Enter the Name of the Product that must be edited :  ");
                string editChoice = Console.ReadLine();
                Console.WriteLine("Choose the Information that must be edited : \n [N]ame of the Product \n [I]D of the Product \n [P]rice of the Product \n [Q]uantity of the product \n");
                Console.Write("Type your Choice: ");
                string editField = Console.ReadLine();
                switch (editField.ToUpper())
                {
                    case "N":
                        Console.WriteLine("Enter the Edited Product Name : ");
                        _productList[ReturnIndex(editChoice, true)].ProductName = Console.ReadLine();
                        break;
                    case "I":
                        Console.WriteLine("Enter the Edited Product ID : ");
                        _productList[ReturnIndex(editChoice, true)].ProductId = GetValidInteger(Console.ReadLine());
                        break;
                    case "P":
                        Console.WriteLine("Enter the Edited Product Price : ");
                        _productList[ReturnIndex(editChoice, true)].ProductPrice = GetValidDecimal(Console.ReadLine());
                        break;
                    case "Q":
                        Console.WriteLine("Enter the Edited Product Quantity : ");
                        _productList[ReturnIndex(editChoice, true)].ProductQuantity = GetValidInteger(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("The Provided input is invalid !!");
                        break;
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        //Method to sort the products in the list
        public void SortProduct()
        {
            if (_productList.Count > 0)
            {
                Console.Write("Do you want to sort by Name or ID ?\n[N]ame/[I]d :");
                string sortOrder = Console.ReadLine();
                if (sortOrder.ToUpper() == "N")
                {                
                    Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
                    _productList = _productList.OrderBy(o => o.ProductName).ToList();
                    productInformation.PrintTable(ProductList());
                }
                else if (sortOrder.ToUpper() == "I")
                {
                    Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
                    _productList = _productList.OrderBy(o => o.ProductId).ToList();
                    productInformation.PrintTable(ProductList());
                }
                else
                {
                    OutputManager.PrintInvalidInput();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        //Method to view the product names in the list
        public void ViewProduct()
        {
            if (_productList.Count > 0)
            {
                Console.WriteLine("All the Product Names in the Product List are : ");
                for (int i = 1; i <= _productList.Count; i++)
                {
                    Console.WriteLine($"{i}.{_productList[i - 1].ProductName}");
                }
                Console.Write("Do you want to view the Product Information of any specific Product ?\nY/N : ");
                string viewChoice = Console.ReadLine();
                while (viewChoice.ToUpper() != "Y" && viewChoice.ToUpper() != "N")
                {
                    OutputManager.PrintInvalidInput();
                    viewChoice = Console.ReadLine();
                }
                if (viewChoice.ToUpper() == "Y")
                {
                    Console.Write("Search by [N]ame / [I]d : ");
                    string searchField = Console.ReadLine();
                    while (searchField.ToUpper() != "I" && searchField.ToUpper() != "N")
                    {
                        OutputManager.PrintInvalidInput();
                        searchField = Console.ReadLine();
                    }
                    bool isProductName = (searchField.ToUpper() == "N") ? true : false;
                    Console.Write("Kindly provide the Name/ID of the Product that must be viewed : ");
                    string searchValue = Console.ReadLine();
                    productInformation.PrintTable(SpecificProductInformation(searchValue, isProductName));
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        //Method to search for a particular product in the list
        public void SearchProduct()
        {
            if (_productList.Count > 0)
            {
                Console.Write("Search by [N]ame or [I]d : ");
                string searchByChoice = Console.ReadLine();
                bool isSearchPresent = false;
                if (searchByChoice.ToUpper() == "N")
                {
                    Console.Write("Search for the Product Name : ");
                    string productNameHint = Console.ReadLine();
                    foreach (Product searchproduct in _productList)
                    {
                        if (searchproduct.ProductName.Contains(productNameHint))
                        {
                            Console.WriteLine($"{searchproduct.ProductName} - Product ID : {searchproduct.ProductId}\n");
                            isSearchPresent = true;
                        }
                    }
                }
                else if (searchByChoice.ToUpper() == "I")
                {
                    Console.Write("Search for the Product ID : ");
                    int productIdHint = GetValidInteger(Console.ReadLine());
                    foreach (Product searchproduct in _productList)
                    {
                        if (searchproduct.ProductId == productIdHint)
                        {
                            Console.WriteLine($"{searchproduct.ProductName} - Product ID : {searchproduct.ProductId}\n");
                            isSearchPresent = true;
                        }
                    }
                }
                else
                {
                    OutputManager.PrintInvalidInput();
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }
    }
}