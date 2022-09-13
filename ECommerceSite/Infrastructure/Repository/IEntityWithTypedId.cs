namespace ECommerceSite.Infrastructure.Repository
{
	public interface IEntityWithTypedId<TId>
	{
        TId Id { get; }
    }
}