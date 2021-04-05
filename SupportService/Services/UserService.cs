using Microsoft.Extensions.Logging;
using SupportService.ApiDto;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;
using SupportService.Services.Interfaces;

namespace SupportService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        
        public int CreateUser(CreateUserRequest createUserRequest)
        {
            User user = new User() {Name = createUserRequest.Name, Role = createUserRequest.Role};
            int result = _userRepository.CreateUser(user);
            return result;
        }
    }
}