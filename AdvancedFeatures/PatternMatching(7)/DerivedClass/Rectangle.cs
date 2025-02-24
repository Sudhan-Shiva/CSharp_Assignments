using BaseClass;

namespace DerivedClass
{
    /// <summary>
    /// Represents the rectangle shape 
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        private double _height { get; set; }

        /// <summary>
        /// Breadth of the rectangle
        /// </summary>
        private double _breadth { get; set; }

        public Rectangle(string name, string colour, double height, double breadth)
        {
            Name = name;
            ShapeColour = colour;
            _height = height;
            _breadth = breadth;
        }

        /// <summary>
        /// To calculate the area of the triangle
        /// </summary>
        /// <returns>The area of the triangle</returns>
        public double CalculateArea()
        {
            return _breadth * _height;
        }
    }
}
