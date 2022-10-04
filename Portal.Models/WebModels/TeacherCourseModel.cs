using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Models.WebModels
{
    public class TeacherCourseModel
    {
        [Key]
        public int Id { get; set; }

        public int? TeacherId { get; set; }
        public virtual TeacherModel Teacher { get; set; }

        public int? CourseId { get; set; }
        public virtual CoursesModel Courses { get; set; }

    }
}
