using Business;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter full path of Salary files");
                string strPath = Console.ReadLine();

                try
                {
                    var lst = new SalaryEmployeeHandler(strPath).ProccesFiles();

                    foreach (Employee employee in lst)
                    {
                        Console.WriteLine("Employee Name: " + employee.FullName + " Salary: " + employee.SalaryCalculated.ToString());
                        Console.WriteLine(Environment.NewLine);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Execption-----------");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Do you want to contiue Y/N or different key to close the program");
                string answer = Console.ReadLine();

                if(answer!="Y")
                {
                    break;
                }
            }
            


            
        }



    }
}
