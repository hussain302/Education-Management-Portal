using PortalMappers.PersonMappers;
using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PortalMapperes
{
    public static class StudentCourceMapper
    {

        public static StudentCourseModel ToModel(this StudentCourse source)
        {
            return new StudentCourseModel
            {
                Id = source.Id,
                CourseId = source.CourseId,
                StudentId= source.StudentId,
                Courses = source.Courses.ToModel(),
                Student = source.Student.ToModel(),
            };
        }

        public static StudentCourse ToDb(this StudentCourseModel source)
        {
            return new StudentCourse
            {
                Id = source.Id,
                CourseId = source.CourseId,
                StudentId = source.StudentId,
            };
        }

    }
}
