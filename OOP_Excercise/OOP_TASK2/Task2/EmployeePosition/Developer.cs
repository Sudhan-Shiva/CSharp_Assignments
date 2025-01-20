using OOP_TASK2.Task2.Model;
using OOP_TASK2.Task2.Contents;

namespace OOP_TASK2.Task2.EmployeePosition
{
    /// <summary>
    /// Represents the Derived Class 'Developer'
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Constructor Block
        /// </summary>
        /// <param name="name">Name of the Employee</param>
        /// <param name="salary">Salary of the Employee</param>
        public Developer(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
            Position = JobPosition.Developer;
        }

        /// <summary>
        /// To calculate the bonus of the developer
        /// </summary>
        /// <returns>The bonus of the developer</returns>
        public override decimal CalculateBonus() => 0.01m * Salary;
    }
}
