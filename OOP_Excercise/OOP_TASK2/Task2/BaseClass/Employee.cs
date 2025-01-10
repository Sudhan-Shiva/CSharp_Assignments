namespace OOP_TASK2.Task2.BaseClass
{
    //Implement the Base Class 'Shape'
    public abstract class Employee
    {
        //Define the property 'Name'
        public string Name { get; set; }
        //Define the property 'Salary'
        public decimal Salary { get; set; }
        //Define Abstract Method 'CalculateBonus'
        public abstract decimal CalculateBonus();
        //Define Abstract Method 'PrintDetails'
        public abstract string PrintDetails();
    }
}