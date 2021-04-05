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
using SupportService.Services.Interfaces;

namespace SupportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _userService = service;
            _logger = logger ?? new NullLogger<UserController>();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            int result = _userService.CreateUser(createUserRequest);
            return Ok();
        }

    }
}
