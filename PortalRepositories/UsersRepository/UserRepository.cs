using Microsoft.EntityFrameworkCore;
using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalRepositories.UsersRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly PortalContext context;

        public UserRepository(PortalContext context)
        {
            this.context = context;
        }
        public bool AddUser(User newUser)
        {
            try
            {
                var findRole = context.Roles.Where(x => x.Name == "pending").FirstOrDefault();
                newUser.RoleId = findRole.Id;
                context.Add<User>(newUser);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var find = GetUser(userId);
                context.Remove<User>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        public User GetUser(int userId)
        {
            try
            {
                return context.Users.Include(x=>x.Role).Where(x=>x.Id == userId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(string email)
        {
            try
            {
                return context.Users.Include(x=>x.Role).Where(x => x.Email == email).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers(Role role)
        {
            try
            {
                return context.Users.Include(x=>x.Role).Where(x => x.Role == role).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return context.Users.Include(x=>x.Role).ToList();
            }
            catch
            {
                return null;
            }
        }

        public User LoginUserRequest(string email, string password)
        {
            try
            {
               var find = context.Users.Include(x=>x.Role).Where(x => x.Email == email)
                    .Where(x => x.Password == password).FirstOrDefault();
                if (find != null) return find;
                else return null;
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateUser(User newUser)
        {
            try
            {
                if (newUser != null)
                {
                    context.Update<User>(newUser);
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