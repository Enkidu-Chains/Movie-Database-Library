namespace Infrastructure.DataAccess.Models;

class Movie
{
	public int Id { get; set; }

	public string Title { get; set; } = null!;

	public string? Description { get; set; }

	public string? Author { get; set; }

	public string? Type { get; set; }

	public string? Studio { get; set; }

	public string? Status { get; set; }

	public DateOnly? DateAired { get; set; }

	public TimeSpan? Duration { get; set; }

	public int? PosterId { get; set; }

	public Image? Poster { get; set; }

	public ICollection<MovieList> MovieLists { get; set; }

	public ICollection<MovieToMovieList> MovieToMovieList { get; set; }
}