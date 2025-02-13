namespace Makc2025.Dummy.Shared.Infrastructure.EntityFramework;

/// <summary>
/// Расширения.
/// </summary>
public static class Extensions
{
  /// <summary>
  /// Создать запрос из SQL с форматированием. Подробности здесь:
  /// <see cref="Helpers.IDbHelperForSQL.CreateQueryFromSqlWithFormat{T}(string, IEnumerable{object}?)"/>
  /// </summary>
  /// <typeparam name="T">Тип данных, возвращаемый запросом.</typeparam>
  /// <param name="dbContext">Контекст базы данных.</param>
  /// <param name="sqlWithFormat">SQL с форматированием.</param>
  /// <param name="parameters">Параметры.</param>
  /// <returns>Запрос.</returns>
  public static IQueryable<T> CreateQueryFromSqlWithFormat<T>(
    this DbContext dbContext,
    string sqlWithFormat,
    IEnumerable<object>? parameters = null)
  {
    if (parameters?.Any() == true)
    {
      var sql = FormattableStringFactory.Create(sqlWithFormat, [.. parameters]);

      return dbContext.Database.SqlQuery<T>(sql);
    }
    else
    {
      return dbContext.Database.SqlQueryRaw<T>(sqlWithFormat);
    }
  }

  /// <summary>
  /// Создать запрос. Подробности здесь:
  /// <see cref="IDbSQLContext.CreateQuery{T}(DbSQLCommand)"/>
  /// </summary>
  /// <typeparam name="T">Тип данных, возвращаемый запросом.</typeparam>
  /// <param name="dbContext">Контекст базы данных.</param>
  /// <param name="sqlWithFormat">SQL с форматированием.</param>
  /// <param name="parameters">Параметры.</param>
  /// <returns>Запрос.</returns>
  public static IQueryable<T> CreateQuery<T>(this DbContext dbContext, DbSQLCommand command)
  {
    if (command.Parameters?.Any() == true)
    {
      var sql = FormattableStringFactory.Create(command.Text, [.. command.Parameters]);

      return dbContext.Database.SqlQuery<T>(sql);
    }
    else
    {
      return dbContext.Database.SqlQueryRaw<T>(command.Text);
    }
  }
}
