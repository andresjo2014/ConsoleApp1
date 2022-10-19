using Business.Calculation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Employee
    {
        public Employee()
        {
            this.LstWorkedDay = new List<WorkedDay>();
        }
        public string FullName { get; set; }
        public long SalaryCalculated { get; set; }
        public List<WorkedDay> LstWorkedDay { get; set; }
        
    }
}
