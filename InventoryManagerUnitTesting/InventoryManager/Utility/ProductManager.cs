using InventoryManager.UserInterface;
using InventoryManager.Model;
using ConsoleTables;

namespace InventoryManager.Utility
{
    /// <summary>
    /// Handles the operations of the product list
    /// </summary>
    public class ProductManager
    {
        /// <summary>
        /// Represents the Product List
        /// </summary>
        private List<Product> _productList;
        InputManager inputManager;
        OutputManager outputManager;

        /// <summary>
        /// Represents the ProductManager class with the essential object references
        /// </summary>
        /// <param name="mainDataValidation">Required Data validation object reference</param>
        /// <param name="mainInputManager">Required Input manager object reference</param>
        public ProductManager(InputManager mainInputManager, OutputManager mainOutputManager)
        {
            inputManager = mainInputManager ;
            outputManager = mainOutputManager ;
            _productList = new List<Product>(); ;
        }
        /// <summary>
        /// To check if the product list is empty
        /// </summary>
        /// <returns>True if the product list is empty, else false</returns>
        private bool IsListEmpty()
        {
            return (_productList.Count == 0);
        }

        public List<Product> productRepository()
            { return _productList; }

        /// <summary>
        /// Returns the index of the product from the product list
        /// </summary>
        /// <param name="inputProductName">The product name whose information must be stored</param>
        /// <returns>The index of the matched product</returns>
        private int ReturnIndexWithName(string inputProductName)
        {
            return _productList.FindIndex(x => x.ProductName == inputProductName);
        }

        /// <summary>
        /// Returns the index of the product from the product list
        /// </summary>
        /// <param name="inputProductId">The product ID whose information must be stored</param>
        /// <returns>The index of the matched product</returns>
        private int ReturnIndexWithId(int inputProductId)
        {
            return _productList.FindIndex(x => x.ProductId == inputProductId);       
        }
        /// <summary>
        /// To check whether the input string is contained in any of the product name
        /// </summary>
        /// <param name="inputForSearchProductName">The input string which is to be checked</param>
        /// <returns>True if any product name contains the input string, else false</returns>
        private int IsContainingProductName(string inputForSearchProductName)
        {
            int numberOfMatchedSearches = 0;
            foreach (Product searchProduct in _productList)
            {
                if (searchProduct.ProductName.Contains(inputForSearchProductName))
                {
                    PrintConsoleTable(outputManager.SpecificProductInformation(_productList, ReturnValidIndex(searchProduct.ProductName)));
                    numberOfMatchedSearches++;
                }
            }
            return numberOfMatchedSearches;
        }

        private int ReturnValidIndex(string viewProduct)
        {
            int printIndex = ReturnIndexWithName(viewProduct);
            while (printIndex == -1)
            {
                viewProduct = inputManager.ReplaceInvalidInput();
                printIndex = ReturnIndexWithName(viewProduct);
            }
            return printIndex;
        }

        private string GetDistinctProductName(string inputProductName)
        {
            while (ReturnIndexWithName(inputProductName) != -1)
            {
                inputProductName = inputManager.GetUniqueProductName();
            }
            return inputProductName;
        }

        private int GetDistinctProductId(int inputProductId)
        {
            while (ReturnIndexWithId(inputProductId) != -1)
            {
                inputProductId = inputManager.GetUniqueProductId();
            }
            return inputProductId;
        }
        private void PrintConsoleTable(ConsoleTable consoleTable)
        {
            consoleTable.Write();
        }

        /// <summary>
        /// To add new products in the list
        /// </summary>
        public virtual void AddProduct()
        {
            string productName = GetDistinctProductName(inputManager.GetProductName());
            int productId = GetDistinctProductId(inputManager.GetProductId());
            decimal productPrice = inputManager.GetProductPrice();
            int productQuantity = inputManager.GetProductQuantity();
            Product product = new Product(productId, productName, productPrice, productQuantity);
            _productList.Add(product);
            OutputManager.PrintSuccessfulAddition();
            PrintConsoleTable(outputManager.SpecificProductInformation(_productList, ReturnValidIndex(product.ProductName)));
        }

