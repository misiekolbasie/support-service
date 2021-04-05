using System;

namespace SupportService.Models.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public int AutorId { get; set; }
    }
}