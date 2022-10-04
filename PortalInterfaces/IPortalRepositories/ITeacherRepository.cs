using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{

    public interface ITeacherRepository
    {
        bool AddTeacher(Teacher model);
        bool RemoveTeacher(int teacherId);
        bool UpdateTeacher(Teacher newTeacher);
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacher(int teacherId);
        Teacher GetTeacher(string teacherEmail);
        List<Teacher> GetTeachers(Expression<Func<Teacher, bool>> filter = null, Func<IQueryable<Teacher>, IOrderedQueryable<Teacher>> orderBy = null, params Expression<Func<Teacher, object>>[] includes);
        
    }
}
