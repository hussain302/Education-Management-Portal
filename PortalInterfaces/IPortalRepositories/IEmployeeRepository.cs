using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(Employee model);
        bool RemoveEmployee(int employeeId);
        bool UpdateEmployee(Employee employee);

        Employee GetEmployee(int employeeId);
        IEnumerable<Employee> GetEmployees();

        List<Employee> GetEmployees(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null, params Expression<Func<Employee, object>>[] includes);
       // IEnumerable<Employee> GetTeachersCourses(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null);
        
    }
}
