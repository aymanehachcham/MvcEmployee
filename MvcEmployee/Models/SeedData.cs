using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcEmployee.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcEmployeeContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcEmployeeContext>>()))
            {
                // Look for any employees.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        HireDate = DateTime.Parse("2015-06-01"),
                        Position = "Software Engineer",
                        Department = "IT",
                        Salary = 75000M,
                        Email = "johndoe@example.com",
                        Phone = "555-1234"
                    },
                    new Employee
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        HireDate = DateTime.Parse("2017-09-15"),
                        Position = "Product Manager",
                        Department = "Marketing",
                        Salary = 85000M,
                        Email = "janesmith@example.com",
                        Phone = "555-5678"
                    },
                    new Employee
                    {
                        FirstName = "Bob",
                        LastName = "Johnson",
                        HireDate = DateTime.Parse("2012-03-23"),
                        Position = "HR Specialist",
                        Department = "Human Resources",
                        Salary = 65000M,
                        Email = "bobjohnson@example.com",
                        Phone = "555-9012"
                    },
                    new Employee
                    {
                        FirstName = "Alice",
                        LastName = "Williams",
                        HireDate = DateTime.Parse("2018-11-30"),
                        Position = "Accountant",
                        Department = "Finance",
                        Salary = 70000M,
                        Email = "alicewilliams@example.com",
                        Phone = "555-3456"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
