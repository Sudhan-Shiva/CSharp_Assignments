namespace ContactManager.ContactClass
{
    //Define Class to Store the Contact Information
    public class ContactInformation
    {
        public string Name;
        public string Email;
        public long PhoneNumber;
        public string Remarks;

        //Constructor Block
        public ContactInformation(string name, string email, long phoneNumber, string remarks)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Remarks = remarks;
        }
    }
}











