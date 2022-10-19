using Business.Calculation;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class SalaryEmployeeHandler
    {
        public string FullPath { get; set; }

        public Dictionary<string, long> DicSalary { get; set; }
        public SalaryEmployeeHandler(string strPath)
        {
            this.FullPath = strPath;
            this.DicSalary = new Dictionary<string, long>();
        }
        public List<Employee> ProccesFiles()
        {
            var repo = new RepositoryFileDB(this.FullPath);
            var fileReader = new FileReaderAnalyzer(repo.Stream);

            var listEmployees = fileReader.GetListEmployees();

            var salaryCalculation = new EmployeeSalaryCalculation(listEmployees);
            var lst = salaryCalculation.CalculationProcess();

            return lst;
        }
    }
}
