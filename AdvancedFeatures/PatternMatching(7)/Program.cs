using BaseClass;
using DerivedClass;

/// <summary>
/// Entry point Class
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the entry point
    /// </summary>
    static void Main()
    {
        List<Shape> shapesList = new List<Shape>();

        Circle circle = new Circle("Circle", "Red", 3.2);
        shapesList.Add(circle);

        Rectangle rectangle = new Rectangle("Rectangle", "Black", 10, 20.5);
        shapesList.Add(rectangle);

        Triangle triangle = new Triangle("Triangle", "White", 25, 25);
        shapesList.Add(triangle);

        shapesList.Add(null);

        Shape shape = new Shape();
        shape.Name = "New Shape";
        shape.ShapeColour = "Whatever";
        shapesList.Add(shape);

        foreach (Shape testShape in shapesList)
        {
            DisplayShapeDetails(testShape);
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    /// <summary>
    /// To display the details of the shape
    /// </summary>
    /// <param name="shape">The shape whose details must be displayed</param>
    static void DisplayShapeDetails(Shape shape)
    {
        switch (shape)
        {
            case Rectangle :
                Rectangle rectangle = (Rectangle) shape;
                Console.WriteLine($"Shape Name : {shape.Name}");
                Console.WriteLine($"Shape Colour : {shape.ShapeColour}");
                Console.WriteLine("Area of Rectangle : "+rectangle.CalculateArea());
                break;
            case Triangle:
                Triangle triangle = (Triangle) shape;
                Console.WriteLine($"Shape Name : {shape.Name}");
                Console.WriteLine($"Shape Colour : {shape.ShapeColour}");
                Console.WriteLine("Area of Triangle : " + triangle.CalculateArea());
                break;
            case Circle:
                Circle circle = (Circle) shape;
                Console.WriteLine($"Shape Name : {shape.Name}");
                Console.WriteLine($"Shape Colour : {shape.ShapeColour}");
                Console.WriteLine("Area of Circle : " + circle.CalculateArea());
                break;
            case null:
                Console.WriteLine("The shape is null !!!!");
                break;
            default:
                Console.WriteLine($"'{shape.Name}' is an invalid shape !!!");
                break;
        }
    }
}
