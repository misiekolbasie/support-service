using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
using SupportService.Models.Models;
using SupportService.Services.Interfaces;

namespace SupportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IMessageService _messageService;

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger ?? new NullLogger<MessagesController>();
        }

        [HttpGet("GetByTicketId")]
        public async Task<IActionResult> GetMessagesByTicketId(int ticketId)
        {
            IEnumerable<Message> messages = _messageService.GetMessagesByTicketId(ticketId);
            return Ok(messages);
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendMessage(SendMessageRequest sendMessageRequest)
        {
            return Ok();
        }
    }
}
