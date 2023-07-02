using Microsoft.EntityFrameworkCore;
using MyReact_backend.Models;

namespace MyReact_backend.Context
{
	public class MyReactContext : DbContext
	{
		public MyReactContext(DbContextOptions<MyReactContext> options) : base(options)
		{
		}

		public DbSet<User> User { get; set; }
		public DbSet<Employee> Employee { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}

	}
}