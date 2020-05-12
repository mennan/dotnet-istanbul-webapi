namespace DotNetIstanbul.WebApi.Helpers
{
	public class ApiReturn<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public string InternalMessage { get; set; }
		public T Data { get; set; }
	}

	public class ApiReturn : ApiReturn<object>
	{
	}
}