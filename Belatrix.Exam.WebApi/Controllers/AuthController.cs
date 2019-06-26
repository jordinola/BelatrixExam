using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Belatrix.Exam.WebApi.Identity.Data;
using Belatrix.Exam.WebApi.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Belatrix.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]User model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
                return Unauthorized();

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("test_data_key_123456789"));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken
            (
                issuer: "http://belatrix.com",
                audience: "http://belatrix.com",
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }
    }
}
