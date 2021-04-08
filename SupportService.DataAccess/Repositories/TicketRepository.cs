using System;
using System.Collections;
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
            return tickets;
        }

        public IEnumerable<Ticket> GetTicketsByUserId(int userId)
        {
            // создать пустой лист
            List<Ticket> userTickets = new List<Ticket>();
            // обратиться в коллекцию тикетов, найти автор ид
            foreach (var ticketdb in _ticketsDb)
            {
                Ticket ticket = ticketdb.Value;
                // если ид юзера равно ид автора записать их в пустой лист
                if (ticket.AutorId == userId)
                {
                    userTickets.Add(ticket);
                }
            }
            return userTickets;
            //вернуть лист
        }
    }
}

//var tickets = _ticketsDb.Values.ToList();
// var users = _usersDB.Values.ToList();
// var ticketsByUserid = new List<Ticket>();
// foreach (var result in _ticketsDb)
// {
// result
//   if (Enumerable.SequenceEqual(_ticketsDb.Values, _usersDB.Values)
//  //  else
// label1.Text = "-1";
//}



//foreach (var ticketFromDB in _ticketsDb)
//{
//ticketss.Add(ticketFromDB.Value);  
//}
// var ticketss = _ticketsDb.Select(ticketFromDB => ticketFromDB.Value).ToList();
//return tickets.Select(entity => _ticketsDb.Values(tickets)).ToList();