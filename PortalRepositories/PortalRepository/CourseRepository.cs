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
    public class CourseRepository : ICourseRepository
    {
        private readonly PortalContext context;

        public CourseRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddCourse(Courses model)
        {
            try
            {
                if (model == null) return false;
                context.Add<Courses>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Courses GetCourse(int courseId)
        {
            try
            {
                return context.Courses.Include(x => x.Program).Include(x=>x.Program.Department)
                    .Where(x=>x.Id == courseId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<Courses> GetCourses(Expression<Func<Courses, bool>> filter = null, Func<IQueryable<Courses>, IOrderedQueryable<Courses>> orderBy = null, params Expression<Func<Courses, object>>[] includes)
        {
            IQueryable<Courses> query = context.Courses;
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

        public IEnumerable<Courses> GetCourses()
        {
            try
            {
                return context.Courses.Include(x => x.Program).Include(x=>x.Program.Department).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveCourse(int courseId)
        {
            try
            {
                var find = GetCourse(courseId: courseId);
                context.Remove<Courses>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCourse(Courses newCourse)
        {
            try
            {
                if (newCourse == null) return false;
                context.Update<Courses>(newCourse);
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