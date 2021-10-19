using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork10.Models;
using Homework10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HomeWork10.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly IConfiguration config;

        public AccountController(SignInManager<IdentityUser> SignInManager, UserManager<IdentityUser> UserManager, IConfiguration config)
        {
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
            this.config = config;
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDTO model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
                return GenerateJWTToken(model.Email, user);
            }

            throw new Exception("error");
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTO model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = UserManager.Users.SingleOrDefault(x => x.Email.Equals(model.Email));
                return await GenerateJWTToken(user.Email, user);
            }

            throw new Exception("error login");
        }

        private async Task<object> GenerateJWTToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToInt32(config["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                config["JwtIssuer"],
                config["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
