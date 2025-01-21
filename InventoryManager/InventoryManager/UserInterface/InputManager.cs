namespace InventoryManager.UserInterface
{
    public class InputManager
    {
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

        public string GetProductName()
        {
            Console.Write("Enter the Product Name :  ");
            string productName = Console.ReadLine();
            return productName;
        }

        public string GetProductId()
        {
            Console.Write("Enter the Product ID :  ");
            string productName = Console.ReadLine();
            return productName;
        }

        public string GetProductPrice()
        {
            Console.Write("Enter the Product Price :  ");
            string productName = Console.ReadLine();
            return productName;
        }

        public string GetProductQuantity()
        {
            Console.Write("Enter the Product Quantity :  ");
            string productName = Console.ReadLine();
            return productName;
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
