using System;
using SupportService.Models.Enums;

namespace SupportService.Models.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        public string Theme { get; set; }
        
        public int AutorId { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public DateTime LastUpdate { get; set; }
        
        public Categories Category { get; set; }
        
        public Statuses Status { get; set; }
    }
}