using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetIstanbul.WebApi.Entity
{
	[Table("User")]
	public class DUsers
	{
		[Key]
		public Guid UserId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public int Age { get; set; }
	}
}