using System.Drawing;
using OOP_TASK2.Task2.DerivedClass;

//Instantiate Object of derived class 'Rectangle'
Manager manager = new Manager("John",(decimal)60000);

//Instantiate Object of derived class 'Circle'
Developer developer = new Developer("Eren",(decimal)40000);

//Print the details of the object
Console.WriteLine(manager.PrintDetails);
Console.WriteLine(developer.PrintDetails);
Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
