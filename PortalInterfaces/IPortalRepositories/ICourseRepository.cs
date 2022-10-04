using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface ICourseRepository
    {
        bool AddCourse(Courses model);
        bool RemoveCourse(int courseId);
        bool UpdateCourse(Courses newCourse);
        IEnumerable<Courses> GetCourses();
        Courses GetCourse(int courseId);
       // Courses GetCourse(string courseName);
    }
}
