namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemGetActionFactory(AppDbSettings _appDbSettings) : IDummyItemGetActionFactory
{  
  /// <inheritdoc/>
  public DbSQLCommand CreateSQL(DummyItemGetActionQuery query)
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    List<object> parameters = [query.Id];

    string text = $$"""
select
  "{{sDummyItem.ColumnForId}}" "Id",
  "{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = {0}

""";

    return new(text, parameters);
  }
}
