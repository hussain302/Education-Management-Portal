using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Models.WebModels
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Designation { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }


        public int DepartmentId { get; set; }
        public virtual DepartmentModel Department { get; set; }

    }
}
