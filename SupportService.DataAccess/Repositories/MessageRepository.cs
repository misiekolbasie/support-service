using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ILogger<MessageRepository> _logger;
        private readonly List<Message>_messagesDb= new List<Message>();

        public MessageRepository(ILogger<MessageRepository> logger)
        {
            _logger = logger ?? new NullLogger<MessageRepository>();
        }
        public int CreateMessage(Message message)
        {
            int maxValue = _messagesDb.Count;
            message.Id = maxValue;
            _messagesDb.Add(message);
            return maxValue;
        }

        public IEnumerable<Message> GetMessagesByTicketId(in int ticketId)
        {
          List<Message> messages = new List<Message>();
          foreach (var message in _messagesDb)
          {
              if (message.TicketId == ticketId)
              {
                  messages.Add(message);
              }
          }
          return messages.OrderBy(c=>c.CreateDate).ToList(); //отсортирует все мессаджи по крейт дате.
        }
    }
}