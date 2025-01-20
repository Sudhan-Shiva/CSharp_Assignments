namespace ContactManager.Model
{
    //Define Class to Store the Contact Information
    public class Contact
    {
        public string Name;
        public string Email;
        public long PhoneNumber;
        public string Remarks;

        //Constructor Block
        public Contact(string name, string email, long phoneNumber, string remarks)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Remarks = remarks;
        }
    }
}
