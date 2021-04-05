using System;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
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
        

        public TicketService(ITicketRepository ticketRepository, IUserRepository userRepository, ILogger<TicketService> logger)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _logger = logger ?? new NullLogger<TicketService>();
        }

        public int CreateTicket(CreateTicketRequest createTicketRequest)
        {
            User user = _userRepository.GetUserById(createTicketRequest.UserId);
            if (user == null)
            {
                throw new Exception("Пользователя не существует!");
            }
            
            Ticket newTicket = new Ticket()
            {
                AutorId = createTicketRequest.UserId,
                Category = createTicketRequest.Categories,
                CreateDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                Status = Statuses.Open,
                Theme = createTicketRequest.Theme
            };
            int result = _ticketRepository.CreateTicket(newTicket);
            return result;
        }
    }
}