namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.AppEvent;

public class AppEventRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventEntity>(dbContext),
  IAppEventRepository
{
}
