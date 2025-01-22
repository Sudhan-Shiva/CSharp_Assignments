using OOP_TASK1.Task1.Model;
using OOP_TASK1.Task1.Contents;

namespace OOP_TASK1.Task1.ShapeTypes
{
    /// <summary>
    /// Represents the Derived class 'Rectangle'
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Represnts the width of the rectangle
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Represents the height of the rectngle
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Represents the shape Rectangle
        /// </summary>
        /// <param name="widthOfRectangle">The width of the rectangle</param>
        /// <param name="heightOfRectangle">The height of the rectangle</param>
        /// <param name="colourOfRectangle">The colour of the rectangle</param>
        public Rectangle(double widthOfRectangle, double heightOfRectangle, string colourOfRectangle)
        {
            Width = widthOfRectangle;
            Height = heightOfRectangle;
            Colour = colourOfRectangle;
            Type = ShapeType.Rectangle;
        }
        /// <summary>
        /// Override the CalculateArea Method of the base class
        /// </summary>
        /// <returns>The area of the rectangle</returns>
        public override double CalculateArea() => Width * Height;
    }
}
