using HomeTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeTask.Data.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{

	}
	public DbSet<Employee> Employees { get; set; }
}
