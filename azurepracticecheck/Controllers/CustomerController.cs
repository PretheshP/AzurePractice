using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using azurepracticecheck.Models;
using azurepracticecheck;

namespace azurepracticecheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Customer")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            return MenuItemOperations.GetConnection();
        }
        [HttpGet("{userid}", Name = "Get Customer")]
        public object Get(int userid)
        {
            int cartCount = 0;
            List<MenuItem> list = new List<MenuItem>(MenuItemOperations.CartList(userid, ref cartCount));

            return new { list, cartCount };
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Cart> cart)
        {
            MenuItemOperations.InsertIntoCarts(cart);
            return Ok();
        }
        [HttpDelete("{cartId}")]
        public string Delete(int cartId)
        {
            return MenuItemOperations.Delete(cartId);
        }
  
    }
}