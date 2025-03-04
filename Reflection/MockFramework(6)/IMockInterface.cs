namespace MockFramework
{
    /// <summary>
    /// Interface which is to be mocked
    /// </summary>
    public interface IMockInterface
    {
        /// <summary>
        /// Method which gets the name of the shape
        /// </summary>
        /// <returns>The name of the shape</returns>
        public string GetShapeName();

        /// <summary>
        /// Method which gets the number of sides in a shape
        /// </summary>
        /// <param name="shapeName">The name of the shape</param>
        /// <returns>The number of sides in a shape</returns>
        public int GetNoOfSides(string shapeName);

        /// <summary>
        /// Method to calculate the area of the given shape
        /// </summary>
        /// <param name="firstSide">The side of the shape</param>
        /// <param name="secondSide">The side of the shape</param>
        /// <returns>The area of the shape</returns>
        public double CalculateArea(int firstSide, int secondSide);
    }
}
