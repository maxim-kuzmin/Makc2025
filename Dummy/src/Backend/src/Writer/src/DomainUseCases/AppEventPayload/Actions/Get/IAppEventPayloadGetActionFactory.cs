namespace Makc2025.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению полезной нагрузки события приложения.
/// </summary>
public interface IAppEventPayloadGetActionFactory
{
  /// <summary>
  /// Создать SQL.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL.</returns>
  DbSQLCommand CreateSQL(AppEventPayloadGetActionQuery query);
}
