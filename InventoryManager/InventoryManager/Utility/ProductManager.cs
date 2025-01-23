using InventoryManager.UserInterface;
using InventoryManager.Model;
using InventoryManager.ValidInput;
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
        private List<Product> _productList = [];
        InputManager inputManager;

        /// <summary>
        /// Represents the ProductManager class with the essential object references
        /// </summary>
        /// <param name="mainDataValidation">Required Data validation object reference</param>
        /// <param name="mainInputManager">Required Input manager object reference</param>
        public ProductManager(InputManager mainInputManager)
        {
            inputManager = mainInputManager ;
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
        /// To get unique inputs for the product name and ID
        /// </summary>
        /// <param name="inputParameter">The input which is checked</param>
        /// <param name="isProductName">Represents whether the given input is the product name</param>
        /// <returns>A unique input for the product name or ID</returns>
        public string GetDistinctInputs(string inputParameter, bool isProductName)
        {
            while (ReturnIndex(inputParameter, isProductName) != -1)
            {
                inputParameter = inputManager.GetUniqueInput();
            }
            return inputParameter;
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
        /// Stores the information of a specific product as a ConsoleTable
        /// </summary>
        /// <param name="viewProduct">The product name/ID whose information must be stored</param>
        /// <param name="isProductName">Represents whether the input parameter to locate the product is name</param>
        /// <returns>The informaton of a specific product as a ConsoleTable</returns>
        public ConsoleTable SpecificProductInformation(string viewProduct, bool isProductName)
        {
            int printIndex = ReturnIndex(viewProduct, isProductName);
            while (printIndex == -1)
            {
                viewProduct  = inputManager.ReplaceInvalidInput();
                printIndex = ReturnIndex(viewProduct, isProductName);
            }
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            productTable.AddRow(_productList[printIndex].ProductName,
                                _productList[printIndex].ProductId,
                                _productList[printIndex].ProductPrice,
                                _productList[printIndex].ProductQuantity);
            return productTable;
        }

        /// <summary>
        /// Stores the complete product list as a ConsoleTable
        /// </summary>
        /// <returns>The ConsoleTable containing the product List</returns>
        public ConsoleTable ProductList()
        {
            var productTable = new ConsoleTable("Product Name", "Product ID", "Product Price", "Product Quantity");
            foreach (Product product in _productList)
            {
                productTable.AddRow(product.ProductName, product.ProductId, product.ProductPrice, product.ProductQuantity);
            }  
            return productTable;
        }

        /// <summary>
        /// Stores the names of all the product as a ConsoleTable
        /// </summary>
        /// <returns>The ConsoleTable containing all the product names</returns>
        public ConsoleTable ProductNames()
        {
            var productTable = new ConsoleTable("Product Name");
            foreach (Product product in _productList)
            {
                productTable.AddRow(product.ProductName);
            }
            //Print the information of the product     
            return productTable;
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
                    OutputManager.ShowList(SpecificProductInformation(searchproduct.ProductName, true));
                    isSearchPresent = true;
                }
            }
            return isSearchPresent;
        }

        /// <summary>
        /// To add new products in the list
        /// </summary>
        public void AddProduct()
        {
            string productName = GetDistinctInputs(inputManager.GetValidInput(inputManager.GetProductName()), true);
            int productId = inputManager.GetValidInteger(GetDistinctInputs(inputManager.GetProductId(), false));
            decimal productPrice = inputManager.GetValidDecimal(inputManager.GetProductPrice());
            int productQuantity = inputManager.GetValidInteger(inputManager.GetProductQuantity());
            Product product = new Product(productId, productName, productPrice, productQuantity);
            _productList.Add(product);
            OutputManager.ShowSuccessfulAddition();
            OutputManager.ShowList(SpecificProductInformation(productName, true));
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
                    OutputManager.ShowNoMatches();
                }
                else
                {
                    OutputManager.ShowSuccessfulDeletion();
                    _productList.RemoveAt(deleteIndex);
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
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
                    OutputManager.ShowNoMatches(); 
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
                            _productList[editIndex].ProductPrice = inputManager.GetValidDecimal(inputManager.GetProductPrice());
                            break;
                        case "Q":
                            _productList[editIndex].ProductQuantity = inputManager.GetValidInteger(inputManager.GetProductQuantity());
                            break;
                        default:
                            inputManager.ReplaceInvalidInput();
                            break;
                    }
                    OutputManager.ShowList(SpecificProductInformation(newProductName, true));
                    OutputManager.ShowSuccessfulModification();
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
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
                    OutputManager.ShowSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductName).ToList();
                    OutputManager.ShowList(ProductList());
                }
                else if (sortOrder.ToUpper() == "I")
                {
                    OutputManager.ShowSuccessfulSorting();
                    _productList = _productList.OrderBy(o => o.ProductId).ToList();
                    OutputManager.ShowList(ProductList());
                }
                else
                {
                    inputManager.ReplaceInvalidInput();
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }

        /// <summary>
        /// To view the product names in the list
        /// </summary>
        public void ViewProduct()
        {
            if (!IsListEmpty())
            {
                OutputManager.ShowList(ProductList());
            }
            else
            {
                OutputManager.ShowListIsEmpty();
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
                                OutputManager.ShowList(SpecificProductInformation(_productList[searchIndex].ProductName, true));
                                isSearchPresent = true;
                            }                       
                        break;
                    default:
                        OutputManager.ShowInvalidInput();
                        break;
                    }
                if (!isSearchPresent)
                {
                   OutputManager.ShowNoMatches();
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }
    }
}
