using OOP_TASK1.Task1.Contents;

namespace OOP_TASK1.Task1.BaseClass
{
    //Define the Base Class 'Shape'
    public abstract class Shape
    {
        //Define the property 'Colour'
        public string Colour { get; set; }
        //Define the property 'ShapeType'
        public ShapeType Type {  get; set; }
        //Define Abstract Method 'CalculateArea'
        public abstract double CalculateArea();
        //Define Method 'PrintDetails' to print the details of the shape
        public string PrintDetails => $"Shape : {Type}\nColor:{Colour}\nArea:{CalculateArea()}\n";
    }
}


