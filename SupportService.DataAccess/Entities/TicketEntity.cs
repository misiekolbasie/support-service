using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportService.DataAccess.Entities
{
    [Table("tickets")]
    public class TicketEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("theme")]
        public string Theme { get; set; }

        [Column("autorId")]
        [ForeignKey(nameof(User))]
        public int AutorId { get; set; }

        [Column("createData")]
        public DateTime CreateDate { get; set; }

        [Column("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [Column("category")]
        public int Category { get; set; }

        [Column("status")]
        public int Status { get; set; }

        #region Navigation property

        public virtual UserEntity User { get; set; }

        public virtual List<MessageEntity> Messages { get; set; }

        #endregion
    }
}
