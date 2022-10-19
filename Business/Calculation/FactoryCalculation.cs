using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Calculation
{
    public class FactoryCalculation
    {
        public Employee Employee { get; set; }
        public FactoryCalculation(Employee employee)
        {
            this.Employee = employee;
        }

        public Employee Calculate()
        {
            var objEmployee = new Employee();
            objEmployee.FullName = this.Employee.FullName;
            objEmployee.SalaryCalculated = this.CalculateSalary();


            return objEmployee;
        }

        private long CalculateSalary()
        {
            long sum = 0;

            foreach (WorkedDay w in this.Employee.LstWorkedDay)
            {
                
                if (w.IsDayOfWeek)
                {
                    var salary = new SalaryRateDayOfWeek(w.StrDay, w.HourFrom, w.HourTo);
                    sum += salary.GetRateValue();
                }
                else
                {
                    var salary = new SalaryRateDayWeekend(w.StrDay, w.HourFrom, w.HourTo);
                    sum += salary.GetRateValue();
                }
            }

            return sum;
        }
    }
}
