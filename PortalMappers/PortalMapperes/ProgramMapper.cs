using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PortalMapperes
{
    public static class ProgramMapper
    {
        public static ProgramModel ToModel(this Program source)
        {
            return new ProgramModel
            {
                Id = source.Id,
                Department = source.Department.ToModel(),
                DepartmentId= source.DepartmentId,
                Description = source.Description,
                Name = source.Name
            };
        }
        public static Program ToDb(this ProgramModel source)
        {
            return new Program
            {
                Id = source.Id,
                DepartmentId = source.DepartmentId,
                Description = source.Description,
                Name = source.Name
            };
        }
    }
}
