using OOP_TASK3.Task3.Contents;

namespace OOP_TASK3.Task3.Model
{
    /// <summary>
    /// Represents the Base Class 'BankAccount'
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Represents the Account Number of the Bank Account
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Represents the Balance of the Bank Account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Represents the Type of the Bank Account
        /// </summary>
        public AccountType Type { get; set; }

        /// <summary>
        /// Define Method 'Deposit' to deposit the requested amount into the account
        /// </summary>
        /// <param name="depositAmount">Amount to be deposited</param>
        /// <returns>The details of the deposit process and the remaining balance.</returns>
        public string Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
            return $"The amount {depositAmount} is deposited into the account with the account number : {AccountNumber} and the remaining balance is {Balance}.\n";
        }

        /// <summary>
        /// To perform withdrawal of the requested amount based on the account type
        /// </summary>
        /// <param name="withdrawAmount">Amount to be withdrawn.</param>
        /// <returns>The details of the withdraw process and the remaining balance.</returns>
        public abstract decimal Withdraw(decimal withdrawAmount);

        /// <summary>
        /// To print the Account details
        /// </summary>
        /// <returns>The details of the account</returns>
        public string PrintDetails() => $"Type : {Type}\nAccount Number:{AccountNumber}\nBalance:{Balance}\n";
    }
}
