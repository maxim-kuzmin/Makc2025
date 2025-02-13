namespace Makc2025.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Интерфейс фабрики действия по получению списка фиктивных предметов.
/// </summary>
public interface IDummyItemGetListActionFactory
{
  /// <summary>
  /// Создать SQL для фильтра.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL для фильтра.</returns>
  DbSQLCommand CreateSQLForFilter(DummyItemGetListActionQuery query);

  /// <summary>
  /// Создать SQL для общего количества.
  /// </summary>
  /// <param name="sqlForFilter">SQL для фильтра.</param>
  /// <returns>SQL для общего количества.</returns>
  DbSQLCommand CreateSQLForTotalCount(DbSQLCommand sqlForFilter);

  /// <summary>
  /// Создать SQL для элементов.
  /// </summary>
  /// <param name="sqlForFilter">SQL для фильтра.</param>
  /// <param name="page">Страница.</param>
  /// <returns>SQL для элементов.</returns>
  DbSQLCommand CreateSQLForItems(DbSQLCommand sqlForFilter, QueryPage? page);
}
