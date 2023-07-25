using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Valideixo.Models;

namespace Valideixo.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("/")]
        public IActionResult Post(
            [FromBody]CreateUserModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            return Ok();
        }
    }
}