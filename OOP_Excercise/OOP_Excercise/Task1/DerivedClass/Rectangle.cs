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
        }
        //Override the CalculateArea Method
        public override double CalculateArea() => Width * Height;
        //Override the PrintDetails Method
        public override string PrintDetails() => $"Shape : Rectangle\nColor:{Colour}\nArea:{CalculateArea()}\n";
    }

}
