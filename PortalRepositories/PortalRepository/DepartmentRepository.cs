using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalRepositories.PortalRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PortalContext context;

        public DepartmentRepository(PortalContext context)
        {
            this.context = context;
        }


        public bool AddDepartment(Department model)
        {
            try
            {
                context.Add<Department>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Department GetDepartment(int departmentId)
        {
            try
            {
                return context.Departments.Where(x => x.Id == departmentId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            try
            {
                return context.Departments.ToList<Department>();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveDepartment(int departmentId)
        {
            try
            {
                var find = GetDepartment(departmentId);
                if(find != null)
                {
                    context.Remove<Department>(find);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateDepartment(Department newDepartment)
        {
            try
            {
                if(newDepartment != null)
                {
                    context.Update<Department>(newDepartment);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
