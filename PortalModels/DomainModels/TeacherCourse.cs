using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PortalModels.DomainModels
{
    public class TeacherCourse
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Teahcer")]
        //public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


        //[ForeignKey("Course")]
        //public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }

    }
}
