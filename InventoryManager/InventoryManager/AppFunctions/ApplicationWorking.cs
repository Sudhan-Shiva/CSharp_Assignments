using InventoryManager.PrintInformation;
using InventoryManager.MatchIndex;
using InventoryManager.ProductClass;
using InventoryManager.ValidInput;

namespace InventoryManager.AppFunctions
{
    public class ApplicationWorking
    {
        //Create the required object references
        DataValidation dataValidation = new DataValidation();
        IndexSearch indexSearch = new IndexSearch();
        UniqueInformation uniqueInformation = new UniqueInformation();
        ProductInformation productInformation = new ProductInformation();

        //Method to add new products in the list
        public void ProductAddition(List<Product> productList)
        {
            Console.Write("Enter the Product Name :  ");
            string productName = uniqueInformation.DistinctInputs(productList, Console.ReadLine(), true);
            Console.Write("Enter the Product ID :  ");
            int productId = dataValidation.CheckDataIsInt(uniqueInformation.DistinctInputs(productList, Console.ReadLine(), false));
            Console.Write("Enter the Product Price :  ");
            decimal productPrice = dataValidation.CheckProductPrice(Console.ReadLine());
            Console.Write("Enter the Product Quantity : ");
            int productQuantity = dataValidation.CheckDataIsInt(Console.ReadLine());
            Product product = new Product(productId, productName, productPrice, productQuantity);
            productList.Add(product);
            Console.WriteLine("The Product Information has been successfully added.\n");
        }

        //Method to delete products in the list
        public void ProductDeletion(List<Product> productList)
        {
            if (productList.Count > 0)
            {
                Console.Write("Enter the Name of the Product that must be deleted :  ");
                string deleteChoice = Console.ReadLine();
                int deleteIndex = indexSearch.ReturnIndex(productList, deleteChoice, true);
                while (deleteIndex == -1)
                {
                    PrintMessages.PrintInvalidInput();
                    deleteChoice = Console.ReadLine();
                    deleteIndex = indexSearch.ReturnIndex(productList, deleteChoice, true);
                }
                Console.WriteLine($"The Product Information of {deleteChoice} has been deleted successfully.");
                productList.RemoveAt(deleteIndex);
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        //Method to modify product information in the list
        public void ProductModification(List<Product> productList)
        {
            if (productList.Count > 0)
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
                        productList[indexSearch.ReturnIndex(productList, editChoice, true)].ProductName = Console.ReadLine();
                        break;
                    case "I":
                        Console.WriteLine("Enter the Edited Product ID : ");
                        productList[indexSearch.ReturnIndex(productList, editChoice, true)].ProductId = dataValidation.CheckDataIsInt(Console.ReadLine());
                        break;
                    case "P":
                        Console.WriteLine("Enter the Edited Product Price : ");
                        productList[indexSearch.ReturnIndex(productList, editChoice, true)].ProductPrice = dataValidation.CheckProductPrice(Console.ReadLine());
                        break;
                    case "Q":
                        Console.WriteLine("Enter the Edited Product Quantity : ");
                        productList[indexSearch.ReturnIndex(productList, editChoice, true)].ProductQuantity = dataValidation.CheckDataIsInt(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("The Provided input is invalid !!");
                        break;
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        //Method to sort the products in the list
        public void ProductSort(List<Product> productList)
        {
            if (productList.Count > 0)
            {
                Console.Write("Do you want to sort by Name or ID ?\n[N]ame/[I]d :");
                string sortOrder = Console.ReadLine();
                if (sortOrder.ToUpper() == "N")
                {
                    List<Product> sortedList = productList.OrderBy(o => o.ProductName).ToList();
                    productList = sortedList;
                    Console.WriteLine("The Product List is Sorted Successfully");
                }
                else if (sortOrder.ToUpper() == "I")
                {
                    List<Product> sortedList = productList.OrderBy(o => o.ProductId).ToList();
                    productList = sortedList;
                    Console.WriteLine("The Product List is Sorted Successfully");
                }
                else
                {
                    PrintMessages.PrintInvalidInput();
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        //Method to view the product names in the list
        public void ProductView(List<Product> productList)
        {
            if (productList.Count > 0)
            {
                Console.WriteLine("All the Product Names in the Product List are : ");
                for (int i = 1; i <= productList.Count; i++)
                {
                    Console.WriteLine($"{i}.{productList[i - 1].ProductName}");
                }
                Console.Write("Do you want to view the Product Information of any specific Product ?\nY/N : ");
                string viewChoice = Console.ReadLine();
                while (viewChoice.ToUpper() != "Y" && viewChoice.ToUpper() != "N")
                {
                    PrintMessages.PrintInvalidInput();
                    viewChoice = Console.ReadLine();
                }
                if (viewChoice.ToUpper() == "Y")
                {
                    Console.Write("Search by [N]ame / [I]d : ");
                    string searchField = Console.ReadLine();
                    while (searchField.ToUpper() != "I" && searchField.ToUpper() != "N")
                    {
                        PrintMessages.PrintInvalidInput();
                        searchField = Console.ReadLine();
                    }
                    bool isProductName = (searchField.ToUpper() == "N") ? true : false;
                    Console.Write("Kindly provide the Name/ID of the Product that must be viewed : ");
                    string searchValue = Console.ReadLine();
                    productInformation.PrintProductInformation(productList, searchValue, isProductName);
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }

        //Method to search for a particular product in the list
        public void ProductSearch(List<Product> productList)
        {
            if (productList.Count > 0)
            {
                Console.Write("Search by [N]ame or [I]d : ");
                string searchByChoice = Console.ReadLine();
                bool isSearchPresent = false;
                if (searchByChoice.ToUpper() == "N")
                {
                    Console.Write("Search for the Product Name : ");
                    string productNameHint = Console.ReadLine();
                    foreach (Product searchproduct in productList)
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
                    int productIdHint = dataValidation.CheckDataIsInt(Console.ReadLine());
                    foreach (Product searchproduct in productList)
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
                    PrintMessages.PrintInvalidInput();
                }
                if (!isSearchPresent)
                {
                    Console.WriteLine("There are no matches found.");
                }
            }
            else
            {
                PrintMessages.PrintListIsEmpty();
            }
        }
    }
}