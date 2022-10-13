using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalModels.DomainModels
{
    public class StudentCourse
    {

        [Key]
        public int Id { get; set; }

        //public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        //public int? CourseId { get; set; }
        public virtual Courses Courses { get; set; }


    }
}
