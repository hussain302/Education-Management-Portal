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
    public class TeacherCourseRepository : ITeacherCourseRepostory
    {
        private readonly PortalContext context;

        public TeacherCourseRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddTeacherCourse(TeacherCourse newModel)
        {
            try
            {
                if (newModel == null) return false;
                context.Add<TeacherCourse>(newModel);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTeacherCourse(int id)
        {
            try
            {
                var find = GetTeacherCourse(id);
                if (find == null) return false;
                context.Remove<TeacherCourse>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TeacherCourse GetTeacherCourse(int idToSearch)
        {
            try
            {
                return context.TeacherCourses.Where(x => x.Id == idToSearch)
                    .Include(x => x.Teacher).Include(x => x.Courses).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<TeacherCourse> GetTeacherCourse(Teacher teacher)
        {
            try
            {
                return context.TeacherCourses.Where(x=>x.Teacher == teacher)
                            .Include(x => x.Teacher).Include(x => x.Courses).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<TeacherCourse> GetTeacherCourse(Courses course)
        {
            try
            {
                return context.TeacherCourses.Where(x => x.Courses == course)
                            .Include(x => x.Teacher).Include(x => x.Courses).ToList();
            }
            catch
            {
                return null;
            }

        }

        public List<TeacherCourse> GetTeachersCourses()
        {
            try
            {
                return context.TeacherCourses.Include(x => x.Teacher).Include(x => x.Courses).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<TeacherCourse> GetTeachersCourses(Expression<Func<TeacherCourse, bool>> filter = null, Func<IQueryable<TeacherCourse>, IOrderedQueryable<TeacherCourse>> orderBy = null, params Expression<Func<TeacherCourse, object>>[] includes)
        {
            IQueryable<TeacherCourse> query = context.TeacherCourses;
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

        public bool UpdateTeacherCourse(TeacherCourse newModel)
        {
            try
            {
                if (newModel == null) return false;
                context.Update<TeacherCourse>(newModel);
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
