using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportService.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("role")]
        public int Role { get; set; }

        #region Navigation property

        public virtual List<TicketEntity> Tickets { get; set; }

        public virtual List<MessageEntity> Messages { get; set; }

        #endregion
    }
}
