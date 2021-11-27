using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRequestManagement_RestAPI.Models;

namespace TravelRequestManagement_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        private TravelRequestSystemContext contextDB;

        //--- dependency injection for configuration ---//
        public LoginController(IConfiguration config, TravelRequestSystemContext _contextDB)
        {
            _config = config;
            contextDB = _contextDB;
        }

        [AllowAnonymous]
        [HttpGet("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();


            //--- Authenticate the user ---//
            Login _user = AuthenticateUser(username, password);

            //--- validate ---//
            if (_user != null)
            {
                var tokenString = GenerateJWT(username, password);
                response = Ok(new { username = _user.Username, RoleId = _user.UserType, Token = tokenString });
                return response;
            }
            return response;
        }

        private string GenerateJWT(string username, string password)
        {
            //--- getting security ---//
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //--- signing credentials ---//
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //--- generate the token ---//
            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Login AuthenticateUser(string username, string password)
        {
            //Validate the user credentials
            Login user = contextDB.Login.FirstOrDefault(us => us.Username == username && us.Password == password);
            if (user != null)
                return user;
            else
                return null;
        }
    }
}
