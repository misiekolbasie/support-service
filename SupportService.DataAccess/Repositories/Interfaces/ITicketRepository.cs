using System;
using System.Collections.Generic;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        int CreateTicket(Ticket ticket);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetTicketsByUserId(int userId);
        void ChangeStatus(int ticketId, Statuses newStatus);
        Ticket GetTicketById(int ticketId);
        void ChangeLastUpdate(in int ticketId, in DateTime messageCreateDate);
    }
}