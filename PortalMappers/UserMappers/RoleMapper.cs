using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.UserMappers
{
    public static class RoleMapper
    {

        public static RoleModel ToModel(this Role source)
        {
            return new RoleModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description
            };
        }

        public static Role ToDb(this RoleModel source)
        {
            return new Role
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description
            };
        }

    }
}
