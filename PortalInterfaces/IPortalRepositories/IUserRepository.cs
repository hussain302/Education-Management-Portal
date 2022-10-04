using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IUserRepository
    {
        User LoginUserRequest(string email, string password);
        bool AddUser(User newUser);
        bool UpdateUser(User newUser);
        bool DeleteUser(int userId);
       // bool DeleteUser(string email);
        User GetUser(int userId);
        User GetUser(string email);
        List<User> GetUsers(Role role);
        List<User> GetUsers();

    }
}
