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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly PortalContext context;

        public TeacherRepository(PortalContext context)
        {
            this.context = context;
        }
        public bool AddTeacher(Teacher model)
        {
            try
            {
                if (model == null) return false;
                context.Add<Teacher>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Teacher GetTeacher(int teacherId)
        {
            try
            {
                return context.Teachers.Find(teacherId);
            }
            catch
            {
                return null;
            }
        }

        public Teacher GetTeacher(string teacherEmail)
        {
            try
            {
                return context.Teachers.Include(x=>x.Qualification).Where(x => x.Email == teacherEmail).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            try
            {
                return context.Teachers.Include(x => x.Qualification)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Teacher> GetTeachers(Expression<Func<Teacher, bool>> filter = null, Func<IQueryable<Teacher>, IOrderedQueryable<Teacher>> orderBy = null, params Expression<Func<Teacher, object>>[] includes)
        {
            {
                IQueryable<Teacher> query = context.Teachers;
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

        }
 

        public bool RemoveTeacher(int teacherId)
        {
            try
            {
                var find = GetTeacher(teacherId);
                context.Remove<Teacher>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTeacher(Teacher newTeacher)
        {
            try
            {
                if (newTeacher == null) return false;
                context.Update<Teacher>(newTeacher);
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
