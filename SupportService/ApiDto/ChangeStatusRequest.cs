using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Models.Enums;

namespace SupportService.ApiDto
{
    public class ChangeStatusRequest
    {
        public int TicketId { get; set; }

        public Statuses NewStatus { get; set; }
    }
}
