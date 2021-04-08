using System.Collections.Generic;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        int CreateTicket(Ticket ticket);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetTicketsByUserId(int userId);
    }
}