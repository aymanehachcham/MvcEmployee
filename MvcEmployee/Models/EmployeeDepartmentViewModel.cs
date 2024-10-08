using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcEmployee.Models
{
    public class EmployeeDepartmentViewModel
    {
        public List<Employee> Employees { get; set; }
        public SelectList Departments { get; set; }
        public string EmployeeDepartment { get; set; }
        public string SearchString { get; set; }
    }
}
