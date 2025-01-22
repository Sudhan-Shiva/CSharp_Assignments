using OOP_TASK3.BankAccountTypes.Model;
using OOP_TASK3.BankAccountTypes.Contents;

namespace OOP_TASK3.BankAccountTypes.AccountTypes
{
    /// <summary>
    /// Represents the Derived Class 'CheckingAccount'
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Constructor Block
        /// </summary>
        /// <param name="accountNumber">Account number of the checking account</param>
        /// <param name="balance">Remaining balance amount of the checking amount</param>
        public CheckingAccount(string accountNumber, decimal balance)
        {
            Type = AccountType.CheckingAccount;
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
