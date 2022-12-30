namespace Infrastructure.DataAccess.Models;

class MovieToMovieList
{
	public int MovieId { get; set; }

	public int MovieListId { get; set; }

	public Movie Movie { get; set; }

	public MovieList MovieList { get; set; }
}