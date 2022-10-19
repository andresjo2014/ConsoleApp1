using Business.Calculation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business
{
    public class FileReaderAnalyzer
    {
        public StreamReader Stream { get; set; }
        public Dictionary<string, List<string>> DicRecorEmployee { get; set; }

        public List<Employee> LstEmployees { get; set; }
        public FileReaderAnalyzer(StreamReader stream)
        {
            this.Stream = stream;
            this.DicRecorEmployee = new Dictionary<string, List<string>>();
            this.LstEmployees = new List<Employee>();

            var file = new FileValidator(stream);
            file.Validate();
            if(!string.IsNullOrEmpty(file.MsgResult))
            {
                throw new Exception(file.MsgResult);
            }
            this.DicRecorEmployee = file.DicRecordEmployee;

        }

        public List<Employee> GetListEmployees()
        {
            
            foreach (KeyValuePair<string,List<string>> key in this.DicRecorEmployee)
            {
                List<WorkedDay> lstWorkedDays = new List<WorkedDay>();
                var employee = new Employee();
                employee.FullName = key.Key;

                var lst = this.DicRecorEmployee[key.Key];

                foreach (string strWD in lst)
                {
                    List<WorkedDay> lstDev = this.GetParserWorkedDay(strWD);
                    lstWorkedDays.AddRange(lstDev);
                }
                employee.LstWorkedDay = lstWorkedDays;
                this.LstEmployees.Add(employee);
          
            }

            return this.LstEmployees;
        }

        private List<WorkedDay> GetParserWorkedDay(string strLine)
        {
            List<WorkedDay> lstWorkedDays = new List<WorkedDay>();
            

            string[] arg = strLine.Split(",");

            if (arg.Length == 0)
            {
                var workDay = new WorkedDay();
                this.SetUnderScoreData(strLine, workDay);
                lstWorkedDays.Add(workDay);
            }
            else
            {
                foreach (string strArg in arg)
                {
                    var workDay = new WorkedDay();
                    this.SetUnderScoreData(strArg, workDay);
                    lstWorkedDays.Add(workDay);
                }
            }

            return lstWorkedDays;
        }

        private void SetUnderScoreData(string strLine, WorkedDay workDay)
        {
            string[] arg = strLine.Split("-");
            string strParseFromDay = arg[0];
            string strParseTo = arg[1];

            string strDay = strParseFromDay.Substring(0, 2);
            string strHourFrom = strParseFromDay.Substring(2, 5);

            workDay.StrDay = strDay;
            DateTime d = DateTime.Parse("2000/01/01");
            d= d.AddHours(double.Parse(strHourFrom.Substring(0, 2)));
            d= d.AddMinutes(double.Parse(strHourFrom.Substring(3, 2)));
            workDay.HourFrom = d;

            DateTime dTo = DateTime.Parse("2000/01/01");
            dTo = dTo.AddHours(double.Parse(strParseTo.Substring(0, 2)));
            dTo= dTo.AddMinutes(double.Parse(strParseTo.Substring(3, 2)));
            workDay.HourTo = dTo;

        }
    }

    
}
