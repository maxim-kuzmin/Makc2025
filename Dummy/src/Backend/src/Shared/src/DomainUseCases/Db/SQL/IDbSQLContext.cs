namespace Makc2025.Dummy.Shared.DomainUseCases.Db.SQL;

/// <summary>
/// Интерфейс SQL-контекста базы данных.
/// </summary>
public interface IDbSQLContext
{
  /// <summary>
  /// Создать запрос.
  /// </summary>
  /// <typeparam name="T">Тип данных, возвращаемый запросом.</typeparam>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос.</returns>
  IQueryable<T> CreateQuery<T>(DbSQLCommand command);
}
