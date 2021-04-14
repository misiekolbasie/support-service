using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
using SupportService.DataAccess.Repositories;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Enums;
using SupportService.Models.Models;
using SupportService.Services.Interfaces;

namespace SupportService.Services
{
    public class TicketService : ITicketService
    {
        private readonly ILogger<TicketService> _logger;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;


        public TicketService(ITicketRepository ticketRepository, IUserRepository userRepository, IMessageRepository messageRepository,
            ILogger<TicketService> logger)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _logger = logger ?? new NullLogger<TicketService>();
        }

        public int CreateTicket(CreateTicketRequest createTicketRequest)
        {
            var userId = createTicketRequest.UserId;
            User user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("Пользователя не существует!");
            }
            
            DateTime createDate = DateTime.Now;
            
            Ticket newTicket = new Ticket()
            {
                AutorId = createTicketRequest.UserId,
                Category = createTicketRequest.Categories,
                CreateDate = createDate,
                LastUpdate = createDate,
                Status = Statuses.Open,
                Theme = createTicketRequest.Theme
            };
            int newTicketId = _ticketRepository.CreateTicket(newTicket);
            
            Message newMessage = new Message()
            {
                AutorId = createTicketRequest.UserId,
                Text = createTicketRequest.Message,
                CreateDate = createDate,
                TicketId = newTicketId
            };
            int newMessageId = _messageRepository.CreateMessage(newMessage);
            
            return newTicketId;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketRepository.GetAllTickets().OrderBy(c => c.LastUpdate).ToList();
        }

        public IEnumerable<Ticket> GetTicketsByUserId(int userId)
        {
            //проверить юзера 
            User user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("Пользователя не существует!");
            }
            //достать тикеты по юзерИд
            IEnumerable<Ticket> tickets = _ticketRepository.GetTicketsByUserId(userId);
            //вернуть тикеты
            return tickets.OrderBy(c => c.LastUpdate).ToList();
        }

        public void ChangeStatus(ChangeStatusRequest changeStatusRequest)
        {
            _ticketRepository.ChangeStatus(changeStatusRequest.TicketId, changeStatusRequest.NewStatus);
        }
    }
}