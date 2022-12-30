namespace Infrastructure.DataAccess.Models;

class MovieList
{	
	public int Id { get; set; }

	public string Name { get; set; }

	public int OwnerId { get; set; }

	public User Owner { get; set; }

	public ICollection<Movie> Movies { get; set; } 

	public ICollection<MovieToMovieList> MovieToMovieList { get; set; }
}
