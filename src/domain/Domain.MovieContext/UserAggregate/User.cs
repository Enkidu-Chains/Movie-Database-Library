using Domain.Common;
using Domain.MovieContext.MovieListAggregate;

namespace Domain.MovieContext.UserAggregate;

public class User : IEntity<UserId>
{
	private readonly List<MovieListId> _movieLists;

	public User(UserId id)
	{
		Id = id;
		_movieLists= new List<MovieListId>();
	}	

	public UserId Id { get; }

	public List<MovieListId> MovieLists { get => new(_movieLists); }

	public void AddMovieList(MovieListId movieList)
	{
		_movieLists.Add(movieList);
	}

	public void RemoveMovieList(MovieListId movieList)
	{
		_movieLists.Remove(movieList);
	}
}