using System.Collections;
using Domain.Common;
using Domain.MovieContext.MovieAggregate;
using Domain.MovieContext.UserAggregate;

namespace Domain.MovieContext.MovieListAggregate;

public class MovieList : IEnumerable<MovieId>, IEntity<MovieListId>
{
	private readonly List<MovieId> _movieIds;

	public MovieList(MovieListId movieListId, UserId ownerId)
	{
		Id = movieListId;
		OwnerId= ownerId;
		_movieIds= new List<MovieId>();
	}

	public MovieList(MovieListId movieListId, UserId ownerId, IEnumerable<MovieId> movieIds)
	{
		Id = movieListId;
		OwnerId = ownerId;
		_movieIds = movieIds.ToList();
	}

	public MovieListId Id{ get; }

	public UserId OwnerId { get; }

	public void AddMovie(MovieId movieId)
	{
		_movieIds.Add(movieId);
	}

	public void RemoveMovie(MovieId	movieId)
	{
		_movieIds.Remove(movieId);
	}

	public Movie? FindByName(string name, IMovieRepository movieRepository)
	{
		return movieRepository.FindByNameInSet(name, _movieIds);
	}

	public IEnumerator<MovieId> GetEnumerator()
	{
		return new List<MovieId>(_movieIds).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}