using System;
using Microsoft.EntityFrameworkCore;

namespace DotNetIstanbul.WebApi.Entity
{
	public class HrContext : DbContext
	{
		public DbSet<DUsers> Users { get; set; }

		public HrContext(DbContextOptions<HrContext> options)
		: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DUsers>().HasData(
				new DUsers { UserId = new Guid("3FD1B461-F590-4A68-8CE7-6B216420E0F4"), Name = "Mennan", Surname = "Köse", Age = 28 }, new DUsers { UserId = new Guid("6D4FCBD5-D7AE-4C6E-8EB5-5B0B5D125ACA"), Name = "Anıl", Surname = "Atalay", Age = 18 });
		}
	}
}