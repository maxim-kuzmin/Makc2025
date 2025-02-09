namespace Makc2025.Dummy.Writer.DomainUseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IReadRepository<DummyItemEntity>,
  IRepository<DummyItemEntity>
{
}
