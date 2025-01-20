namespace ContactManager.Model
{
    /// <summary>
    /// Defines the Contact Inforamtion
    /// </summary>
    public class Contact
    {
        public string Name;
        public string Email;
        public long PhoneNumber;
        public string Remarks;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name">Represents the name of the contact</param>
        /// <param name="email">Represents the email of the contact</param>
        /// <param name="phoneNumber">Represents the phone number of the contact</param>
        /// <param name="remarks">Represents the remarks of the contact</param>
        public Contact(string name, string email, long phoneNumber, string remarks)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Remarks = remarks;
        }
    }
}
