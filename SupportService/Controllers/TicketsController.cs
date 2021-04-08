using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
using SupportService.DataAccess.Repositories.Interfaces;
using SupportService.Models.Models;
using SupportService.Services.Interfaces;

namespace SupportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService, ILogger<TicketsController> logger)
        {
            _ticketService = ticketService;
            _logger = logger ?? new NullLogger<TicketsController>();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTicket() // Смотреть все тикеты
        {
            IEnumerable<Ticket> tickets = _ticketService.GetTickets();
            return Ok(tickets);
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetTicketsByUserId(int userId) // Просмотр тикетов пользователя
        {
            IEnumerable<Ticket> tickets = _ticketService.GetTicketsByUserId(userId);
            return Ok(tickets);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTicket(CreateTicketRequest createTicketRequest) //создаем Тикет
        {
            int result = _ticketService.CreateTicket(createTicketRequest);
            return Ok(result);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeTicketStatus(ChangeStatusRequest changeStatusRequest) // смена статуса тикета
        {
            _ticketService.ChangeStatus(changeStatusRequest);
            return Ok();
        }
    }
}
