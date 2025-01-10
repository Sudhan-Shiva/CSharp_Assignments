using OOP_Excercise.Task1.DerivedClass;

//Instantiate Object of derived class 'Rectangle'
Rectangle rectangle = new Rectangle(2,7,"Blue");

//Instantiate Object of derived class 'Circle'
Circle circle = new Circle(2,"Red");

//Print the details of the object
Console.WriteLine(circle.PrintDetails());
Console.WriteLine(rectangle.PrintDetails());
Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
