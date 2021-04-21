using System;
using System.Collections.Generic;
using System.Text;
using SupportService.DataAccess.Entities;
using SupportService.Models.Enums;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Translators
{
    internal static class TicketTranslatorExtension
    {
        internal static TicketEntity ToEntity(this Ticket ticket)
        {
            TicketEntity ticketEntity = new TicketEntity()
            {
                AutorId = ticket.AutorId,
                Category = (int)ticket.Category, //upcast
                CreateDate = ticket.CreateDate,
                LastUpdate = ticket.LastUpdate,
                Status = (int)ticket.Status,
                Theme = ticket.Theme
            };
            return ticketEntity;
        }

        internal static Ticket ToModel(this TicketEntity entity)
        {
            Ticket ticket = new Ticket()
            {
                Id = entity.Id,
                AutorId = entity.AutorId,
                Category = (Categories)entity.Category,
                CreateDate = entity.CreateDate,
                LastUpdate = entity.LastUpdate,
                Status = (Statuses)entity.Status,
                Theme = entity.Theme
            };
            return ticket;
        }
    }
}