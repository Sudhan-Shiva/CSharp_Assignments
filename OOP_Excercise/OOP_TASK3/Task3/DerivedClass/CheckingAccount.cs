using System.Xml.Linq;
using OOP_TASK3.Task3.BaseClass;
using OOP_TASK3.Task3.Contents;

namespace OOP_TASK3.Task3.DerivedClass
{
    //Implement Derived Class 'CheckingAccount'
    public class CheckingAccount : BankAccount
    {
        //Constructor Block
        public CheckingAccount(int accountNumber, decimal balance)
        {
            Type = AccountType.CheckingAccount;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        //Override the Withdraw Method
        public override decimal Withdraw(decimal withdrawRequest)
        {
            if (withdrawRequest < Balance)
            {
                Console.WriteLine($"The amount {withdrawRequest} has been withdrawn from the Checking Account with the account number : {AccountNumber} successfully.");
                Balance = Balance - withdrawRequest;
            }
            // If Withdrawal Amount is greater than the remaining balance
            else
            {
                Console.WriteLine($"The amount {withdrawRequest} exceeds the remaining balance {Balance} in the Checking Account with the account number : {AccountNumber}.\nCan't withdraw !!!");
            }
            return Balance;
        }
    }
}