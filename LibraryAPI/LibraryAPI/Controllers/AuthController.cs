using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using LibraryAPI.BL.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerRequestDto)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var result = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    result = await userManager.AddToRolesAsync(user, registerRequestDto.Roles);

                    if(result.Succeeded)
                    {
                        return Ok(new { Message = "User registered successfully" });
                    }
                }
            }
            
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequesDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequesDto.Username);
            if (user == null)
                return BadRequest("Incorrect Username");

            var result = await userManager.CheckPasswordAsync(user, loginRequesDto.Password);
            if (!result)
                return BadRequest("Incorrect Password");


            var roles = await userManager.GetRolesAsync(user);

            if (roles != null)
            {
                var jwtToken = GenerateJwtToken(user, roles.ToList());

                var responce = new LoginResponceDto
                {
                    JwtToken = jwtToken
                };

                return Ok(responce);
            }

            return BadRequest("Failed to login");
        }

        private string GenerateJwtToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
