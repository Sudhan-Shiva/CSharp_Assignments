using InventoryManager.UserInterface;
using InventoryManager.Model;

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
        private List<Product> _productList = new List<Product>();
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
        }
        /// <summary>
        /// To check if the product list is empty
        /// </summary>
        /// <returns>True if the product list is empty, else false</returns>
        public bool IsListEmpty()
        {
            return (_productList.Count == 0);
        }

        /// <summary>
        /// Returns the index of the product from the product list
        /// </summary>
        /// <param name="inputParameter">The product name/ID whose information must be stored</param>
        /// <param name="isProductName">Represents whether the input parameter to locate the product is name</param>
        /// <returns>The index of the matched product</returns>
        public int ReturnIndex(string inputParameter, bool isProductName)
        {
            if (isProductName)
            {
                return _productList.FindIndex(x => x.ProductName == inputParameter);
            }
            else
            {
                return _productList.FindIndex(x => x.ProductId == inputManager.GetValidInteger(inputParameter));
            }
        }

        /// <summary>
        /// To check whether the input string is contained in any of the product name
        /// </summary>
        /// <param name="productNameHint">The input string which is to be checked</param>
        /// <returns>True if any product name contains the input string, else false</returns>
        public bool IsContainingProductName(string productNameHint)
        {
            bool isSearchPresent = false;
            foreach (Product searchproduct in _productList)
            {
                if (searchproduct.ProductName.Contains(productNameHint))
                {
                    outputManager.SpecificProductInformation(_productList, ReturnValidIndex(searchproduct.ProductName, true));
                    isSearchPresent = true;
                }
            }
            return isSearchPresent;
        }

        public int ReturnValidIndex(string viewProduct, bool isProductName)
        {
            int printIndex = ReturnIndex(viewProduct, isProductName);
            while (printIndex == -1)
            {
                viewProduct = inputManager.ReplaceInvalidInput();
                printIndex = ReturnIndex(viewProduct, isProductName);
            }
            return printIndex;
        }

        public string GetDistinctInputs(string inputParameter, bool isProductName)
        {
            while (ReturnIndex(inputParameter, isProductName) != -1)
            {
                inputParameter = inputManager.GetUniqueInput();
            }
            return inputParameter;
        }

        /// <summary>
        /// To add new products in the list
        /// </summary>
        public void AddProduct()
        {

            string productName = GetDistinctInputs(inputManager.GetProductName(), true);
            int productId = int.Parse(GetDistinctInputs(inputManager.GetProductId(), false));
            decimal productPrice = inputManager.GetProductPrice();
            int productQuantity = inputManager.GetProductQuantity();
            Product product = new Product(productId, productName, productPrice, productQuantity);
            _productList.Add(product);
            OutputManager.PrintSuccessfulAddition();
            outputManager.SpecificProductInformation(_productList, ReturnValidIndex(productName, true));
        }

        /// <summary>
        /// To delete products in the list
        /// </summary>
        public void DeleteProduct()
        {
            if (!IsListEmpty())
            {
                string deleteChoice = inputManager.GetProductName();
                int deleteIndex = ReturnIndex(deleteChoice, true);
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
        public void ModifyProduct()
        {
            if (!IsListEmpty())
            {
                string editChoice = inputManager.GetProductName();
                int editIndex = ReturnIndex(editChoice, true);
                string newProductName = editChoice;
                if (editIndex == -1)
                { 
                    OutputManager.PrintNoMatches(); 
                }
                else
                {
                    string editField = inputManager.GetEditField();
                    switch (editField.ToUpper())
                    {
                        case "N":
                            newProductName = GetDistinctInputs(inputManager.GetValidInput(inputManager.GetProductName()), true);
                            _productList[editIndex].ProductName = newProductName;
                            break;
                        case "I":
                            _productList[editIndex].ProductId = inputManager.GetValidInteger(GetDistinctInputs(inputManager.GetProductId(), false));
                            break;
                        case "P":
                            _productList[editIndex].ProductPrice = inputManager.GetProductPrice();
                            break;
                        case "Q":
                            _productList[editIndex].ProductQuantity = inputManager.GetProductQuantity();
                            break;
                        default:
                            inputManager.ReplaceInvalidInput();
                            break;
                    }
                    outputManager.SpecificProductInformation(_productList, editIndex);
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
        public void SortProduct()
        {
            if (!IsListEmpty())
            {
                string sortOrder = inputManager.GetActionField();
                if (sortOrder.ToUpper() == "N")
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductName).ToList();
                    outputManager.ProductList(_productList);
                }
                else if (sortOrder.ToUpper() == "I")
                {
                    OutputManager.PrintSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductId).ToList();
                    outputManager.ProductList(_productList);
                }
                else
                {
                    inputManager.ReplaceInvalidInput();
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
        public void ViewProduct()
        {
            if (!IsListEmpty())
            {
                outputManager.ProductList(_productList);
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }

        /// <summary>
        /// To search for a particular product in the list
        /// </summary>
        public void SearchProduct()
        {
            if (!IsListEmpty())
            {
                string searchByChoice = inputManager.GetActionField();
                bool isSearchPresent = false;
                while (searchByChoice.ToUpper() != "N" && searchByChoice.ToUpper() != "I")
                {
                    searchByChoice = inputManager.ReplaceInvalidInput();
                }
                switch(searchByChoice.ToUpper())
                    {
                        case "N":
                            string productNameHint = inputManager.GetProductName();
                            isSearchPresent = IsContainingProductName(productNameHint);
                        break;
                        case "I":
                            string productIdHint = inputManager.GetProductId();
                            int searchIndex = ReturnIndex(productIdHint, false);
                            if (searchIndex == -1)
                            { break; }
                            else
                            {
                                outputManager.SpecificProductInformation(_productList, searchIndex);
                                isSearchPresent = true;
                            }                       
                        break;
                    default:
                        OutputManager.PrintInvalidInput();
                        break;
                    }
                if (!isSearchPresent)
                {
                   OutputManager.PrintNoMatches();
                }
            }
            else
            {
                OutputManager.PrintListIsEmpty();
            }
        }
    }
}
