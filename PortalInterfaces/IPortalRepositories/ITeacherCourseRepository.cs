using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PortalInterfaces.IPortalRepositories
{
    public interface ITeacherCourseRepostory
    {
        bool AddTeacherCourse(TeacherCourse newModel);
        List<TeacherCourse> GetTeachersCourses();
        TeacherCourse GetTeacherCourse(int idToSearch);
        List<TeacherCourse> GetTeacherCourse(Teacher teacher);
        List<TeacherCourse> GetTeacherCourse(Courses course);
        bool UpdateTeacherCourse(TeacherCourse newModel);
        bool DeleteTeacherCourse(int id);

        List<TeacherCourse> GetTeachersCourses(Expression<Func<TeacherCourse, bool>> filter = null, Func<IQueryable<TeacherCourse>, IOrderedQueryable<TeacherCourse>> orderBy = null, params Expression<Func<TeacherCourse, object>>[] includes);
        //IEnumerable<TeacherCourse> GetTeachersCourses(Expression<Func<TeacherCourse, bool>> filter = null, Func<IQueryable<TeacherCourse>, IOrderedQueryable<TeacherCourse>> orderBy = null);

        //public virtual IEnumerable<Product> GetProduct(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null)
        //{
        //    IQueryable<Product> query = context.Products;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        //public List<Product> GetProduct(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, params Expression<Func<Product, object>>[] includes)
        //{
        //    IQueryable<Product> query = context.Set<Product>();

        //    foreach (Expression<Func<Product, object>> include in includes)
        //        query = query.Include(include);

        //    if (filter != null)
        //        query = query.Where(filter);

        //    if (orderBy != null)
        //        query = orderBy(query);

        //    return query.ToList();
        //}

    }
}
