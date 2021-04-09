using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using SupportService.ApiDto;
using SupportService.Models.Models;

namespace SupportService.Services.Interfaces
{
    interface IMessageService
    {
        IEnumerable<Message> GetMessagesByTicketId(int ticketId);
        int CreateMessage(SendMessageRequest sendMessageRequest);
    }
}
