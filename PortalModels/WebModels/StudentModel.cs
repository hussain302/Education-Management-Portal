using System;
using System.ComponentModel.DataAnnotations;

namespace PortalModels.WebModels
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RollNumber { get; set; }

        //public string Address { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsGraduated { get; set; }
    
        public int ProgramId { get; set; }
        public virtual ProgramModel Program { get; set; }
    }
}   
