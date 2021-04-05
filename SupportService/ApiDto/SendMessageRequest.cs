using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Models;

namespace SupportService.ApiDto
{
    public class SendMessageRequest
    {
        public int TicketId { get; set; }

        public string MessageText { get; set; }

        public int AutorId { get; set; }
    }
}