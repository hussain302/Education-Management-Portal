using System;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models.DomainModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RollNumber { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; }

        public string Email { get; set; }

        public Nullable<bool> IsGraduated { get; set; }
    
        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }
    }
}   
