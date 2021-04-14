using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.DataAccess.Entities;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ILogger<TicketRepository> _logger;
        private readonly SupportServiceDbContext _ticketsDb;

        public TicketRepository(SupportServiceDbContext dbContext, ILogger<TicketRepository> logger)
        {
            _ticketsDb = dbContext;
            _logger = logger ?? new NullLogger<TicketRepository>();
        }
        public int CreateTicket(Ticket ticket)
        {
            //ticket v ticket entity , pishem property
            TicketEntity ticketEntity = new TicketEntity()
            {
                AutorId = ticket.AutorId,
                Category = (int)ticket.Category, //upcast
                CreateDate = ticket.CreateDate,
                LastUpdate = ticket.LastUpdate,
                Status = (int)ticket.Status,
                Theme = ticket.Theme
            };
            // save in base
            _ticketsDb.Tickets.Add(ticketEntity); //base.Tablica.add(object entity(stroka v bd))
            _ticketsDb.SaveChanges();// save base
            //return id
            return ticketEntity.Id;

        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            // go v bazy, vzyat vse etity ticketov
            List<TicketEntity> ticketEntities = _ticketsDb.Tickets.ToList();
            // entity prevratit v modely
            List<Ticket> tickets = new List<Ticket>();
            foreach (var entity in ticketEntities)
            {
                Ticket ticket = TicketEntityToModel(entity);
                tickets.Add(ticket);
            }
            // vernyt modely
            return tickets;
        }



        public IEnumerable<Ticket> GetTicketsByUserId(int userId)
        {
            // zaprosit vse entity 
            List<TicketEntity> ticketEntities = _ticketsDb.Tickets.ToList();
            List<Ticket> userTickets = new List<Ticket>();
            foreach (var entity in ticketEntities)
            {
                Ticket ticket = TicketEntityToModel(entity);
                // iz entity v ticket
                if (ticket.AutorId == userId)
                {
                    userTickets.Add(ticket);
                }
            }
            return userTickets;
        }

        public void ChangeStatus(int ticketId, Statuses newStatus)
        {
            // find ticket entity po id
            TicketEntity entity = _ticketsDb.Tickets.FirstOrDefault(entity => entity.Id == ticketId); //entity - SYSCHESTVYET TOLKO V ETIX SKOBKAX => entity.Id == ticketId
            //proverka est' li entity voobshe
            if (entity == null)
            {
                throw new Exception("Ticket not found");
            }
            // pomenyat status
            entity.Status = (int)newStatus;
            //save BASE
            _ticketsDb.SaveChanges();
        }

        public Ticket GetTicketById(int ticketId)
        {
            // find ticket entity po id
            TicketEntity entity = _ticketsDb.Tickets.FirstOrDefault(entity => entity.Id == ticketId); //entity - SYSCHESTVYET TOLKO V ETIX SKOBKAX => entity.Id == ticketId
            //proverka est' li entity voobshe
            if (entity == null)
            {
                return null;
            }
            // preobrazovanie iz entity v model
            Ticket ticket = TicketEntityToModel(entity);
            return ticket;
        }

        public void ChangeLastUpdate(int ticketId, DateTime lastUpdate)
        {
            // find ticket entity po id
            TicketEntity entity = _ticketsDb.Tickets.FirstOrDefault(entity => entity.Id == ticketId); //entity - SYSCHESTVYET TOLKO V ETIX SKOBKAX => entity.Id == ticketId
            //proverka est' li entity voobshe
            if (entity == null)
            {
                throw new Exception("Ticket not found");
            }
            // novoe vremya i save in base
            entity.LastUpdate = lastUpdate;
            _ticketsDb.SaveChanges();
        }

        private Ticket TicketEntityToModel(TicketEntity entity)
        {
            Ticket ticket = new Ticket()
            {
                AutorId = entity.AutorId,
                Category = (Categories)entity.Category,
                CreateDate = entity.CreateDate,
                LastUpdate = entity.LastUpdate,
                Status = (Statuses)entity.Status,
                Theme = entity.Theme
            };
            return ticket;
        }
    }
}
