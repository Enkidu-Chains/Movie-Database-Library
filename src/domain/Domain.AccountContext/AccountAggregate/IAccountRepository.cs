using Domain.Common;

namespace Domain.UserContext.AccountAggregate;

public interface IAccountRepository : IRepository<Account>
{
	public bool IsLoginAlreadyTaken(string login);

	public bool IsEmailAlreadyTaken(string password);
}