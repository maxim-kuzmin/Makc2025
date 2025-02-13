namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventGetActionFactory(AppDbSettings _appDbSettings) : IAppEventGetActionFactory
{  
  /// <inheritdoc/>
  public DbSQLCommand CreateSQL(AppEventGetActionQuery query)
  {
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    List<object> parameters = [query.Id];

    string text = $$"""
select
  "{{sAppEvent.ColumnForId}}" "Id",
  "{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  "{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
where
  "{{sAppEvent.ColumnForId}}" = {0}

""";

    return new(text, parameters);
  }
}
