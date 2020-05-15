using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotNetIstanbul.WebApi.Controllers.Base;
using DotNetIstanbul.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DotNetIstanbul.WebApi.Controllers
{
	[ApiVersionNeutral]
	public class AuthController : BaseApiController
	{
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[AllowAnonymous]
		[HttpPost("token")]
		public IActionResult Post([FromBody] AuthModel model)
		{
			if (model.UserName == "john" && model.Password == "Asd1234")
			{
				var claims = new[]
				{
					new Claim(ClaimTypes.Name, "John"),
					new Claim(ClaimTypes.Surname, "Doe"),
					new Claim(ClaimTypes.DateOfBirth, "1970/01/01")
				};

				var key = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["Authentication:JwtKey"]));

				var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.UtcNow.AddMonths(1),
					signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
				);
				var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

				return Ok(new
				{
					Token = generatedToken
				});
			}

			return Unauthorized();
		}
	}
}