using System.Reflection;
using Infrastructure.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext
{
	internal DbSet<Movie> Movies { get; set; } = null!;

	internal DbSet<MovieList> MovieLists { get; set; } = null!;

	internal DbSet<Image> Images { get; set; } = null!;

	internal DbSet<User> Users { get; set; } = null!;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions): base(dbContextOptions)
	{ }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(
				Assembly.GetAssembly(typeof(ApplicationDbContext))!
			);
	}

}