using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var result = GetEmployee147(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new { 
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(s => s.Salary > 50000)
                .OrderBy(f=>f.FirstName)
                .ToArray();

            foreach(var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .Where(d=>d.Name == "Research and Development")
                .OrderBy(s => s.Salary)
                .ThenByDescending(f => f.FirstName)
                .ToArray();

            foreach( var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAdress);
            Employee employee = context
                .Employees
                .First(e => e.LastName == "Nakov");
            employee.Address = newAdress;
            context.SaveChanges();

            string[] adressTexts = context
                 .Employees
                 .OrderByDescending(a => a.AddressId)
                 .Select(a => a.Address.AddressText)
                 .Take(10)
                 .ToArray();

            foreach ( string address in adressTexts)
            {
                sb.AppendLine($"{address}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                                      .Include(x => x.Manager)
                                      .Include(x => x.EmployeesProjects)
                                      .ThenInclude(x => x.Project)
                                      .Where(e => e.EmployeesProjects
                                                  .Any(ep => ep.Project.StartDate.Year >= 2001
                                                          && ep.Project.StartDate.Year <= 2003))
                                      .Take(10)
                                      .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine(
                    string.Format(
                        "{0} {1} - Manager: {2} {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Manager.FirstName,
                        employee.Manager.LastName));

                foreach (var project in employee.EmployeesProjects)
                {
                    sb.AppendLine(
                        string.Format(
                            "--{0} - {1} - {2}",
                            project.Project.Name,
                            project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            project.Project.EndDate.HasValue ? project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"));
                }
            }
            return sb.ToString().TrimEnd();
        }

         public static string GetAddressesByTown(SoftUniContext context)
        {
            var employees = context
                .Addresses
                .Select(e => new
                {
                    AdressText = e.AddressText,
                    TownName = e.Town.Name,
                    EmployeeCount = e.Employees.Count()
                })
                .OrderByDescending(e=>e.EmployeeCount)
                .ThenBy(t=>t.TownName)
                .ThenBy(a=>a.AdressText)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.AdressText}, {employee.TownName} - {employee.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(e => new
                    {
                        e.Project.Name
                    }).OrderBy(p => p.Name)
                    .ToArray()
                }).ToArray();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee[0].FirstName} - {employee[0].JobTitle}");
            foreach (var project in employee[0].Projects)
            {
                sb.AppendLine($"{project.Name}");
            }
           
            return sb.ToString().TrimEnd();
        }
    }
}
