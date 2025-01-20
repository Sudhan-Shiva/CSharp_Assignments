using System.Xml.Linq;
using OOP_TASK3.Task3.Model;
using OOP_TASK3.Task3.Contents;

namespace OOP_TASK3.Task3.AccountTypes
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
        public CheckingAccount(int accountNumber, decimal balance)
        {
            Type = AccountType.CheckingAccount;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        /// <summary>
        /// To withdraw from the checking account
        /// </summary>
        /// <param name="withdrawRequest">Amount to be withdrawn</param>
        /// <returns>The details of the withdraw request based on the conditions.</returns>
        public override decimal Withdraw(decimal withdrawRequest)
        {
            if (withdrawRequest < Balance)
            {
                Console.WriteLine($"The amount {withdrawRequest} has been withdrawn from the Checking Account with the account number : {AccountNumber} successfully.");
                Balance = Balance - withdrawRequest;
            }
            else
            {
                Console.WriteLine($"The amount {withdrawRequest} exceeds the remaining balance {Balance} in the Checking Account with the account number : {AccountNumber}.\nCan't withdraw !!!");
            }

            return Balance;
        }
    }
}
