using OOP_TASK2.Task2.BaseClass;

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
        }
        //Override the CalculateBonus Method
        public override decimal CalculateBonus() => (decimal)0.01 * Salary;
        //Override the PrintDetails Method
        public override string PrintDetails() => $"Position : Developer\nName:{Name}\nSalary:{Salary}\nBonus:{CalculateBonus()}\n";
    }
}
