namespace Domain.Common;

public interface IRepository<TEntity>
	where TEntity: IEntity<BaseId>
{
	public void Save(TEntity entity);
}
