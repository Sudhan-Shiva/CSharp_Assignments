using BaseClass;

namespace DerivedClass
{
    /// <summary>
    /// Represents the triangle shape 
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Height of the triangle
        /// </summary>
        private double _height { get; set; }

        /// <summary>
        /// Breadth of the triangle
        /// </summary>
        private double _breadth { get; set; }

        public Triangle(string name, string colour, double height, double breadth)
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
            return 0.50 * _breadth * _height;
        }
    }
}
