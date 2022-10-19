using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Calculation
{
    public class EmployeeSalaryCalculation
    {
        public List<Employee> Employees { get; set; }
        public EmployeeSalaryCalculation(List<Employee> employees)
        {
            this.Employees = employees;
        }

        public List<Employee> CalculationProcess()
        {

            var salaryEmployees = new List<Employee>();

            foreach (var employee in this.Employees)
            {
                var employeeCalculated = new FactoryCalculation(employee).Calculate();
                salaryEmployees.Add(employeeCalculated);
            }


            return salaryEmployees;
        }
    }
}
