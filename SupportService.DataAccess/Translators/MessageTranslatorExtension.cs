using System;
using System.Collections.Generic;
using System.Text;
using SupportService.DataAccess.Entities;
using SupportService.Models.Models;

namespace SupportService.DataAccess.Translators
{
    internal static class MessageTranslatorExtension
    {
        internal static MessageEntity ToEntity(this Message message)
        {
            MessageEntity messageEntity = new MessageEntity()
            {
                AutorId = message.AutorId,
                CreateDate = message.CreateDate,
                Text = message.Text,
                TicketId = message.TicketId
            };
            return messageEntity;
        }

        internal static Message ToModel(this MessageEntity entity)
        {
            Message message = new Message()
            {
                Id = entity.Id,
                AutorId = entity.AutorId,
                CreateDate = entity.CreateDate,
                Text = entity.Text,
                TicketId = entity.TicketId,
            };
            return message;
        }
    }
}