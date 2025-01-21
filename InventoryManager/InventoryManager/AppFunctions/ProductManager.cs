using InventoryManager.PrintInformation;
using InventoryManager.MatchIndex;
using InventoryManager.Model;
using InventoryManager.ValidInput;

namespace InventoryManager.AppFunctions
{
    public class ProductManager
    {
        private List<Product> _productList = [];
        //Create the required object references
        DataValidation dataValidation = new DataValidation();
        IndexSearch indexSearch = new IndexSearch();
        UniqueInformation uniqueInformation = new UniqueInformation();
        ProductInformation productInformation = new ProductInformation();

        //Method to add new products in the list
        public void AddProduct()
        {
            Console.Write("Enter the Product Name :  ");
            string productName = uniqueInformation.DistinctInputs(_productList, Console.ReadLine(), true);
            Console.Write("Enter the Product ID :  ");
            int productId = dataValidation.IsDataValid(uniqueInformation.DistinctInputs(_productList, Console.ReadLine(), false));
            Console.Write("Enter the Product Price :  ");
            decimal productPrice = dataValidation.IsProductPriceValid(Console.ReadLine());
            Console.Write("Enter the Product Quantity : ");
            int productQuantity = dataValidation.IsDataValid(Console.ReadLine());
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
                int deleteIndex = indexSearch.ReturnIndex(_productList, deleteChoice, true);
                while (deleteIndex == -1)
                {
                    InputManager.PrintInvalidInput();
                    deleteChoice = Console.ReadLine();
                    deleteIndex = indexSearch.ReturnIndex(_productList, deleteChoice, true);
                }
                Console.WriteLine($"The Product Information of {deleteChoice} has been deleted successfully.");
                _productList.RemoveAt(deleteIndex);
            }
            else
            {
                InputManager.PrintListIsEmpty();
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
                        _productList[indexSearch.ReturnIndex(_productList, editChoice, true)].ProductName = Console.ReadLine();
                        break;
                    case "I":
                        Console.WriteLine("Enter the Edited Product ID : ");
                        _productList[indexSearch.ReturnIndex(_productList, editChoice, true)].ProductId = dataValidation.IsDataValid(Console.ReadLine());
                        break;
                    case "P":
                        Console.WriteLine("Enter the Edited Product Price : ");
                        _productList[indexSearch.ReturnIndex(_productList, editChoice, true)].ProductPrice = dataValidation.IsProductPriceValid(Console.ReadLine());
                        break;
                    case "Q":
                        Console.WriteLine("Enter the Edited Product Quantity : ");
                        _productList[indexSearch.ReturnIndex(_productList, editChoice, true)].ProductQuantity = dataValidation.IsDataValid(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("The Provided input is invalid !!");
                        break;
                }
            }
            else
            {
                InputManager.PrintListIsEmpty();
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
                    List<Product> sortedList = _productList.OrderBy(o => o.ProductName).ToList();
                    _productList = sortedList;
                    Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
                    productInformation.PrintProductList(sortedList);
                }
                else if (sortOrder.ToUpper() == "I")
                {
                    List<Product> sortedList = _productList.OrderBy(o => o.ProductId).ToList();
                    _productList = sortedList;
                    Console.WriteLine("The Product List is Sorted Successfully.\nThe Sorted List ");
                    productInformation.PrintProductList(sortedList);
                }
                else
                {
                    InputManager.PrintInvalidInput();
                }
            }
            else
            {
                InputManager.PrintListIsEmpty();
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
                    InputManager.PrintInvalidInput();
                    viewChoice = Console.ReadLine();
                }
                if (viewChoice.ToUpper() == "Y")
                {
                    Console.Write("Search by [N]ame / [I]d : ");
                    string searchField = Console.ReadLine();
                    while (searchField.ToUpper() != "I" && searchField.ToUpper() != "N")
                    {
                        InputManager.PrintInvalidInput();
                        searchField = Console.ReadLine();
                    }
                    bool isProductName = (searchField.ToUpper() == "N") ? true : false;
                    Console.Write("Kindly provide the Name/ID of the Product that must be viewed : ");
                    string searchValue = Console.ReadLine();
                    productInformation.PrintProductInformation(_productList, searchValue, isProductName);
                }
            }
            else
            {
                InputManager.PrintListIsEmpty();
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
                    int productIdHint = dataValidation.IsDataValid(Console.ReadLine());
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
                    InputManager.PrintInvalidInput();
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
            }
            else
            {
                InputManager.PrintListIsEmpty();
            }
        }
    }
}