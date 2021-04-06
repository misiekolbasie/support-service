using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ILogger<TicketRepository> _logger;
        private readonly Dictionary<int, Ticket> _ticketsDb = new Dictionary<int, Ticket>();

        public TicketRepository(ILogger<TicketRepository> logger)
        {
            _logger = logger ?? new NullLogger<TicketRepository>();
        }
        public int CreateTicket(Ticket ticket)
        {
            int maxCount = _ticketsDb.Count;
            _ticketsDb.Add(maxCount, ticket);
            return maxCount;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var tickets = _ticketsDb.Values.ToList();

            var ticketss = new List<Ticket>();
            //foreach (var ticketFromDB in _ticketsDb)
            //{
              //ticketss.Add(ticketFromDB.Value);  
            //}
           // var ticketss = _ticketsDb.Select(ticketFromDB => ticketFromDB.Value).ToList();
            return tickets;
            //return tickets.Select(entity => _ticketsDb.Values(tickets)).ToList();
        }
    }
}