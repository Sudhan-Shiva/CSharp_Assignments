using OOP_TASK2.Task2.BaseClass;
using OOP_TASK2.Task2.Contents;
namespace OOP_TASK2.Task2.DerivedClass
{
    //Implement Derived Class 'Developer'
    public class Developer : Employee
    {
        //Constructor Block
        public Developer(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
            Position = JobPosition.Developer;
        }
        //Override the CalculateBonus Method
        public override decimal CalculateBonus() => 0.01m * Salary;
    }
}
