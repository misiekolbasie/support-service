using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ILogger<MessageRepository> _logger;
        private readonly SupportServiceDbContext _messageDb;

        public MessageRepository(SupportServiceDbContext dbContext, ILogger<MessageRepository> logger)
        {
            dbContext = _messageDb;
            _logger = logger ?? new NullLogger<MessageRepository>();
        }

        public int CreateMessage(Message message)
        {
            //mesage c message entity , pishem property
            MessageEntity messageEntity = new MessageEntity()
            {
                AutorId = message.AutorId,
                CreateDate = message.CreateDate,
                Text = message.Text,
                TicketId = message.TicketId
            };
            //save in base
            _messageDb.Messages.Add(messageEntity); //base.Tablica.add(object entity(stroka v bd))
            _messageDb.SaveChanges();
            //return id
            return messageEntity.Id;
        }

        public IEnumerable<Message> GetMessagesByTicketId(int ticketId)
        {
            // zaprosit vse entity 
            List<MessageEntity> messageEntities = _messageDb.Messages.ToList();
            List<Message> ticketMessages = new List<Message>();
            foreach (var entity in messageEntities)
            {
                Message message = MessageEntityToModel(entity);
                if (message.AutorId == ticketId)
                {
                    ticketMessages.Add(message);
                }
            }
            return ticketMessages.OrderBy(c => c.CreateDate).ToList(); //отсортирует все мессаджи по крейт дате.
        }

        private Message MessageEntityToModel(MessageEntity entity)
        {
            Message message = new Message()
            {
                AutorId = entity.AutorId,
                CreateDate = entity.CreateDate,
                Text = entity.Text,
                TicketId = entity.TicketId
            };
            return message;
        }

    }
}