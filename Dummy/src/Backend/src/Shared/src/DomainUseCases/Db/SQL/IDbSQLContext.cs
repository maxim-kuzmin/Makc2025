namespace Makc2025.Dummy.Shared.DomainUseCases.Db.SQL;

/// <summary>
/// Интерфейс SQL-контекста базы данных.
/// </summary>
public interface IDbSQLContext
{
  /// <summary>
  /// Получить первый элемент или значение по умолчанию асинхронно.
  /// </summary>
  /// <typeparam name="T">Тип возвращаемого элемента.</typeparam>
  /// <param name="sql">SQL.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Первое или по умолчанию.</returns>
  Task<T?> GetFirstOrDefaultAsync<T>(DbSQLCommand sql, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список асинхронно.
  /// </summary>
  /// <typeparam name="T">Тип элемента возвращаемого списка.</typeparam>
  /// <param name="sql">SQL.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список.</returns>
  Task<List<T>> GetListAsync<T>(DbSQLCommand sql, CancellationToken cancellationToken);
}
