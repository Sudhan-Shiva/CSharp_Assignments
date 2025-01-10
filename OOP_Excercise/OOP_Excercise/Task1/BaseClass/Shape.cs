namespace OOP_Excercise.Task1.BaseClass
{
    //Define the Base Class 'Shape'
    public abstract class Shape
    {
        //Define the property 'Colour'
        public string Colour { get; set; }
        //Define Abstract Method 'CalculateArea'
        public abstract double CalculateArea();
        //Define Abstract Method 'PrintDetails'
        public abstract string PrintDetails();
    }

}


