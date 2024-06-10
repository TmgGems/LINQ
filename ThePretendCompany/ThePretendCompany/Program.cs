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

            //List<Department> departmentList = Data.GetDepartments();

            //var filteredDepartments = departmentList.Where(dep => dep.Id > 0);

            //foreach( var dept in filteredDepartments )
            //{
            //    Console.WriteLine($"Id : {dept.Id}");
            //    Console.WriteLine($"Short Name : {dept.ShortName}");
            //    Console.WriteLine($"Full Name : {dept.LongName}");
            //    Console.WriteLine();
            //}

            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            var resultList = from emp in employeeList
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach (var empdp in resultList)
            {
                Console.WriteLine($"First Name : {empdp.FirstName}");
                Console.WriteLine($"Last Name : {empdp.LastName}");
                Console.WriteLine($"Annual Salary : {empdp.AnnualSalary}");
                Console.WriteLine($"Manager :{empdp.Manager}");
                Console.WriteLine($"Department :{empdp.Department}");
                Console.WriteLine();
            }

            var avgSalary = resultList.Average(u=>u.AnnualSalary);
            var minSalary = resultList.Min(u => u.AnnualSalary);
            var maxSalary = resultList.Max(u => u.AnnualSalary);

            Console.WriteLine($"Average Salary : {avgSalary}");
            Console.WriteLine($"Minimum Salary : {minSalary}");
            Console.WriteLine($"Maximum Salary : {maxSalary}");

        }
    }
}