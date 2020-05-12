using Microsoft.AspNetCore.Mvc;

namespace DotNetIstanbul.WebApi.Controllers.Base.v1
{
	[Route("v{version:apiVersion}/[controller]")]
	public class Basev1ApiController : BaseApiController
	{

	}
}