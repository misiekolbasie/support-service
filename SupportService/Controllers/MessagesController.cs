using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;

namespace SupportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger ?? new NullLogger<MessagesController>();
        }

        [HttpGet("GetByTicketId")]
        public async Task<IActionResult> GetMessagesByTicketId(int ticketId)
        {
            return Ok();
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendMessage(SendMessageRequest sendMessageRequest)
        {
            return Ok();
        }
    }
}
