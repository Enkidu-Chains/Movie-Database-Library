namespace Domain.Common;

public interface IEntity<out TId>
	where TId : BaseId
{
	public TId Id { get; }
}
