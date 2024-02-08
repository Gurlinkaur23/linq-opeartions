using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LINQOperations operations = new LINQOperations();

            Console.WriteLine("- * - * - * - LINQ Opeartions - * - * - * - ");
            Console.WriteLine();

            operations.GroupEmployeesByDepartment();
            Console.WriteLine();

            operations.GroupEmployeesByProjects();
            Console.WriteLine("- * - * - * - * - * - * - * - * - * - * - * - * - * -");
            Console.WriteLine();

            operations.PerformingInnerJoins();
            Console.WriteLine("- * - * - * - * - * - * - * - * - * - * - * - * - * -");
            Console.WriteLine();

            operations.FilterEmployeesBySalary();
            Console.WriteLine("- * - * - * - * - * - * - * - * - * - * - * - * - * -");
            Console.WriteLine();

            operations.DisplayEmpAndProjectInfo();
            Console.WriteLine("- * - * - * - * - * - * - * - * - * - * - * - * - * -");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
