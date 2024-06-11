namespace LINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();

            List<Department> departmentList = Data.GetDepartments();

            // Select and Where Operators - Method Syntax
            //var results = employeeList.Select(e => new
            //{
            //    FullName = e.FirstName + " " + e.LastName,
            //    AnnualSalary = e.AnnualSalary
            //}).Where( e => e.AnnualSalary >10000);

            //foreach(var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}");           
            //}

            //Query syntax
            //var results = from emp in employeeList
            //              where emp.AnnualSalary > 10000
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary
            //              };

            //foreach(var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}");
            //}


            //Deferred Execution Example
            //var results = from emp in employeeList.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary
            //              };



            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "5am",
            //    LastName = "Davis",
            //    AnnualSalary = 100000.20m,
            //    IsManager = true,
            //    DepartmentId = 5
            //});
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}");
            //}

            //Immediate Execution Example
            //var results = (from emp in employeeList.GetHighSalariedEmployees()
            //               select new
            //               {
            //                   FullName = emp.FirstName + " " + emp.LastName,
            //                   AnnualSalary = emp.AnnualSalary
            //               }).ToList();



            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "5am",
            //    LastName = "Davis",
            //    AnnualSalary = 100000.20m,
            //    IsManager = true,
            //    DepartmentId = 5
            //});
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}");
            //}

            //Join Operation - Method Syntax
            //var results = departmentList.Join(employeeList,
            //    department => department.Id,
            //    employee => employee.DepartmentId,
            //    (department, employee) => new
            //    {
            //        FullName = employee.FirstName + " " + employee.LastName,
            //        AnnualSalary = employee.AnnualSalary,
            //        departmentName = department.LongName
            //    });
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}");
            //}

            //Join Operation - Query Syntax
            //var results = departmentlist.join(employeelist,
            //    department => department.id,
            //    employee => employee.departmentid,
            //    (department, employee) => new
            //    {
            //        fullname = employee.firstname + " " + employee.lastname,
            //        annualsalary = employee.annualsalary,
            //        departmentname = department.longname
            //    });
            //foreach (var item in results)
            //{
            //    console.writeline($"{item.fullname,-20}{item.annualsalary,10}");
            //}

            //Join Operation -Query Syntax
            //var results = from dept in departmentList
            //              join emp in employeeList
            //              on dept.Id equals emp.DepartmentId
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary,
            //                  Department = dept.LongName

            //              };

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20}{item.AnnualSalary,10}{item.Department,40}");
            //}

            //GroupJoin Operator Example - Method Syntax
            //var results = departmentList.GroupJoin(employeeList,//group of employees
            //    dept => dept.Id,//outer key selector
            //    emp => emp.DepartmentId,//inner key selector
            //    (dept, employeesGroup) => new
            //    {
            //        Employees = employeesGroup,
            //        DepartmentName = dept.LongName
            //    });
            //foreach(var item in results)
            //{
            //    Console.WriteLine($"Department Name : {item.DepartmentName}");
            //    foreach (var emp in item.Employees)
            //        Console.WriteLine($"\t {emp.FirstName}{emp.LastName}");
            //}


            //GroupJoin Operator Example - Query Syntax
            //var results = from dept in departmentList
            //              join emp in employeeList
            //              on dept.Id equals emp.DepartmentId
            //              into employeeGroup
            //              select new
            //              {
            //                  Employees = employeeGroup,
            //                  DepartmentName = dept.LongName
            //              };
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Department Name : {item.DepartmentName}");
            //    foreach (var emp in item.Employees)
            //        Console.WriteLine($"\t {emp.FirstName}{emp.LastName}");
            //}

        }
    }
    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Accessing Employee: {emp.FirstName + " " + emp.LastName}");

                if (emp.AnnualSalary >= 50000)
                    yield return emp;
            }


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
                DepartmentId = 2
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
                DepartmentId = 2
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
    }
}
