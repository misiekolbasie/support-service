using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;
using SupportService.Services.Interfaces;

namespace SupportService.Services
{
    public class MessageService : IMessageService
    {
        private readonly ILogger<MessageService> _logger;
        private readonly IMessageRepository _messageRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, ITicketRepository ticketRepository ,ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _ticketRepository = ticketRepository;
            _logger = logger ?? new NullLogger<MessageService>();
        }

        public IEnumerable<Message> GetMessagesByTicketId(int ticketId)
        {   // сделать проверку тикета
           CheckTicket(ticketId);
            // вызвать  imessage и вызвать у него метод вернуть мессаджи по тикет ид
            IEnumerable<Message> messages = _messageRepository.GetMessagesByTicketId(ticketId);
            return messages;
        }


        public int CreateMessage(SendMessageRequest sendMessageRequest)
        {
            CheckTicket(sendMessageRequest.TicketId);
            CheckUser(sendMessageRequest.AutorId);
            Message message = new Message()
            {
                AutorId = sendMessageRequest.AutorId, 
                Text = sendMessageRequest.MessageText,
                TicketId = sendMessageRequest.TicketId,
                CreateDate = DateTime.Now
            };
            int result = _messageRepository.CreateMessage(message);
            _ticketRepository.ChangeLastUpdate(sendMessageRequest.TicketId, message.CreateDate);
            return result;
        }
        private void CheckTicket(int checkTicketId)
        {
            Ticket ticket = _ticketRepository.GetTicketById(checkTicketId);
            if (ticket == null)
            {
                throw new Exception("Такого тикета нет!");
            }
        }
        private void CheckUser(int checkUserid)
        {
            User user = _userRepository.GetUserById(checkUserid);
            if (user == null)
            {
                throw new Exception("Такого пользователя не существует!");
            }
        }

    }
}
