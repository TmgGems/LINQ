using System;
using TCPData;
using TCPExtensions;
namespace ThePretendCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employeeList = Data.GetEmployees();
            //var filteredEmployees = employeeList.Filter( emp => emp.AnnualSalary >= 500 );

            //foreach(var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"First Name : {employee.FirstName}");
            //    Console.WriteLine($"Last Name : {employee.LastName}");
            //    Console.WriteLine($"Annual Salary : {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager :{employee.IsManager}");
            //    Console.WriteLine();
            //}
            
            List<Department> departmentList = Data.GetDepartments();

            var filteredDepartments = departmentList.Filter(dep => dep.ShortName =="hr".ToUpper() || dep.ShortName == "FN");

            foreach( var dept in filteredDepartments )
            {
                Console.WriteLine($"Id : {dept.Id}");
                Console.WriteLine($"Short Name : {dept.ShortName}");
                Console.WriteLine($"Full Name : {dept.LongName}");
                Console.WriteLine();
            }
        }
    }
}