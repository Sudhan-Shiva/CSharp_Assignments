using OOP_TASK2.Task2.BaseClass;

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
            Position = "Manager";
        }
        //Override the CalculateArea Method
        public override decimal CalculateBonus() => (decimal)0.1 * Salary;
    }
}
