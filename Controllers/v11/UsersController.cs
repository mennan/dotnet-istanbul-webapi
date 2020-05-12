using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetIstanbul.WebApi.Controllers.Base.v11;
using DotNetIstanbul.WebApi.Entity;
using DotNetIstanbul.WebApi.Helpers;
using DotNetIstanbul.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetIstanbul.WebApi.Controllers.v11
{
	[ApiVersion("1.1")]
    public class UsersController : Basev11ApiController
    {
		[HttpPost("{id}/state")]
		public async Task<IActionResult> Post([FromBody] StateModel model)
		{
			return Success("Changed user state successfully.", null, model.IsActive);
		}
    }
}