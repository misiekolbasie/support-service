using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Models;
using SupportService.Models.Enums;

namespace SupportService.ApiDto 
{
    public class CreateTicketRequest // модель содержит всю информацию для создания тикета.
    {
        public string Theme { get; set; }
        
        public string Message { get; set; }
        public Categories Categories { get; set; }
        public int UserId { get; set; }
    }
}
