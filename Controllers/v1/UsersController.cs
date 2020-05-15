using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetIstanbul.WebApi.Controllers.Base.v1;
using DotNetIstanbul.WebApi.Entity;
using DotNetIstanbul.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetIstanbul.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class UsersController : Basev1ApiController
	{
		private readonly HrContext _context;

		public UsersController(HrContext context)
		{
			_context = context;
		}

		/// <summary>
		/// List all users
		/// </summary>
		/// <returns>User list</returns>
		[HttpGet]
		[ProducesResponseType(typeof(List<DUsers>), 200)]
		public async Task<IActionResult> Get()
		{
			var users = await _context.Users.ToListAsync();

			return Success("Users listed.", null, users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);

			if (user == null) return NotFound<object>("User not found.", "User not found in database.", null);

			return Success("User found.", null, user);
		}

		/// <summary>
		/// Create a new user
		/// </summary>
		/// <param name="model">User information</param>
		/// <returns>Results</returns>
		[HttpPost]
		[ValidateModel]
		[ProducesResponseType(typeof(ApiReturn<DUsers>), 200)]
		[ProducesResponseType(typeof(ApiReturn<DUsers>), 400)]
		[ProducesResponseType(typeof(ApiReturn<DUsers>), 500)]
		public async Task<IActionResult> Post([FromBody] DUsers model)
		{
			try
			{
				await _context.Users.AddAsync(model);
				await _context.SaveChangesAsync();

				return Success("User added successfully.", null, model);
			}
			catch (Exception ex)
			{
				return Error<object>("Something went wrong!", ex.Message, null);
			}
		}

		[HttpPut("{id}")]
		[ValidateModel]
		public async Task<IActionResult> Put(Guid id, [FromBody] DUsers model)
		{
			try
			{
				var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);

				if (user == null) return NotFound<object>("User not found.", "User not found in database.", null);

				user.Name = model.Name;
				user.Surname = model.Surname;
				user.Age = model.Age;

				await _context.SaveChangesAsync();

				return Success("User updated successfully.", null, model);
			}
			catch (Exception ex)
			{
				return Error<object>("Something went wrong!", ex.Message, null);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);

				if (user == null) return NotFound<object>("User not found.", "User not found in database.", null);

				_context.Users.Remove(user);

				await _context.SaveChangesAsync();

				return Success<object>("User deleted successfully.", null, null);
			}
			catch (Exception ex)
			{
				return Error<object>("Something went wrong!", ex.Message, null);
			}
		}
	}
}