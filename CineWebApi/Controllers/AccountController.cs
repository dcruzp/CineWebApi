using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CineWebApi.DBModels;
using CineWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<CineUser> _userManager;
        private readonly SignInManager<CineUser> _singInManager;
        private readonly IConfiguration _configuration; 


        public AccountController(UserManager<CineUser> userManager,
                                 SignInManager<CineUser> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _configuration = configuration; 
        }


        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = new CineUser { UserName = model.Email , Email = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password); 
                if (result.Succeeded)
                {
                    return BuildToken(model); 
                }
                else
                {
                    return BadRequest("Username or password invalid"); 
                }
            }
            else
            {
                return BadRequest(ModelState); 
            }
        }

        private IActionResult BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("mi valor", "Lo que yo quiera "),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1); 

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login ([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password , true , true);
                if (result.Succeeded)
                {
                    return BuildToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "invalid token attemp.");
                    return BadRequest(ModelState); 
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        
    }
}
