using OOP_TASK1.Task1.BaseClass;

namespace OOP_TASK1.Task1.DerivedClass
{
    //Define Derived class 'Circle'
    public class Circle : Shape
    {
        public double Radius { get; }

        //Constructor Block
        public Circle(double radiusOfCircle, string colourOfCircle)
        {
            Radius = radiusOfCircle;
            Colour = colourOfCircle;
            ShapeType = "Circle";
        }
        //Override the CalculateArea Method
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
