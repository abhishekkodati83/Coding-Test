using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Coding_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Coding_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTSettings jwtSettings;

        public UserController(IUserRepository userRepository, IOptions<JWTSettings> options)
        {
            this._userRepository = userRepository;
            this.jwtSettings = options.Value;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userCred)
        {
            var result = this._userRepository.Authenticate(userCred.Username, userCred.Password);

            if (result == false)
                return Unauthorized();

            // Generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this.jwtSettings.SecurityKey);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userCred.Username) }),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDesc);
            string finalToken = tokenHandler.WriteToken(token);

            return Ok(finalToken);
        }
    }
}
