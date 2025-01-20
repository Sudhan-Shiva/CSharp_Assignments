﻿using OOP_TASK3.Task3.BaseClass;
using OOP_TASK3.Task3.Contents;

namespace OOP_TASK3.Task3.DerivedClass
{
    //Implement Derived Class 'SavingsAccount'
    public class SavingsAccount : BankAccount
    {
        //Constructor Block
        public SavingsAccount(int accountNumber, decimal balance)
        {
            Type = AccountType.SavingsAccount;
            AccountNumber = accountNumber;
            Balance = balance;
        }
        private const decimal MinBalance = 1000;
        //Override the Withdraw Method
        public override decimal Withdraw(decimal withdrawRequest)
        {
            //if the remaining balance is less than the minimum balance
            if (Balance <= MinBalance)
            {
                Console.WriteLine($"The Balance Amount : {Balance} in the Savings Account with the account number : {AccountNumber} is below the Minimum Balance:{MinBalance}.\nCan't Withdraw !!!");
            }
            //if all the conditions for the withdrawal process is satisfied
            else if (Balance - withdrawRequest >= MinBalance)
            {
                Console.WriteLine($"The amount {withdrawRequest} has been withdrawn from the Savings Account with the account number : {AccountNumber} successfully.");
                Balance = Balance - withdrawRequest;
            }
            // if withdrawing the requested amount brings down the remaining balance below the minimum balance
            else
            {
                Console.WriteLine($"The amount {withdrawRequest} lowers the Remaining Balance : {Balance} below the Minimum Limit : {MinBalance} in the Savings Account with the account number : {AccountNumber}.\nCan't withdraw !!!");
            }
            return Balance;
        }
    }
}

