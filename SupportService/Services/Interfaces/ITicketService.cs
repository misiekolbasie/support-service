using SupportService.ApiDto;

namespace SupportService.Services.Interfaces
{
    public interface ITicketService
    {
        int CreateTicket(CreateTicketRequest createTicketRequest);
    }
}