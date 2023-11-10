using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex1
{
    internal static class EmployeeManager
    {
        static List<Employee> employees = new();
        public static void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public static void Find(string name)
        {
            if(name =="")
            {
                Console.WriteLine("Please enter some character");
                return;
            }
            var results = employees.FindAll(x=> x.Name.Contains(name));
            if(results.Count > 0)
            {
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("No match found");
            }
            
        }
        public static void Show()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);

        }

    }
}
