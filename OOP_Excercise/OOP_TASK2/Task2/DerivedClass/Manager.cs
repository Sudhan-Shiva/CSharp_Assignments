using OOP_TASK2.Task2.BaseClass;
using OOP_TASK2.Task2.Contents;

namespace OOP_TASK2.Task2.DerivedClass
{
    //Implement Derived Class 'Manager'
    public class Manager : Employee
    {
        //Constructor Block
        public Manager(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
            Position = JobPosition.Manager;
        }
        //Override the CalculateArea Method
        public override decimal CalculateBonus() =>  0.1m * Salary;
    }
}
