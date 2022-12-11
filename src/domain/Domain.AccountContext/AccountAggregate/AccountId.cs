using Domain.Common;

namespace Domain.UserContext.AccountAggregate;

public class AccountId : BaseId
{
	public AccountId(Guid id)
	{
		Id = id;
	}	

	public override Guid Id { get; }
}