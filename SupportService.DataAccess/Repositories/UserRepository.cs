using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly Dictionary<int, User> _userDB = new Dictionary<int, User>();
        
        
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }

        public int CreateUser(User user)
        {
            int maxCount = _userDB.Count;
            _userDB.Add(maxCount, user);
            return maxCount;
        }
    }
}