namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventPayloadGetListActionFactory(AppDbSettings _appDbSettings) : IAppEventPayloadGetListActionFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForFilter(AppEventPayloadGetListActionQuery query)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    List<object>? parameters = null;

    var parameterIndex = 0;

    string text;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      parameters = [];

      text = $$"""
where
  aep."{{sAppEventPayload.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  aep."{{sAppEventPayload.ColumnForData}}" ilike {{{parameterIndex}}}

""";

      parameters.Add($"%{query.Filter.FullTextSearchQuery}%");
    }
    else
    {
      text = string.Empty;
    }

    return new(text, parameters);
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForItems(DbSQLCommand sqlForFilter, QueryPage? page)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    var parameters = sqlForFilter.Parameters ?? [];

    int parameterIndex = parameters.Count;

    string text = $$"""
select
  aep."{{sAppEventPayload.ColumnForId}}" "Id",
  aep."{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  aep."{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep
{{sqlForFilter}}
order by
  aep."{{sAppEventPayload.ColumnForId}}" desc
    
""";

    if (page != null)
    {
      if (page.Size > 0)
      {
        text += $$"""        
limit {{{parameterIndex++}}}
        
""";

        parameters.Add(page.Size);
      }

      if (page.Number > 0)
      {
        text += $$"""        
offset {{{parameterIndex++}}}
                
""";

        parameters.Add((page.Number - 1) * page.Size);
      }
    }

    return new(text, parameters);
  }


  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForTotalCount(DbSQLCommand sqlForFilter)
  {
    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    string text = $$"""    
select
  count(*)
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep
{{sqlForFilter}}

""";

    return new(text, sqlForFilter.Parameters);
  }
}
