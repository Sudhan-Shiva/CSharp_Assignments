using OOP_TASK2.EmployeeHierarchy.Contents;

namespace OOP_TASK2.EmployeeHierarchy.Model
{
    /// <summary>
    /// Represents the Base Class 'Employee'
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Represents the name of the employee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the salary of the employee
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Represents the job position of the employee
        /// </summary>
        public JobPosition Position {  get; set; }

        /// <summary>
        /// To calculate the bonus of the employee based on the position
        /// </summary>
        /// <returns>The Bonus of the employee</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// To print the details of the employee
        /// </summary>
        public string PrintDetails => $"Position : {Position}\nName:{Name}\nSalary:{Salary}\nBonus:{CalculateBonus()}\n";
    }
}
