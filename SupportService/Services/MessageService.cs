﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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

        public MessageService(IMessageRepository messageRepository, ITicketRepository ticketRepository ,ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _ticketRepository = ticketRepository;
            _logger = logger ?? new NullLogger<MessageService>();
        }

        public IEnumerable<Message> GetMessagesByTicketId(int ticketId)
        {   // сделать проверку тикета
            Ticket ticket = _ticketRepository.GetTicketById(ticketId);
            if (ticket == null)
            {
                throw new Exception("Такого тикета нет!");
            }

            IEnumerable<Message> messages = _messageRepository.GetMessagesByTicketId(ticketId);
            return messages;
            // вызвать  imessage и вызвать у него метод вернуть мессаджи по тикет ид

        }
    }
}
