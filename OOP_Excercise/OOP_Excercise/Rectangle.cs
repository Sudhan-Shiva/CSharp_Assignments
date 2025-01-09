public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double widthOfRectangle, double heightOfRectangle,string colourOfRectangle)
    {
        Width = widthOfRectangle;
        Height = heightOfRectangle;
        Colour = colourOfRectangle;
    }
    public override double CalculateArea() => Width * Height;
    public override string PrintDetails() => $"Shape : Rectangle\nColor:{Colour}\nArea:{CalculateArea()}\n";
}

