using OOP_TASK2.Task2.EmployeePosition;

string nameOfManager = "John";
decimal salaryOfManager = 60000;

//Instantiate Object of derived class 'Rectangle'
Manager manager = new Manager(nameOfManager,salaryOfManager);

string nameOfDeveloper = "Eren";
decimal salaryOfDeveloper = 40000;

//Instantiate Object of derived class 'Circle'
Developer developer = new Developer(nameOfDeveloper,salaryOfDeveloper);

//Print the details of the object
Console.WriteLine(manager.PrintDetails);
Console.WriteLine(developer.PrintDetails);
Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
