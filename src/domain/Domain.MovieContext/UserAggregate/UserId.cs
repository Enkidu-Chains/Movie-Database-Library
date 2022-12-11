using Domain.Common;

namespace Domain.MovieContext.UserAggregate;

public class UserId : BaseId
{
	public UserId(Guid guid)
	{
		Id = guid;
	}

	public override Guid Id { get; }
}
