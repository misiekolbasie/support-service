using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SupportService.ApiDto;
using SupportService.Models.Enums;

namespace SupportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger ?? new NullLogger<UserController>();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            return Ok();
        }

    }
}
