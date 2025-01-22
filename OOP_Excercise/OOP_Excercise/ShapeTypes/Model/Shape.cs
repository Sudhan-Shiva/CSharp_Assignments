using OOP_TASK1.ShapeTypes.Contents;

namespace OOP_TASK1.ShapeTypes.Model
{
    /// <summary>
    /// Represents the Base Class 'Shape'
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Represents the Colour of the shape
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// Represents the type of the shape
        /// </summary>
        public ShapeType Type {  get; set; }

        /// <summary>
        /// Calculate the area of the shape
        /// </summary>
        /// <returns> Returns the area of the shape </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Print the details of the shape
        /// </summary>
        public string PrintDetails => $"Shape : {Type}\nColor:{Colour}\nArea:{CalculateArea()}\n";
    }
}
