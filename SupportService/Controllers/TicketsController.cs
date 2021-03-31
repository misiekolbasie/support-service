using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;

namespace SupportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(ILogger<TicketsController> logger)
        {
            _logger = logger ?? new NullLogger<TicketsController>();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTickets() // Смотреть все тикеты
        {
            return Ok("ALL TICKETS");
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetTicketsByUserId(int userId) // Просмотр тикетов пользователя
        {
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTicket(CreateTicketRequest createTicketRequest) //создаем Тикет
        {
            return Ok();
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeTicketStatus(ChangeStatusRequest changeStatusRequest) // смена статуса тикета
        {
            return Ok();
        }
    }
}
