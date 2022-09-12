using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using azurepracticecheck.Models;
using azurepracticecheck;

namespace azurepracticecheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id, string password)
        {
            List<User> list = MenuItemOperations.UserList();
            bool user = list.Any(p => p.userId == id && p.password == password);
            if (user == true)
                return "true";
            return "falseSubmission";
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            MenuItemOperations.Insert(user);
            return Ok();
        }
        
    }
}