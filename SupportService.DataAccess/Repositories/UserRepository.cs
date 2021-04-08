using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly Dictionary<int, User> _usersDB = new Dictionary<int, User>();
        
        
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public int CreateUser(User user)
        {
            if (!ValidateUser(user))
            {
               throw new Exception("Такой пользователь уже существует!");
            }
            
            int maxCount = _usersDB.Count;
            user.Id = maxCount;
            _usersDB.Add(maxCount, user);
            return maxCount;
        }

        public User GetUserById(int id)
        {
            if (_usersDB.TryGetValue(id,out User user))
            {
                return user;
            }
            return null;
        }

        private bool ValidateUser(User user)
        {
            foreach (var userDB  in _usersDB)
            {
                if (user.Name == userDB.Value.Name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}