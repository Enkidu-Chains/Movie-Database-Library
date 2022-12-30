using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Models.Configuration;

class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
	public void Configure(EntityTypeBuilder<Movie> movie)
	{
		movie.HasKey(x => x.Id);

		movie.Property(x => x.Title)
			.HasMaxLength(50)
			.IsRequired();

		movie.Property(x => x.Description)
			.HasMaxLength(5000);

		movie.Property(x => x.Author)
			.HasMaxLength(50);

		movie.Property(x => x.Type)
			.HasMaxLength(50);

		movie.Property(x => x.Studio)
			.HasMaxLength(50);

		movie.Property(x => x.Status)
			.HasMaxLength(50);

		movie.Property(x => x.DateAired)
			.HasDefaultValue(
				DateOnly.FromDateTime(DateTime.UtcNow)
			);

		movie.HasOne(x => x.Poster)
			.WithOne(x => x.Movie)
			.HasForeignKey<Image>(x => x.MovieId)
			.OnDelete(DeleteBehavior.Cascade);

		movie.HasMany(x => x.MovieLists)
			.WithMany(x => x.Movies)
			.UsingEntity<MovieToMovieList>(movieToMovieList =>
			{
				movieToMovieList.HasKey(x => new { x.MovieId, x.MovieListId });

				movieToMovieList.HasOne(x => x.Movie)
					.WithMany(x => x.MovieToMovieList)
					.HasForeignKey(x => x.MovieId)
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
	}
}