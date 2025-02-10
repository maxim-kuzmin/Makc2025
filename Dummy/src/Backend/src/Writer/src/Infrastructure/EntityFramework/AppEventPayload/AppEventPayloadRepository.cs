namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.AppEventPayload;

public class AppEventPayloadRepository(AppDbContext dbContext) :
  AppRepositoryBase<AppEventPayloadEntity>(dbContext),
  IAppEventPayloadRepository
{
}
