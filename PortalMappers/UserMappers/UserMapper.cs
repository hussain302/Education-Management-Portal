using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.UserMappers
{
    public static class UserMapper
    {

        public static UserModel ToModel(this User source)
        {
            return new UserModel
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                Password = source.Password,
                Phone = source.Phone,
                Role = source.Role.ToModel(),
                RoleId = source.RoleId,
                SecurityAnswer = source.SecurityAnswer,
                SecurityQuestion = source.SecurityQuestion,
                IsApproved = source.IsApproved
            };
        }
        public static User ToDb(this UserModel source)
        {
            return new User
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                Password = source.Password,
                Phone = source.Phone,
                RoleId = source.RoleId,
                SecurityAnswer = source.SecurityAnswer,
                SecurityQuestion = source.SecurityQuestion,
                IsApproved=source.IsApproved  
            };
        }
    }
}