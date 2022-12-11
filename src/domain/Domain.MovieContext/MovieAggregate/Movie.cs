using Domain.Common;
using Domain.MovieContext.MovieListAggregate;

namespace Domain.MovieContext.MovieAggregate;

public class Movie: IEntity<MovieId>
{
	private readonly List<MovieListId> _containdInLists;

	public Movie(MovieId movieId, MovieInformation information, MovieListId InList)
	{
		Id = movieId;
		Information = information;
		_containdInLists = new List<MovieListId> { InList };
	}

	public Movie(MovieId movieId, MovieInformation information, IEnumerable<MovieListId> containdInLists)
	{
		Id = movieId;
		Information = information;
		_containdInLists = containdInLists.ToList();
	}

	public MovieId Id { get; }

	public MovieInformation Information { get; set; }

	public List<MovieListId> ContaindInLists { get => new(_containdInLists); }
}