namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Интерфейс фабрики действия по получению события приложения.
/// </summary>
public interface IAppEventGetActionFactory
{
  /// <summary>
  /// Создать SQL.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>SQL.</returns>
  DbSQLCommand CreateSQL(AppEventGetActionQuery query);
}
