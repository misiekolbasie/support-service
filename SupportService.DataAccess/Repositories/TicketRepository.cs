using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.DataAccess.Translators;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ILogger<TicketRepository> _logger;
        private readonly SupportServiceDbContext _dbContext;

        public TicketRepository(SupportServiceDbContext dbContextContext, ILogger<TicketRepository> logger)
        {
            _dbContext = dbContextContext;
            _logger = logger ?? new NullLogger<TicketRepository>();
        }

        public int CreateTicket(Ticket ticket)
        {
            //ticket v ticket entity , pishem property
            TicketEntity ticketEntity = ticket.ToEntity();
            // save in base
            _dbContext.Tickets.Add(ticketEntity); //base.Tablica.add(object entity(stroka v bd))
            _dbContext.SaveChanges();// save base
            //return id
            return ticketEntity.Id;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = _dbContext.Tickets.ToList().Select(c => c.ToModel()).ToList();
            //// go v bazy, vzyat vse etity ticketov
            //List<TicketEntity> ticketEntities = _dbContext.Tickets.ToList();
            //// entity prevratit v modely
            //List<Ticket> tickets = new List<Ticket>();
            //foreach (var entity in ticketEntities)
            //{
            //    Ticket ticket = TicketEntityToModel(entity);
            //    tickets.Add(ticket);
            //}
            //// vernyt modely
            return tickets;
        }

        public IEnumerable<Ticket> GetTicketsByUserId(int userId)
        {
            List<Ticket> userTickets = _dbContext.Tickets.Where(c => c.AutorId == userId).ToList()
                .Select(c => c.ToModel())
                .ToList();
            //// zaprosit vse entity 
            //List<TicketEntity> ticketEntities = _dbContext.Tickets.ToList();
            //List<Ticket> userTickets = new List<Ticket>();
            //foreach (var entity in ticketEntities)
            //{
            //    Ticket ticket = TicketEntityToModel(entity);
            //    // iz entity v ticket
            //    if (ticket.AutorId == userId)
            //    {
            //        userTickets.Add(ticket);
            //    }
            //}
            return userTickets;
        }

        public void ChangeStatus(int ticketId, Statuses newStatus)
        {
            // find ticket entity po id
            TicketEntity entity = _dbContext.Tickets.FirstOrDefault(entity => entity.Id == ticketId); //entity - SYSCHESTVYET TOLKO V ETIX SKOBKAX => entity.Id == ticketId
            //proverka est' li entity voobshe
            if (entity == null)
            {
                throw new Exception("Ticket not found");
            }
            // pomenyat status
            entity.Status = (int)newStatus;
            //save BASE
            _dbContext.SaveChanges();
        }

        public Ticket GetTicketById(int ticketId)
        {
            // find ticket entity po id
            TicketEntity entity = _dbContext.Tickets.FirstOrDefault(entity => entity.Id == ticketId);
            //proverka est' li entity voobshe
            if (entity == null)
            {
                return null;
            }
            // preobrazovanie iz entity v model
            Ticket ticket = entity.ToModel();
            return ticket;
        }

        public void ChangeLastUpdate(int ticketId, DateTime lastUpdate)
        {
            // find ticket entity po id
            TicketEntity entity = _dbContext.Tickets.FirstOrDefault(entity => entity.Id == ticketId);
            //proverka est' li entity voobshe
            if (entity == null)
            {
                throw new Exception("Ticket not found");
            }
            // novoe vremya i save in base
            entity.LastUpdate = lastUpdate;
            _dbContext.SaveChanges();
        }
    }
}
