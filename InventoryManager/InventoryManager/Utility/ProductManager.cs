using InventoryManager.UserInterface;
using InventoryManager.Model;
using InventoryManager.ValidInput;
using ConsoleTables;
using System.Buffers;

namespace InventoryManager.Utility
{
    public class ProductManager
    {
        private List<Product> _productList = [];
        DataValidation dataValidation;
        InputManager inputManager;
        
        public ProductManager(DataValidation mainDataValidation, InputManager mainInputManager)
        {
            dataValidation = mainDataValidation ;
            inputManager = mainInputManager ;
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
                inputParameter = inputManager.GetUniqueInput();
            }
            return inputParameter;
        }
        public int GetValidInteger(string inputParameter)
        {          
            while (!dataValidation.IsDataValid(inputParameter))
            {
                inputParameter = inputManager.ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }
        public decimal GetValidDecimal(string inputParameter)
        {
            while (!dataValidation.IsProductPriceValid(inputParameter))
            {
                inputParameter = inputManager.ReplaceInvalidInput();
            }
            decimal.TryParse(inputParameter, out decimal validData);
            return validData;
        }
        public int ReturnIndex(string inputParameter, bool isProductName)
        {
            if (isProductName)
            {
                return _productList.FindIndex(x => x.ProductName == inputParameter);
            }
            else
            {
                return _productList.FindIndex(x => x.ProductId == GetValidInteger(inputParameter));
            }
        }

        public ConsoleTable SpecificProductInformation(string viewProduct, bool isProductName)
        {
            int printIndex = ReturnIndex(viewProduct, isProductName);
            //If returned index is -1, it means that either the given input is invalid or it is not present in the list
            while (printIndex == -1)
            {
                viewProduct  = inputManager.ReplaceInvalidInput();
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
        public bool FindProductName(string productNameHint)
        {
            bool isSearchPresent = false;
            foreach (Product searchproduct in _productList)
            {
                if (searchproduct.ProductName.Contains(productNameHint))
                {
                    Console.WriteLine($"Product Name : {searchproduct.ProductName}\n" +
                                      $" Product ID : {searchproduct.ProductId}\n");
                    isSearchPresent = true;
                }
            }
            return isSearchPresent;
        }
        //Method to add new products in the list
        public void AddProduct()
        {
            string productName = GetDistinctInputs(inputManager.GetProductName(), true);
            int productId = GetValidInteger(GetDistinctInputs(inputManager.GetProductId(), false));
            decimal productPrice = GetValidDecimal(inputManager.GetProductPrice());
            int productQuantity = GetValidInteger(inputManager.GetProductQuantity());
            Product product = new Product(productId, productName, productPrice, productQuantity);
            _productList.Add(product);
            OutputManager.ShowSuccessfulAddition();
            OutputManager.ShowList(SpecificProductInformation(productName, true));
        }
        //Method to delete products in the list
        public void DeleteProduct()
        {
            if (_productList.Count > 0)
            {
                string deleteChoice = inputManager.GetProductName();
                int deleteIndex = ReturnIndex(deleteChoice, true);
                while (deleteIndex == -1)
                {
                    deleteChoice = inputManager.ReplaceInvalidInput();
                    deleteIndex = ReturnIndex(deleteChoice, true);
                }
                OutputManager.ShowSuccessfulDeletion();
                _productList.RemoveAt(deleteIndex);
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }
        //Method to modify product information in the list
        public void ModifyProduct()
        {
            if (_productList.Count > 0)
            {
                string editChoice = inputManager.GetProductName();            
                string editField = inputManager.GetEditField();
                switch (editField.ToUpper())
                {
                    case "N":
                        _productList[ReturnIndex(editChoice, true)].ProductName = GetDistinctInputs(inputManager.GetProductName(), true);
                        break;
                    case "I":
                        _productList[ReturnIndex(editChoice, true)].ProductId = GetValidInteger(GetDistinctInputs(inputManager.GetProductId(), false));
                        break;
                    case "P":
                        _productList[ReturnIndex(editChoice, true)].ProductPrice = GetValidDecimal(inputManager.GetProductPrice());
                        break;
                    case "Q":
                        _productList[ReturnIndex(editChoice, true)].ProductQuantity = GetValidInteger(inputManager.GetProductQuantity());
                        break;
                    default:
                        OutputManager.ShowInvalidInput();
                        break;
                }
                OutputManager.ShowList(SpecificProductInformation(editChoice,true));
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }

        //Method to sort the products in the list
        public void SortProduct()
        {
            if (_productList.Count > 0)
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
                    OutputManager.ShowInvalidInput();
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }

        //Method to view the product names in the list
        public void ViewProduct()
        {
            if (_productList.Count > 0)
            {
                OutputManager.ShowList(ProductNames());
                string viewChoice = inputManager.GetViewSpecificProductChoice();
                while (viewChoice.ToUpper() != "Y" || viewChoice.ToUpper() != "N")
                {
                    inputManager.ReplaceInvalidInput();
                }
                if (viewChoice.ToUpper() == "Y")
                {
                    string searchField = inputManager.GetActionField();
                    while (searchField.ToUpper() != "I" && searchField.ToUpper() != "N")
                    {
                        searchField = inputManager.ReplaceInvalidInput();
                    }
                    bool isProductName = (searchField.ToUpper() == "N") ? true : false;
                    string searchValue;
                    if (isProductName) { searchValue = inputManager.GetProductName(); }
                    else { searchValue = inputManager.GetProductId(); }
                    OutputManager.ShowList(SpecificProductInformation(searchValue, isProductName));
                }
            }
            else
            {
                OutputManager.ShowListIsEmpty();
            }
        }

        //Method to search for a particular product in the list
        public void SearchProduct()
        {
            if (_productList.Count > 0)
            {
                string searchByChoice = inputManager.GetActionField();
                bool isSearchPresent = false;
                switch(searchByChoice.ToUpper())
                {
                    case "N":
                        string productNameHint = inputManager.GetProductName();
                        isSearchPresent = FindProductName(productNameHint); 
                        break;
                    case "I":
                        string productIdHint = inputManager.GetProductId();
                        OutputManager.ShowNameAndId(_productList[ReturnIndex(productIdHint, false)].ProductName, _productList[ReturnIndex(productIdHint, false)].ProductId);
                        isSearchPresent = true;
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