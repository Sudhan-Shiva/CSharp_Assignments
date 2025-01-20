using OOP_TASK2.Task2.Contents;

namespace OOP_TASK2.Task2.BaseClass
{
    //Implement the Base Class 'Shape'
    public abstract class Employee
    {
        //Define the property 'Name'
        public string Name { get; set; }
        //Define the property 'Salary'
        public decimal Salary { get; set; }
        //Define the property 'Position'
        public JobPosition Position {  get; set; }
        //Define Abstract Method 'CalculateBonus' to calculate the bonus of the employee based on the position
        public abstract decimal CalculateBonus();
        //Define Method 'PrintDetails' to print the details of the employee
        public string PrintDetails => $"Position : {Position}\nName:{Name}\nSalary:{Salary}\nBonus:{CalculateBonus()}\n";
    }
}