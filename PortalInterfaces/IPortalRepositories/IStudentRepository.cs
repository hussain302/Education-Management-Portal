using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IStudentRepository
    {
        bool AddStudent(Student model);
        bool RemoveStudent(int studentId);
        bool UpdateStudent(Student newStudent);
        IEnumerable<Student> GetStudents();
        Student GetStudent(int studentId);
        List<Student> GetStudents(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, params Expression<Func<Student, object>>[] includes);
        IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null);

    }
}
