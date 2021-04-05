using System.Collections.Generic;
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
    }
}