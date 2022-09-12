using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace azurepracticecheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config) { _config = config; }
        //[HttpGet("{id}")] public IActionResult Get(int id) { return Ok(GenerateJSONWebToken(id)); }

        //private string GenerateJSONWebToken(int userId)
        //{
        //    string userRole = "";

        //    if (userId == 1) userRole = "Admin";

        //    else if (userId != -1 && userId != 1) userRole = "Customer";

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new List<Claim> { new Claim(ClaimTypes.Role, userRole), new Claim("UserId", userId.ToString()) };

        //    //var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials); return new JwtSecurityTokenHandler().WriteToken(token);

        //}
    }
}







// ﻿using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Reflection.Metadata;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;

// namespace azurepracticecheck.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AuthController : ControllerBase
//     {
//         private IConfiguration _config;

//         public AuthController(IConfiguration config) { _config = config; }
//         [HttpGet("{id}")] public IActionResult Get(int id) { return Ok(GenerateJSONWebToken(id)); }

//         private string GenerateJSONWebToken(int userId)
//         {
//             string userRole = "";

//             if (userId == 1) userRole = "Admin";

//             else if (userId != -1 && userId != 1) userRole = "Customer";

//             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//             var claims = new List<Claim> { new Claim(ClaimTypes.Role, userRole), new Claim("UserId", userId.ToString()) };

//             var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims: claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials); return new JwtSecurityTokenHandler().WriteToken(token);

//         }
//     }
// }

