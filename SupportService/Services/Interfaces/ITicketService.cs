using SupportService.ApiDto;
using SupportService.Models.Models;
using System.Collections.Generic;

namespace SupportService.Services.Interfaces
{
    public interface ITicketService
    {
        int CreateTicket(CreateTicketRequest createTicketRequest);

        IEnumerable<Ticket> GetTickets();
        IEnumerable<Ticket> GetTicketsByUserId(int userId);
        void ChangeStatus(ChangeStatusRequest changeStatusRequest);
    }
}