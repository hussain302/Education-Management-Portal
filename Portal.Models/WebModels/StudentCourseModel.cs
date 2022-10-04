using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Models.WebModels
{
    public class StudentCourseModel
    {

        [Key]
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public virtual StudentModel Student { get; set; }

        public int? CourseId { get; set; }
        public virtual CoursesModel Courses { get; set; }


    }
}
