using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalModels.DomainModels
{
    public class TeacherCourse
    {
        [Key]
        public int Id { get; set; }

        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int? CourseId { get; set; }
        public virtual Courses Courses { get; set; }

    }
}
