using Microsoft.EntityFrameworkCore;
using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalRepositories.PortalRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PortalContext context;

        public StudentRepository( PortalContext context )
        {
            this.context = context;
        }

        public bool AddStudent(Student model)
        {
            try
            {
                if (model == null) return false;
                context.Add<Student>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student GetStudent(int studentId)
        {
            try
            {
                return context.Students.Include(x => x.Program).Include(x=>x.Program.Department).Where(x=>x.Id == studentId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                return context.Students.Include(x => x.Program).Include(x => x.Program.Department).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Student> GetStudents(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, params Expression<Func<Student, object>>[] includes)
        {
            try
            {
                IQueryable<Student> query = context.Students;
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
            catch
            {
                return null;
            }
        }

        public IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(int studentId)
        {
            try
            {
                var find = GetStudent(studentId);
                if (find == null) return false;
                context.Remove<Student>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStudent(Student newStudent)
        {
            try
            {
                if (newStudent == null) return false;
                context.Update<Student>(newStudent);
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
