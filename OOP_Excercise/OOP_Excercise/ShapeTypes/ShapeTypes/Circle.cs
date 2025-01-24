using OOP_TASK1.ShapeTypes.Model;
using OOP_TASK1.ShapeTypes.Contents;

namespace OOP_TASK1.ShapeTypes.ShapeTypes
{
    /// <summary>
    /// Represents the Derived class 'Circle'
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Represents the radius of the circle
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Represents the circle
        /// </summary>
        /// <param name="radiusOfCircle">The radius of the circle</param>
        /// <param name="colourOfCircle">The colour of the circle</param>
        public Circle(double radiusOfCircle, string colourOfCircle)
        {
            Radius = radiusOfCircle;
            Colour = colourOfCircle;
            Type = ShapeType.Circle;
        }

        /// <summary>
        /// To calculate the area of the circle
        /// </summary>
        /// <returns> The area of the circle </returns>
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
