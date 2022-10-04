using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IDepartmentRepository
    {
        bool AddDepartment(Department model);
        bool RemoveDepartment(int departmentId);
        bool UpdateDepartment(Department newDepartment);
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);
    }
}