using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Models.Enums;

namespace SupportService.ApiDto
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public Roles Roles { get; set; }
    }
}
