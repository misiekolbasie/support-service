using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportService.DataAccess.Entities
{
    [Table("messages")]
    public class MessageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Ticket))]
        [Column("ticketId")]
        public int TicketId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("createDate")]
        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(User))]
        [Column("autorId")]
        public int AutorId { get; set; }

        #region Navigation Property

        public virtual UserEntity User { get; set; }

        public virtual TicketEntity Ticket { get; set; }

        #endregion
    }
}
