
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace LINQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            // Sorting Operations OrderBy,OrderByDescending,ThenBy,ThenByDescending
            //Method Syntax
            //var results = employeeList.Join(departmentList,
            //    e => e.DepartmentId,
            //    d => d.Id,
            //    (emp, dept) => new
            //    {
            //        Id = emp.Id,
            //        FirstName = emp.FirstName,
            //        LastName = emp.LastName,
            //        AnnualSalary = emp.AnnualSalary,
            //        DepartmentId =emp.DepartmentId,
            //        DepartmentName = dept.LongName
            //    }).OrderBy(o =>o.DepartmentId).ThenByDescending(o=>o.AnnualSalary);

            //foreach(var item in results)
            //{
            //    Console.WriteLine($"Id:{item.Id,-5} First Name:{item.FirstName,-10}LastName:{item.LastName,-10}Annual Salary:{item.AnnualSalary,10}\tDepartment Name:{item.DepartmentName}");
            //    Console.WriteLine();
            //}


            //Query Syntax

            //var results = from emp in employeeList
            //              join dept in departmentList
            //              on emp.DepartmentId equals dept.Id
            //              orderby emp.DepartmentId, emp.AnnualSalary descending
            //              select new
            //              {
            //                  Id = emp.Id,
            //                  FirstName = emp.FirstName,
            //                  LastName = emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary,
            //                  DepartmentId = emp.DepartmentId,
            //                  DepartmentName = dept.LongName
            //              };
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Id:{item.Id,-5} First Name:{item.FirstName,-10}LastName:{item.LastName,-10}Annual Salary:{item.AnnualSalary,10}\tDepartment Name:{item.DepartmentName}");
            //    Console.WriteLine();
            //}

            //Grouping Operators
            //GroupBy
            //var groupList = from emp in employeeList
            //                orderby emp.DepartmentId
            //                group emp by emp.DepartmentId;
            //foreach(var empGroup in groupList)
            //{
            //    Console.WriteLine($"Department Id:{empGroup.Key}");
            //    foreach(Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"\t Employee Fullname:{emp.FirstName}{emp.LastName}");
            //    }
            //}

            //ToLookup Operator

            //var groupResult = employeeList.ToLookup(e =>  e.DepartmentId);
            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department Id :{empGroup.Key}");
            //    foreach (Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"\t Employee Fullname:{emp.FirstName}{emp.LastName}");
            //    }
            //}

            //All,Any,Contains Quantifier Operators
            //All and Any Operators

            //var annualSalaryCompare = 20000;
            //bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll)
            //{
            //    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"All employee annual salaries are  below {annualSalaryCompare}");
            //}

            //bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAny)
            //{
            //    Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"No employees have an annual salary above {annualSalaryCompare}");
            //}

            //Contains Operator

            //var searchemployee = new Employee
            //{
            //    Id = 5,
            //    FirstName = "John",
            //    LastName = "Cena",
            //    AnnualSalary = 30000.2m,
            //    IsManager = false,
            //    DepartmentId = 3
            //};

            //bool isEmployee = employeeList.Contains(searchemployee,new EmployeeComparer());

            //if (isEmployee)
            //{
            //    Console.WriteLine($"An employee record for {searchemployee.FirstName} {searchemployee.LastName}");
            //}
            //else
            //{
            //    Console.WriteLine($"Sorry No match for {searchemployee.FirstName} {searchemployee.LastName}");
            //}

            //ofType filter operation
            //ArrayList mixedcollection = Data.GetHeterogeneousDataCollection();

            //var stringResult = from s in mixedcollection.OfType<string>()
            //                   select s;

            //var intResult = from i in mixedcollection.OfType<int>()
            //                select i;

            //var employeeResults = from e in mixedcollection.OfType<Employee>()
            //                      select e;



            //foreach(var emp in employeeResults)
            //{
            //    Console.WriteLine($"{emp.Id} {emp.FirstName} {emp.LastName}");
            //}


            //Element Operator

            //ElementAt
            //var emp = employeeList.ElementAtOrDefault(5);
            //if(emp != null)
            //{
            //    Console.WriteLine($"{emp.Id} {emp.FirstName} {emp.LastName}");
            //}
            //else
            //{
            //    Console.WriteLine("The employee record  does not exist");
            //}

            //First,FirstOrDefault,Last,LastOrDefault

            //List<int> integerList = new List<int> { 1,2, 3, 5,6,4};
            //int result = integerList.First( i => i% 2 == 0);

            //Console.WriteLine(result);

            //int result = integerList.LastOrDefault(i => i % 2 == 0);
            //if(result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even numbers in the collection");
            //}

            //Single,SingleOrDefault Operators

            //var emp = employeeList.Single( e => e.Id == 2);

            var emp = employeeList.Single( e => e.Id == 1);

            if(emp != null)
            {
                Console.WriteLine($"{emp.Id,-5}{emp.FirstName,-10}{emp.LastName,-10}");
            }
            else
            {
                Console.WriteLine("The selected employee doesnot exist in the list");
            }
        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee ? x, Employee? y)
        {
            if(x.Id == y.Id && x.FirstName.ToLower()==y.FirstName.ToLower() &&x.LastName.ToLower()==y.LastName.ToLower())
            {
                return true;
            };
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)//GetHashCode used for uniquely identifying the object
        {
            return obj.Id.GetHashCode();
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AnnualSalary { get; set; }

        public bool IsManager { get; set; }

        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string LongName { get; set; }
    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 6000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 8000.1m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);


            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 5,
                FirstName = "John",
                LastName = "Cena",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);
            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance "
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology "
            };
            departments.Add(department);
            return departments;
        }
        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            arrayList.Add("Bob Janes");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Hinder Son");
            arrayList.Add(new Employee { Id=6,FirstName="Ram",LastName="Karki",IsManager=true,AnnualSalary=9000,DepartmentId=4 });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
            return arrayList;
        }
    }
}