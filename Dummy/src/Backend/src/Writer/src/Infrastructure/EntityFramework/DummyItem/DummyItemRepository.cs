namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.DummyItem;

public class DummyItemRepository(AppDbContext dbContext) :
  AppRepositoryBase<DummyItemEntity>(dbContext),
  IDummyItemRepository
{
}
