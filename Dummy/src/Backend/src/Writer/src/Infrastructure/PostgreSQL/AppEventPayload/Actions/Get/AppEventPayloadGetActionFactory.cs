namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Actions.Get;

/// <summary>
/// Фабрика действия по получению фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventPayloadGetActionFactory(AppDbSettings _appDbSettings) : IAppEventPayloadGetActionFactory
{  
  /// <inheritdoc/>
  public DbSQLCommand CreateSQL(AppEventPayloadGetActionQuery query)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    List<object> parameters = [query.Id];

    string text = $$"""
select
  "{{sAppEventPayload.ColumnForId}}" "Id",
  "{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  "{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
where
  "{{sAppEventPayload.ColumnForId}}" = {0}

""";

    return new(text, parameters);
  }
}
