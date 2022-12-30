using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Models.Configuration;

class MovieListConfiguration : IEntityTypeConfiguration<MovieList>
{
	public void Configure(EntityTypeBuilder<MovieList> movieList)
	{
		movieList.HasKey(x => x.Id);

		movieList.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		movieList.HasOne(x => x.Owner)
			.WithMany(x => x.MovieLists)
			.HasForeignKey(x => x.OwnerId)
			.IsRequired();

		movieList.HasMany(x => x.Movies)
			.WithMany(x => x.MovieLists)
			.UsingEntity<MovieToMovieList>(movieToMovieList =>
			{
				movieToMovieList.HasKey(x => new { x.MovieId, x.MovieListId });

				movieToMovieList.HasOne(x => x.MovieList)
					.WithMany(x => x.MovieToMovieList)
					.HasForeignKey(x => x.MovieListId)
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
	}
}