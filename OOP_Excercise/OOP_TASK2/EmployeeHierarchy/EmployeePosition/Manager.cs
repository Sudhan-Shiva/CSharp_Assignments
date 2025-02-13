﻿using OOP_TASK2.EmployeeHierarchy.Model;
using OOP_TASK2.EmployeeHierarchy.Contents;

namespace OOP_TASK2.EmployeeHierarchy.EmployeePosition
{
    /// <summary>
    /// Represents the Derived Class 'Manager'
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Constructor Block
        /// </summary>
        /// <param name="name">Name of the manager</param>
        /// <param name="salary">Salary of the manager</param>
        public Manager(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
            Position = JobPosition.Manager;
        }

        /// <summary>
        /// To calculate the bonus of the manager
        /// </summary>
        /// <returns>The bonus of the manager</returns>
        public override decimal CalculateBonus() =>  0.1m * Salary;
    }
}
