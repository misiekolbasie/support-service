using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ILogger<TicketRepository> _logger;
        private readonly List<Ticket>_ticketsDb = new List<Ticket>();

        public TicketRepository(ILogger<TicketRepository> logger)
        {
            _logger = logger ?? new NullLogger<TicketRepository>();
        }
        public int CreateTicket(Ticket ticket)
        {
            int maxCount = _ticketsDb.Count;
            ticket.Id = maxCount;
            _ticketsDb.Add(ticket);
            return maxCount;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var tickets = _ticketsDb.ToList();
            return tickets;
        }

        public IEnumerable<Ticket> GetTicketsByUserId(int userId)
        {
            // создать пустой лист
            List<Ticket> userTickets = new List<Ticket>();
            // обратиться в коллекцию тикетов, найти автор ид
            foreach (var ticket in _ticketsDb)
            {
                // если ид юзера равно ид автора записать их в пустой лист
                if (ticket.AutorId == userId)
                {
                    userTickets.Add(ticket);
                }
            }
            return userTickets;
            //вернуть лист
        }

        public void ChangeStatus(int ticketId, Statuses newStatus)
        {
            // обратиться в коллекцию тикетов, и найти тикет по ид
            foreach (var ticket in _ticketsDb)
            {
                if (ticket.Id == ticketId)
                {
                    //поменять статус у тикета на новый
                    ticket.Status = newStatus;
                    break;
                }
            }
            throw new Exception("Тикет не найден!");
        }

        public Ticket GetTicketById(int ticketId)
        {
            foreach (var ticket in _ticketsDb)
            {
                if (ticket.Id == ticketId)
                {
                    return ticket;
                }
            }
            return null;
        }

        public void ChangeLastUpdate(in int ticketId, in DateTime messageCreateDate)
        {
            Ticket ticket = GetTicketById(ticketId);

        }
    }
}
