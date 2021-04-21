using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.DataAccess.Translators;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly SupportServiceDbContext _dbContext;
        
        
        public UserRepository(SupportServiceDbContext dbContextContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContextContext;
            _logger = logger;
        }

        public int CreateUser(User user)
        {
            UserEntity userEntity = user.ToEntity();
            //save in base
            _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();
            return userEntity.Id;
        }

        public User GetUserById(int userid)
        {
            // find ticket entity po id
            UserEntity entity = _dbContext.Users.FirstOrDefault(c => c.Id == userid);
            //proverka est' li entity voobshe
            if (entity == null)
            {
                return null;
            }
            // preobrazovanie iz entity v model
            User user = entity.ToModel();
            return user;
        }
    }
}