using Domain.Common;

namespace Domain.MovieContext.MovieAggregate;

public class MovieId : BaseId
{
	public MovieId(Guid guid)
	{
		Id = guid;
	}

	public override Guid Id { get; }
}