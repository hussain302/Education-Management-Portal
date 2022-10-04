using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PortalMapperes
{
    public static class DepartmentMapper
    {

        public static DepartmentModel ToModel(this Department source)
        {
            return new DepartmentModel
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name
            };
        }

        public static Department ToDb(this DepartmentModel source)
        {
            return new Department
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name
            };
        }

    }
}
