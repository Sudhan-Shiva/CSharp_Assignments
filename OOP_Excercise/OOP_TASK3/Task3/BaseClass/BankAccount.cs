using OOP_TASK3.Task3.Contents;

namespace OOP_TASK3.Task3.BaseClass
{
    //Implement the Base Class 'BankAccount'
    public abstract class BankAccount
    {
        //Define the property 'AccountNumber'
        public int AccountNumber { get; set; }
        //Define the property 'Balance'
        public decimal Balance { get; set; }
        //Define the property 'TypeOfAccount'
        public AccountType Type { get; set; }
        //Define Method 'Deposit' to deposit the requested amount into the account
        public string Deposit(decimal depositAmount)
        {
            Balance += depositAmount;
            return $"The amount {depositAmount} is deposited into the account with the account number : {AccountNumber} and the remaining balance is {Balance}.\n";
        }
        //Define the abstarct method 'Withdraw'to perform withdrawal of the requested amount based on the account type
        public abstract decimal Withdraw(decimal withdrawAmount);
        //Define Abstract Method 'PrintDetails' to print the account details
        public string PrintDetails() => $"Type : {Type}\nAccount Number:{AccountNumber}\nBalance:{Balance}\n";
    }
}
