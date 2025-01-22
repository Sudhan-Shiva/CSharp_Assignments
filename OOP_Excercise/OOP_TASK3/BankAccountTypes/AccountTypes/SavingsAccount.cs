using OOP_TASK3.BankAccountTypes.Model;
using OOP_TASK3.BankAccountTypes.Contents;

namespace OOP_TASK3.BankAccountTypes.AccountTypes
{
    /// <summary>
    /// Represent the Derived Class 'SavingsAccount'
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Constructor Block
        /// </summary>
        /// <param name="accountNumber">Represents the account number of the savings account</param>
        /// <param name="balance">Represents the remaining balance of the savings account</param>
        public SavingsAccount(string accountNumber, decimal balance)
        {
            Type = AccountType.SavingsAccount;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        /// <summary>
        /// Represents the minimum balance of the savings account
        /// </summary>
        private const decimal MinBalance = 1000;

        /// <summary>
        /// To withdraw from the savings account
        /// </summary>
        /// <param name="withdrawRequest">Amount to be withdrawn</param>
        /// <returns>Details of the withdrawal request based on the conditions of the savings account</returns>
        public override decimal Withdraw(decimal withdrawRequest)
        {
            
            if (Balance <= MinBalance)
            {
                Console.WriteLine($"The Balance Amount : {Balance} in the Savings Account with the account number : {AccountNumber} is below the Minimum Balance:{MinBalance}.\nCan't Withdraw !!!");
            }           
            else if (Balance - withdrawRequest >= MinBalance)
            {
                Console.WriteLine($"The amount {withdrawRequest} has been withdrawn from the Savings Account with the account number : {AccountNumber} successfully.");
                Balance = Balance - withdrawRequest;
            }
            else
            {
                Console.WriteLine($"The amount {withdrawRequest} lowers the Remaining Balance : {Balance} below the Minimum Limit : {MinBalance} in the Savings Account with the account number : {AccountNumber}.\nCan't withdraw !!!");
            }

            return Balance;
        }
    }
}
