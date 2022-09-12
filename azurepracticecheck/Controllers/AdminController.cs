using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using azurepracticecheck.Models;
using azurepracticecheck;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace azurepracticecheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    //[Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
   
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return MenuItemOperations.GetConnection();
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MenuItem menu)
        {
            MenuItemOperations.Update(id, menu);
            return Ok();
        }


    }
}
