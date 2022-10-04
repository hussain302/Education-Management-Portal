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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PortalContext context;

        public EmployeeRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddEmployee(Employee model)
        {
            try
            {
                if (model == null) return false;
                context.Add<Employee>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Employee GetEmployee(int employeeId)
        {
            try
            {
                return context.Employees.Include(x => x.Department).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return context.Employees.Include(x => x.Department).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Employee> GetEmployees(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderBy = null, params Expression<Func<Employee, object>>[] includes)
        {
            IQueryable<Employee> query = context.Employees;
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

        public bool RemoveEmployee(int employeeId)
        {
            try
            {
                var find = GetEmployee(employeeId);
                if (find == null) return false;
                context.Remove<Employee>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee == null && employee.FirstName == null 
                    && employee.Designation == null && employee.DepartmentId == 0) return false;
                context.Update<Employee>(employee);
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
