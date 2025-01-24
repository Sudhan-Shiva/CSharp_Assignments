using OOP_TASK3.BankAccountTypes.AccountTypes;

string accNoOfSavingsAcc1 = "12345";
decimal balanceOfSavingsAcc1 = 10000;

//Instantiate Object of derived class 'SavingsAccount'
SavingsAccount savingsAccount1 = new SavingsAccount(accNoOfSavingsAcc1, balanceOfSavingsAcc1);

string accNoOfCheckingAcc1 = "54321";
decimal balanceOfCheckingAcc1 = 20000;

//Instantiate Object of derived class 'CheckingAccount'
CheckingAccount checkingAccount1 = new CheckingAccount(accNoOfCheckingAcc1, balanceOfCheckingAcc1);

string accNoOfSavingsAcc2 = "123456789";
decimal balanceOfSavingsAcc2 = 800;

//Instantiate Another Object of derived class 'SavingsAccount'
SavingsAccount savingsAccount2 = new SavingsAccount(accNoOfSavingsAcc2, balanceOfSavingsAcc2);

string accNoOfCheckingAcc2 = "987654321";
decimal balanceOfCheckingAcc2 = 500;

//Instantiate Another Object of derived class 'CheckingAmount'
CheckingAccount checkingAccount2 = new CheckingAccount(accNoOfCheckingAcc2, balanceOfCheckingAcc2);

//Print the details of the first account
Console.WriteLine(savingsAccount1.PrintDetails());
Console.WriteLine(checkingAccount1.PrintDetails());

decimal withdrawAmount1 = 6000;
decimal withdrawAmount2 = 7000;

//Withdraw the requested amount
Console.WriteLine($"The Remaining amount in the account :{savingsAccount1.Withdraw(withdrawAmount1)}\n");
Console.WriteLine($"The Remaining amount in the account :{checkingAccount1.Withdraw(withdrawAmount2)}\n");

decimal depositAmount1 = 600;
decimal depositAmount2 = 800;

//Deposit the requested amount
Console.WriteLine(savingsAccount1.Deposit(depositAmount1));
Console.WriteLine(checkingAccount1.Deposit(depositAmount2));

Console.WriteLine(savingsAccount2.PrintDetails());
Console.WriteLine(checkingAccount2.PrintDetails());

decimal withdrawAmount3 = 500;
decimal withdrawAmount4 = 700;

Console.WriteLine($"The Remaining amount in the account :{savingsAccount2.Withdraw(withdrawAmount3)} \n");
Console.WriteLine($"The Remaining amount in the account :{checkingAccount2.Withdraw(withdrawAmount4)}\n");

Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
