using OOP_TASK1.Task1.BaseClass;

namespace OOP_TASK1.Task1.DerivedClass
{
    //Define Derived class 'Rectangle'
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }
        //Constructor Block
        public Rectangle(double widthOfRectangle, double heightOfRectangle, string colourOfRectangle)
        {
            Width = widthOfRectangle;
            Height = heightOfRectangle;
            Colour = colourOfRectangle;
            ShapeType = "Rectangle";
        }
        //Override the CalculateArea Method
        public override double CalculateArea() => Width * Height;
    }
}
