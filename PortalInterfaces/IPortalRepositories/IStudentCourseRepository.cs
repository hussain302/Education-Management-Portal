using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IStudentCourseRepository
    {
        bool AddStudentCourse(StudentCourse newModel);
        List<StudentCourse> GetStudentCourses();
        StudentCourse GetStudentCourse(int idToSearch);
        List<StudentCourse> GetStudentCourse(Student student);
        List<StudentCourse> GetStudentCourse(Courses course);
        bool UpdateStudentCourse(StudentCourse newModel);
        bool DeleteStudentCourse(int id);

        List<StudentCourse> GetTeachersCourses(Expression<Func<StudentCourse, bool>> filter = null, Func<IQueryable<StudentCourse>, IOrderedQueryable<StudentCourse>> orderBy = null, params Expression<Func<StudentCourse, object>>[] includes);
       //IEnumerable<StudentCourse> GetTeachersCourses(Expression<Func<StudentCourse, bool>> filter = null, Func<IQueryable<StudentCourse>, IOrderedQueryable<StudentCourse>> orderBy = null);
    }
}
