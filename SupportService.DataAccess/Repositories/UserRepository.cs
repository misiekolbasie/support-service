using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly SupportServiceDbContext _usersDb;
        
        
        public UserRepository(SupportServiceDbContext dbContext, ILogger<UserRepository> logger)
        {
            _usersDb = dbContext;
            _logger = logger;
        }

        public int CreateUser(User user)
        {
            UserEntity userEntity = new UserEntity()
            {
                Name = user.Name,
                Role = (int)user.Role
            };
            //save in base
            _usersDb.Users.Add(userEntity);
            _usersDb.SaveChanges();
            return userEntity.Id;
            //if (!ValidateUser(user))
            //{
            //   throw new Exception("Такой пользователь уже существует!");
            //}
        }
        public User GetUserById(int userid)
        {
            // find ticket entity po id
            UserEntity entity = _usersDb.Users.FirstOrDefault(c => c.Id == userid);
            //proverka est' li entity voobshe
            if (entity == null)
            {
                return null;
            }
            // preobrazovanie iz entity v model
            User user = UserEntityToModel(entity);
            return user;
        }
        //private bool ValidateUser(User user)
        //{
        //    foreach (var userDB  in _usersDB)
        //    {
        //        if (user.Name == userDB.Name)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        private User UserEntityToModel(UserEntity entity)
        {
            User user = new User()
            {
                Name = entity.Name,
                Role = (Roles)entity.Role
            };
            return user;
        }
    }
}