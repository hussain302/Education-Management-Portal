using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalModels.DomainModels
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int CreditHours { get; set; }

        public int ProgramId { get; set; }
        public virtual Program Program { get; set; }

        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
