using System.ComponentModel.DataAnnotations;

using Domain.Common;

namespace Domain.UserContext.AccountAggregate;

public class Account : IEntity<AccountId>
{
	private string? _email;

	public Account(AccountId id, string login, string password, string email)
	{
		Id = id;
		Login = login;
		Password = password;
		Email =email;
	}

	public AccountId Id { get; }

	public string Login { get; set; }

	public string Password { get; set; }

	public string? Email
	{
		get
		{
			return _email;
		}
		set 
		{
			if (new EmailAddressAttribute().IsValid(value))
			{
				throw new InvalidOperationException("Email is not valid");
			}

			_email = value;
		}
	}
}