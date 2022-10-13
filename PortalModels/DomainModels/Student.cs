using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalModels.DomainModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RollNumber { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

       // public string Address { get; set; }

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; }

        public string Email { get; set; }

        public Nullable<bool> IsGraduated { get; set; }
    
        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}   
