namespace MockFramework
{
    public interface IMockInterface
    {
        public string GetShapeName();

        public int GetNoOfSides(string shapeName);

        public double CalculateArea(int firstSide, int secondSide);
    }
}
