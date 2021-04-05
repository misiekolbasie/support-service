using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int CreateUser(User user);

        User GetUserById(int id);
    }
}