using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab_01
{
    internal class LINQOperations
    {
        Database data = new Database();

        /// <summary>
        /// This method groups the employees by their departments. It then calculates the average salary for each department
        /// and finds the department with the highest total salary.
        /// </summary>
        public void GroupEmployeesByDepartment()
        {
            // Grouping the employees by their departments
            var groupedEmployeesByDepartment = data.Employees
                                                .GroupBy(x => x.DepartmentId)
                                                .Select(empGroup => new
                                                {
                                                    Department = empGroup.Key,
                                                    // Calculating the total salary of each department
                                                    TotalSalary = empGroup.Sum(emp => emp.Salary),
                                                    // Calculating the average salary of each department
                                                    AverageSalary = empGroup.Average(emp => emp.Salary),
                                                    GroupedEmployees = empGroup
                                                });

            // Printing the average salary for each department
            foreach (var empGroup in groupedEmployeesByDepartment)
            {
                Console.WriteLine($"The average salary of Department {empGroup.Department} is " +
                    $"{Math.Round(empGroup.AverageSalary, 2)}");
            }
            Console.WriteLine();

            // Finding the department with highest total salary
            var departmentWithHighestSalary = groupedEmployeesByDepartment.OrderBy(empGroup => empGroup.TotalSalary).Last();
            Console.WriteLine($"The Department {departmentWithHighestSalary.Department} has the highest total salary of" +
                $" {departmentWithHighestSalary.TotalSalary}");
            Console.WriteLine();
        }

        /// <summary>
        /// This method groups the employees by the projects they are involved in.
        /// Then, it also counts the total number of projects in each department.
        /// </summary>
        public void GroupEmployeesByProjects()
        {
            // Joining Projects list and Employees list
            var groupedEmployeesByProject = data.Employees
                                                    .Join(data.Projects,
                                                          emp => emp.DepartmentId,
                                                          proj => proj.DepartmentId,
                                                          (emp, proj) => new
                                                          {
                                                              Employee = emp,
                                                              Project = proj
                                                          })
                                                    // Grouping the resulting object by the department ID
                                                    .GroupBy(group => group.Employee.DepartmentId)
                                                    .Select(group => new
                                                    {
                                                        DepartmentId = group.Key,
                                                        // Selecting the unique projects from the group
                                                        Projects = group.Select(emp => emp.Project.ProjectId).Distinct(),
                                                        empDetails = group
                                                    }); ;

            // Looping through the newly created object and counting the total number of projects
            foreach (var emps in groupedEmployeesByProject)
            {
                int numberOfProjects = emps.Projects.Count();

                Console.WriteLine($"The total number of projects in Department {emps.DepartmentId} are" +
                    $" {numberOfProjects}");
            }
        }

        /// <summary>
        /// This method performs inner joins between the Employee, Department, and Project lists based on the 
        /// Department IDs. It also displays the information about the employees, departments and projects.
        /// </summary>
        public void PerformingInnerJoins()
        {
            // Joining the Employees and Department lists based on "DepartmentId". Then further group joining with
            // Projects list based on "DepartmentId"

            var combinedData = data.Employees.Join(data.Departments,
                                                emp => emp.DepartmentId,
                                                dept => dept.DepartmentId,
                                                (emp, dept) => new
                                                {
                                                    EmployeeId = emp.EmployeeId,
                                                    FirstName = emp.FirstName,
                                                    LastName = emp.LastName,
                                                    Salary = emp.Salary,
                                                    DepartmentId = dept.DepartmentId,
                                                    DepartmentName = dept.DepartmentName
                                                }).GroupJoin(data.Projects,
                                                    empDept => empDept.DepartmentId,
                                                    proj => proj.DepartmentId,
                                                    (empDept, proj) => new
                                                    {
                                                        EmpDept = empDept,
                                                        // Using select since there are multiple projects associated with
                                                        // same department
                                                        ProjectId = proj.Select(x => x.ProjectId),
                                                        ProjectName = proj.Select(x => x.ProjectName),
                                                    });

            // Displaying information about employees, their departments, and projects.

            Console.WriteLine("The details about the employees, their departments and projects are: ");
            Console.WriteLine();

            foreach (var data in combinedData)
            {
                Console.WriteLine($"Employee ID: {data.EmpDept.EmployeeId} \n" +
                    $"First Name: {data.EmpDept.FirstName} \n" +
                    $"Last Name: {data.EmpDept.LastName} \n" +
                    $"Salary: {data.EmpDept.Salary} \n" +
                    $"Department ID: {data.EmpDept.DepartmentId} \n" +
                    $"Department Name: {data.EmpDept.DepartmentName} \n" +
                    $"Project ID: {string.Join(", ", data.ProjectId)} \n" +
                    $"Project Names: {string.Join(", ", data.ProjectName)}");

                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method filters the employees with a salary above a certain threshold.
        /// </summary>
        public void FilterEmployeesBySalary()
        {
            int thresholdSalary = 70000;

            // Filtering out the employees who have their salary above the threshold
            var filteredEmployeesBySalary = from emp in data.Employees where emp.Salary > thresholdSalary select emp;

            Console.WriteLine($"The employees with salary above {thresholdSalary} are:  ");
            Console.WriteLine();

            // Printing the employees to the console
            foreach (var filteredEmp in filteredEmployeesBySalary)
            {
                Console.WriteLine($"Employee: {filteredEmp.FirstName} {filteredEmp.LastName}, Salary: {filteredEmp.Salary}");
            }
        }

        /// <summary>
        /// This method displays the information about the employee and project names
        /// </summary>
        public void DisplayEmpAndProjectInfo()
        {
            // Joining the Employees and Projects lists based on department Id
            var empAndProjectInfo = data.Employees.GroupJoin(
                                                    data.Projects,
                                                    emp => emp.DepartmentId,
                                                    proj => proj.DepartmentId,
                                                    (emp, proj) => new
                                                    {
                                                        FirstName = emp.FirstName,
                                                        LastName = emp.LastName,
                                                        ProjectName = proj.Select(x => x.ProjectName),
                                                    });

            Console.WriteLine("The information about the employee and project names is:");
            Console.WriteLine();

            // Looping through the empAndProjectInfo to display the info about names of employees and project
            foreach (var empProj in empAndProjectInfo)
            {
                Console.WriteLine($"Employee First Name: {empProj.FirstName} \n" +
                    $"Employee Last Name: {empProj.LastName} \n" +
                    $"Project Names: {string.Join(", ", empProj.ProjectName)}");

                Console.WriteLine();
            }
        }
    }
}
