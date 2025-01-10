using System.Drawing;
using System.Xml.Linq;
using OOP_TASK3.Task3.DerivedClass;

//Instantiate Object of derived class 'SavingsAccount'
SavingsAccount savingsAccount1 = new SavingsAccount("543678", (decimal)10000);

//Instantiate Object of derived class 'CheckingAccount'
CheckingAccount checkingAccount1 = new CheckingAccount("567834290", (decimal)20000);

//Instantiate Another Object of derived class 'SavingsAccount'
SavingsAccount savingsAccount2 = new SavingsAccount("12345", (decimal)800);

//Instantiate Another Object of derived class 'CheckingAmount'
CheckingAccount checkingAccount2 = new CheckingAccount("1234567890", (decimal)500);

//Print the details of the first account
Console.WriteLine(savingsAccount1.PrintDetails());
Console.WriteLine(checkingAccount1.PrintDetails());

//Withdraw the requested amount
Console.WriteLine($"The Remaining amount in the account :{savingsAccount1.Withdraw((decimal)6000)}\n");
Console.WriteLine($"The Remaining amount in the account :{checkingAccount1.Withdraw((decimal)7000)}\n");

//Deposit the requested amount
Console.WriteLine(savingsAccount1.Deposit((decimal)600));
Console.WriteLine(checkingAccount1.Deposit((decimal)800));

Console.WriteLine(savingsAccount2.PrintDetails());
Console.WriteLine(checkingAccount2.PrintDetails());

Console.WriteLine($"The Remaining amount in the account :{savingsAccount2.Withdraw((decimal)500)} \n");
Console.WriteLine($"The Remaining amount in the account :{checkingAccount2.Withdraw((decimal)700)}\n");

Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
