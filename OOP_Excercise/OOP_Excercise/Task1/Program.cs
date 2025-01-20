using OOP_TASK1.Task1.ShapeTypes;

double widthOfRectangle = 2;
double heightOfRectangle = 7;
string colorOfRectangle = "Blue";

//Instantiate Object of derived class 'Rectangle'
Rectangle rectangle = new Rectangle(widthOfRectangle,heightOfRectangle,colorOfRectangle);

double radiusOfCircle = 2;
string colorOfCircle = "Red";

//Instantiate Object of derived class 'Circle'
Circle circle = new Circle(radiusOfCircle,colorOfCircle);

//Print the details of the object
Console.WriteLine(circle.PrintDetails);
Console.WriteLine(rectangle.PrintDetails);
Console.WriteLine("Press any key to Exit !!");
Console.ReadKey();
