using System.Diagnostics.CodeAnalysis;

namespace Domain.MovieContext.MovieAggregate;

public class MovieInformation
{	
	public MovieInformation([NotNull]string title)
	{
		Title = title;
	}

	public string Title { get; }

	public Poster? Poster { get; init; }

	public string? Description { get; init; }

	public string? Author { get; init; }

	public string? Type { get; init; }

	public string? Studios { get; init; }

	public DateOnly? DateAired { get; init; }

	public string? Status { get; init; }

	public string? Duration { get; set; }

	public string? Quality { get; set; }
}
