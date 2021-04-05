using SupportService.ApiDto;

namespace SupportService.Services.Interfaces
{
    public interface IUserService
    {
        int CreateUser(CreateUserRequest createUserRequest);
    }
}