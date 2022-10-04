using PortalMappers.PortalMapperes;
using PortalModels.DomainModels;
using PortalModels.WebModels;

namespace PortalMappers.PersonMappers
{
    public static class EmployeeMapper
    {


        public static EmployeeModel ToModel(this Employee source)
        {
            return new EmployeeModel
            {
                Department = source.Department.ToModel(),
                JoiningDate = source.JoiningDate,
                Designation = source.Designation,
                Address = source.Address,
                Email = source.Email,
                FirstName = source.FirstName,
                Id = source.Id,
                LastName = source.LastName,
                Phone = source.Phone,
                Salary = source.Salary
            };
        }

        public static Employee ToDb(this EmployeeModel source)
        {
            return new Employee
            {
                DepartmentId = source.DepartmentId,
                JoiningDate = source.JoiningDate,
                Designation = source.Designation,
                Address = source.Address,
                Email = source.Email,
                FirstName = source.FirstName,
                Id = source.Id,
                LastName = source.LastName,
                Phone = source.Phone,
                Salary = source.Salary
            };
        }
    }
}
