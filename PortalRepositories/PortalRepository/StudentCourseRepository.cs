using Microsoft.EntityFrameworkCore;
using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PortalRepositories.PortalRepository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly PortalContext context;

        public StudentCourseRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddStudentCourse(StudentCourse newModel)
        {
            try
            {
                if (newModel == null) return false;
                context.Entry(newModel.Courses).State = EntityState.Unchanged;
                context.Entry(newModel.Student).State = EntityState.Unchanged;
                context.Add<StudentCourse>(newModel);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteStudentCourse(int id)
        {
            try
            {
                var find = GetStudentCourse(id);
                if (find == null) return false;
                context.Remove<StudentCourse>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public StudentCourse GetStudentCourse(int idToSearch)
        {
            try
            {
                return context.StudentCourses.Where(x => x.Id == idToSearch).Include(x => x.Courses)
                    .Include(x => x.Student).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<StudentCourse> GetStudentCourse(Student student)
        {
            try
            {
                return context.StudentCourses.Where(x=>x.Student == student)
                            .Include(x => x.Student).Include(x => x.Courses).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<StudentCourse> GetStudentCourse(Courses course)
        {
            try
            {
                return context.StudentCourses.Where(x => x.Courses == course)
                            .Include(x => x.Student).Include(x => x.Courses).ToList();
            }
            catch
            {
                return null;
            }

        }

        public List<StudentCourse> GetStudentCourses()
        {
            try
            {
                var find = context.StudentCourses.Include(x => x.Courses).Include(x => x.Student).ToList();
                return find;
            }
            catch
            {
                return null;
            }
        }

        public List<StudentCourse> GetTeachersCourses(Expression<Func<StudentCourse, bool>> filter = null, Func<IQueryable<StudentCourse>, IOrderedQueryable<StudentCourse>> orderBy = null, params Expression<Func<StudentCourse, object>>[] includes)
        {
            IQueryable<StudentCourse> query = context.StudentCourses;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        

        public bool UpdateStudentCourse(StudentCourse newModel)
        {
            try
            {
                if (newModel == null) return false;
                context.Entry(newModel.Courses).State = EntityState.Unchanged;
                context.Entry(newModel.Student).State = EntityState.Unchanged;
                context.Update<StudentCourse>(newModel);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
