using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IRoleRepository
    {
        bool AddRole(Role model);
        bool RemoveRole(int roleId);
        Role GetRole(string roleName);
        bool UpdateRole(Role newRole);
        IEnumerable<Role> GetRoles();
        Role GetRole(int RoleId);
    }
}
