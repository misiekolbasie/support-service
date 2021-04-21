using System;
using System.Collections.Generic;
using System.Text;
using SupportService.DataAccess.Entities;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Translators
{
    internal static class UserTranslatorExtension //метод расширения
    {
        internal static UserEntity ToEntity(this User user) //this- на ком вызывается
        {
            UserEntity userEntity = new UserEntity()
            {
                Name = user.Name,
                Role = (int)user.Role
            };
            return userEntity;
        }

        internal static User ToModel(this UserEntity entity)
        {
            User user = new User()
            {
                Id = entity.Id,
                Name = entity.Name,
                Role = (Roles)entity.Role
            };
            return user;
        }
    }
}
