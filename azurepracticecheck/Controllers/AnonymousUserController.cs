using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using azurepracticecheck.Models;
using azurepracticecheck;

namespace azurepracticecheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AnonymousUserController : ControllerBase
    {
       // GET: api/AnonymousUser
       [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
          return  MenuItemOperations.GetConnection();
        }


    }
}
