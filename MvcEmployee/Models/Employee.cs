using System;
using System.ComponentModel.DataAnnotations;

namespace MvcEmployee.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid salary")]
        public decimal Salary { get; set; }

        [Display(Name="Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
    }
}
