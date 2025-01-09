public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radiusOfCircle,string colourOfCircle)
    {
        Radius = radiusOfCircle;
        Colour = colourOfCircle;
    }
    public override double CalculateArea() => Math.PI * Radius * Radius;
    public override string PrintDetails() => $"Shape : Circle\nColor:{Colour}\nArea:{CalculateArea()}\n";
}

