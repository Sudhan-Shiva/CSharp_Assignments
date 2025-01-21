namespace InventoryManager.UserInterface
{
    public class InputManager
    {

        public string GetUserOptions()
        {
            Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Product List\n[S]earch the Product List\n[A]dd new Product\n[M]odify the Product List\n[Q]uickSort the Product List\n[D]elete the Product\n[E]xit the Product List\n");
            Console.Write("Type your Choice: ");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }
        public string GetUniqueInput()
        {
            Console.Write("The Product Field is Already Present !\nGive a new Field : ");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        public string ReplaceInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        public string ReplaceEmptyInput()
        {
            Console.Write("The Provided input is empty !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        public string GetProductName()
        {
            Console.Write("Enter the Product Name :  ");
            string productName = Console.ReadLine();
            return productName;
        }

        public string GetProductId()
        {
            Console.Write("Enter the Product ID :  ");
            string productId = Console.ReadLine();
            return productId;
        }

        public string GetProductPrice()
        {
            Console.Write("Enter the Product Price :  ");
            string productPrice = Console.ReadLine();
            return productPrice;
        }

        public string GetProductQuantity()
        {
            Console.Write("Enter the Product Quantity :  ");
            string productQuantity = Console.ReadLine();
            return productQuantity;
        }

        public string GetEditField()
        {
            Console.WriteLine("Choose the Information that must be edited : \n [N]ame of the Product \n [I]D of the Product \n [P]rice of the Product \n [Q]uantity of the product \n");
            Console.Write("Type your Choice: ");
            string editField = Console.ReadLine();
            return editField;
        }

        public string GetActionField()
        {
            Console.Write("Perform the action by Name or ID ?\n[N]ame/[I]d :");
            string sortOrder = Console.ReadLine();
            return sortOrder;
        }

        public string GetViewSpecificProductChoice()
        {
            Console.Write("Do you want to view the Product Information of any specific Product ?\nY/N : ");
            string viewChoice = Console.ReadLine();
            return viewChoice;
        }


    }

    
}
