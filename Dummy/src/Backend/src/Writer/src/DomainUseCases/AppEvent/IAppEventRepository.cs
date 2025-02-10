namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Интерфейс репозитория события приложения.
/// </summary>
public interface IAppEventRepository : IReadRepository<AppEventEntity>,
  IRepository<AppEventEntity>
{
}
