using Domain.Common;

namespace Domain.MovieContext.MovieListAggregate;

public class MovieListId : BaseId
{
	public MovieListId(Guid guid)
	{
		Id = guid;
	}

	public override Guid Id { get; }
}