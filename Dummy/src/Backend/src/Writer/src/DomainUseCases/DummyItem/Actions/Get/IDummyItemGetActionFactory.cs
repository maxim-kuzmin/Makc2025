namespace Makc2025.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению фиктивного предмета.
/// </summary>
public interface IDummyItemGetActionFactory
{
  /// <summary>
  /// Создать SQL.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL.</returns>
  DbSQLCommand CreateSQL(DummyItemGetActionQuery query);
}
