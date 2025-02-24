using BaseClass;

namespace DerivedClass
{
    /// <summary>
    /// Represents the circle shape 
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        private double _radius { get; set; }

        public Circle(string name, string colour, double radius)
        {
            _radius = radius;
            Name = name;
            ShapeColour = colour;
        }

        /// <summary>
        /// To calculate the area of the circle
        /// </summary>
        /// <returns>The area of the circle</returns>
        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
