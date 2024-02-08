using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab_01
{
    internal class Database
    {
        public List<Employee> Employees = new List<Employee>()
        {
            new Employee{EmployeeId = 1, FirstName = "Ross", LastName = "Geller", Salary = 45000, DepartmentId = 101},
            new Employee{EmployeeId = 2, FirstName = "Phoebe", LastName = "Buffay", Salary = 82000, DepartmentId = 102},
            new Employee{EmployeeId = 3, FirstName = "Joey", LastName = "Tribbiani", Salary = 78000, DepartmentId = 103},
            new Employee{EmployeeId = 4, FirstName = "Monica", LastName = "Geller", Salary = 86000, DepartmentId = 101},
            new Employee{EmployeeId = 5, FirstName = "Chandler", LastName = "Bing", Salary = 65000, DepartmentId = 102},
            new Employee{EmployeeId = 6, FirstName = "Rachel", LastName = "Green", Salary = 62000, DepartmentId = 103},
            new Employee{EmployeeId = 7, FirstName = "Gunther", LastName = "Perk", Salary = 34000, DepartmentId = 101},
            new Employee{EmployeeId = 8, FirstName = "Mike", LastName = "Hannigan", Salary = 56000, DepartmentId = 102},
            new Employee{EmployeeId = 9, FirstName = "Jack", LastName = "Geller", Salary = 39000, DepartmentId = 103},
            new Employee{EmployeeId = 10, FirstName = "Judy", LastName = "Geller", Salary = 47000, DepartmentId = 101},
        };

        public List<Department> Departments = new List<Department>()
        {
            new Department{DepartmentId = 101, DepartmentName = "Software Developer"},
            new Department{DepartmentId = 102, DepartmentName = "Networking"},
            new Department{DepartmentId = 103, DepartmentName = "Cloud Security"},
        };

        public List<Project> Projects = new List<Project>()
        {
            new Project {ProjectId = 401, ProjectName = "Mobile App Development", DepartmentId = 101},
            new Project {ProjectId = 402, ProjectName = "Network Upgrade", DepartmentId = 102},
            new Project {ProjectId = 403, ProjectName = "Security Policy Review", DepartmentId = 103},
            new Project {ProjectId = 404, ProjectName = "Software Testing", DepartmentId = 101},
            new Project {ProjectId = 405, ProjectName = "Wi-Fi Expansion", DepartmentId = 102},
        };
    }
}
