using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEmployee.Models;

namespace MvcEmployee.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcEmployeeContext _context;

        public EmployeesController(MvcEmployeeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string employeeDepartment, string searchString)
        {
            // Use LINQ to get list of departments.
            IQueryable<string> departmentQuery = from e in _context.Employee
                                                 orderby e.Department
                                                 select e.Department;

            var employees = from e in _context.Employee
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(employeeDepartment))
            {
                employees = employees.Where(x => x.Department == employeeDepartment);
            }

            var employeeDepartmentVM = new EmployeeDepartmentViewModel
            {
                Departments = new SelectList(await departmentQuery.Distinct().ToListAsync()),
                Employees = await employees.ToListAsync(),
                EmployeeDepartment = employeeDepartment,
                SearchString = searchString
            };

            return View(employeeDepartmentVM);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,HireDate,Position,Department,Salary,Email,Phone")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,HireDate,Position,Department,Salary,Email,Phone")] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.ID == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}