        /// <summary>
        /// To delete products in the list
        /// </summary>
        public virtual void DeleteProduct()
        {
            if (!IsListEmpty())
            {
                string deleteChoice = inputManager.GetProductName();
                int deleteIndex = ReturnIndexWithName(deleteChoice);
                if (deleteIndex == -1)
                {
                    OutputManager.PrintNoMatches();
                }
                else
                {
                    OutputManager.PrintSuccessfulDeletion();
                    _productList.RemoveAt(deleteIndex);
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To modify product information in the list
        /// </summary>
        public virtual void ModifyProduct()
        {
            if (!IsListEmpty())
            {
                string editChoice = inputManager.GetProductName();
                int editIndex = ReturnIndexWithName(editChoice);
                if (editIndex == -1)
                { 
                    OutputManager.PrintNoMatches(); 
                }
                else
                {
                    UserEditChoice userEditChoice = (UserEditChoice)inputManager.GetEditField();
                    switch (userEditChoice)
                    {
                        case UserEditChoice.EditProductName:
                            _productList[editIndex].ProductName = GetDistinctProductName(inputManager.GetProductName());
                            break;
                        case UserEditChoice.EditProductId:
                            _productList[editIndex].ProductId = GetDistinctProductId(inputManager.GetProductId());
                            break;
                        case UserEditChoice.EditProductPrice:
                            _productList[editIndex].ProductPrice = inputManager.GetProductPrice();
                            break;
                        case UserEditChoice.EditProductQuantity:
                            _productList[editIndex].ProductQuantity = inputManager.GetProductQuantity();
                            break;
                        default:
                            break;
                    }
                    PrintConsoleTable(outputManager.SpecificProductInformation(_productList, editIndex));
                    OutputManager.PrintSuccessfulModification();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To sort the products in the list
        /// </summary>
        public virtual void SortProduct()
        {
            if (!IsListEmpty())
            {
                int sortOrder = inputManager.GetActionField();
                NameOrIdChoice sortChoice = (NameOrIdChoice) sortOrder;
                if (sortChoice == NameOrIdChoice.ByName)
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductName).ToList();
                    PrintConsoleTable(outputManager.ProductList(_productList));
                }
                else if (sortChoice == NameOrIdChoice.ById)
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductId).ToList();
                    PrintConsoleTable(outputManager.ProductList(_productList));
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To view the product names in the list
        /// </summary>
        public virtual void ViewProduct()
        {
            if (!IsListEmpty())
            {
                PrintConsoleTable(outputManager.ProductList(_productList));
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To search for a particular product in the list
        /// </summary>
        public virtual int SearchProduct()
        {
            int numberOfMatches = 0;
            if (!IsListEmpty())
            {
                int searchByChoice = inputManager.GetActionField();              
                NameOrIdChoice searchChoice = (NameOrIdChoice) searchByChoice;
                switch(searchChoice)
                {
                    case NameOrIdChoice.ByName:
                        string productNameHint = inputManager.GetProductName();
                        numberOfMatches = IsContainingProductName(productNameHint);
                        break;
                    case NameOrIdChoice.ById:
                        int productIdHint = inputManager.GetProductId();
                        int searchIndex = ReturnIndexWithId(productIdHint);
                        if (searchIndex == -1)
                        { break; }
                        else
                        {
                            PrintConsoleTable(outputManager.SpecificProductInformation(_productList, searchIndex));
                            numberOfMatches++;
                        }           
                        break;
                }

                if (numberOfMatches == 0)
                    OutputManager.PrintNoMatches();                             
            }

            else
                OutputManager.PrintListIsEmpty();
            return numberOfMatches;
        }
    }
}
