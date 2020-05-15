using DotNetIstanbul.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetIstanbul.WebApi.Controllers.Base
{
	[ApiController]
	[Authorize]
	[Route("[controller]")]
	public class BaseApiController : Controller
	{
		[NonAction]
		protected IActionResult Success<T>(string message, string internalMessage, T data)
		{
			return Success(new ApiReturn<T>
			{
				Success = true,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult Success<T>(ApiReturn<T> data)
		{
			return Ok(data);
		}

		[NonAction]
		protected IActionResult Created<T>(string message, string internalMessage, T data)
		{
			return Created(new ApiReturn<T>
			{
				Success = true,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult Created<T>(ApiReturn<T> data)
		{
			return StatusCode(201, data);
		}

		[NonAction]
		protected IActionResult NoContent<T>(string message, string internalMessage, T data)
		{
			return NoContent(new ApiReturn<T>
			{
				Success = true,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult NoContent<T>(ApiReturn<T> data)
		{
			return StatusCode(204, data);
		}

		[NonAction]
		protected IActionResult BadRequest<T>(string message, string internalMessage, T data)
		{
			return BadRequest(new ApiReturn<T>
			{
				Success = false,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult BadRequest<T>(ApiReturn<T> data)
		{
			return StatusCode(400, data);
		}

		[NonAction]
		protected IActionResult Unauthorized<T>(string message, string internalMessage, T data)
		{
			return Unauthorized(new ApiReturn<T>
			{
				Success = false,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult Unauthorized<T>(ApiReturn<T> data)
		{
			return StatusCode(401, data);
		}

		[NonAction]
		protected IActionResult Forbidden<T>(string message, string internalMessage, T data)
		{
			return Forbidden(new ApiReturn<T>
			{
				Success = false,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult Forbidden<T>(ApiReturn<T> data)
		{
			return StatusCode(403, data);
		}

		[NonAction]
		protected IActionResult NotFound<T>(string message, string internalMessage, T data)
		{
			return NotFound(new ApiReturn<T>
			{
				Success = false,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult NotFound<T>(ApiReturn<T> data)
		{
			return StatusCode(404, data);
		}

		[NonAction]
		protected IActionResult Error<T>(string message, string internalMessage, T data)
		{
			return Error(new ApiReturn<T>
			{
				Success = false,
				Message = message,
				InternalMessage = internalMessage,
				Data = data
			});
		}

		[NonAction]
		protected IActionResult Error<T>(ApiReturn<T> data)
		{
			return StatusCode(500, data);
		}
	}
}