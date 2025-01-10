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
        }
        //Override the CalculateArea Method
        public override double CalculateArea() => Math.PI * Radius * Radius;
        //Override the PrintDetails Method
        public override string PrintDetails() => $"Shape : Circle\nColor:{Colour}\nArea:{CalculateArea()}\n";
    }

}
