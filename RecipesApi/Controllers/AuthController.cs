using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace RecipesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
		public IConfiguration Configuration {get; set; }

		public AuthController(IConfiguration configuration) {
			Configuration = configuration;
		}
        [HttpGet]
        public string Get()
        {
            var section = Configuration.GetSection("JWT");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section.GetValue<string>("Token")));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var issuer = section.GetValue<string>("Issuer");
			var audience = section.GetValue<string>("Audience");
			var jwtValidity = DateTime.Now.AddHours(section.GetValue<int>("ExpirationHours"));

			var token = new JwtSecurityToken(
				issuer,
				audience,
				expires: jwtValidity,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
