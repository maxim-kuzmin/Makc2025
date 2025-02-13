namespace Makc2025.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Интерфейс фабрики действия по получению списка полезных нагрузок события приложения.
/// </summary>
public interface IAppEventPayloadGetListActionFactory
{
  /// <summary>
  /// Создать SQL для фильтра.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL для фильтра.</returns>
  DbSQLCommand CreateSQLForFilter(AppEventPayloadGetListActionQuery query);

  /// <summary>
  /// Создать SQL для элементов.
  /// </summary>
  /// <param name="sqlForFilter">SQL для фильтра.</param>
  /// <param name="page">Страница.</param>
  /// <returns>SQL для элементов.</returns>
  DbSQLCommand CreateSQLForItems(DbSQLCommand sqlForFilter, QueryPage? page);

  /// <summary>
  /// Создать SQL для общего количества.
  /// </summary>
  /// <param name="sqlForFilter">SQL для фильтра.</param>
  /// <returns>SQL для общего количества.</returns>
  DbSQLCommand CreateSQLForTotalCount(DbSQLCommand sqlForFilter);
}
