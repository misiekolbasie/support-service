using System.Xml.Serialization;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        int CreateMessage(Message message);
    }
}