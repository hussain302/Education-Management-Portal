using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalRepositories.UsersRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PortalContext _db;

        public RoleRepository(PortalContext db)
        {
            this._db = db;
        }

        public bool AddRole(Role model)
        {
            try
            {
                _db.Add<Role>(model);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Role GetRole(int RoleId)
        {
            try
            {
                return _db.Find<Role>(RoleId);
            }
            catch
            {
                return null;
            }
        }
        
        public Role GetRole(string roleName)
        {
            try
            {
                return _db.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            try
            {
                return _db.Roles.ToList();
            }
            catch
            {
                return Enumerable.Empty<Role>();
            }
        }

        public bool RemoveRole(int roleId)
        {
            try
            {
                var find = GetRole(RoleId: roleId);
                _db.Remove<Role>(find);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateRole(Role newRole)
        {
            try
            {
                if (newRole != null)
                {
                    _db.Update<Role>(newRole);
                    _db.SaveChanges();
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
    }
}
