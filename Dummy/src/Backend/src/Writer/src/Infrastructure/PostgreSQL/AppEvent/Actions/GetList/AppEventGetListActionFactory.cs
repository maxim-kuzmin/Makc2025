namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventGetListActionFactory(AppDbSettings _appDbSettings) : IAppEventGetListActionFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForFilter(AppEventGetListActionQuery query)
  {
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    List<object>? parameters = null;

    var parameterIndex = 0;

    string text;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      parameters = [];

      text = $$"""
where
  ae."{{sAppEvent.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  ae."{{sAppEvent.ColumnForName}}" ilike {{{parameterIndex}}}

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
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    var parameters = sqlForFilter.Parameters ?? [];

    int parameterIndex = parameters.Count;

    string text = $$"""
select
  ae."{{sAppEvent.ColumnForId}}" "Id",
  ae."{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  ae."{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae
{{sqlForFilter.Text}}
order by
  ae."{{sAppEvent.ColumnForId}}" desc
    
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
    var sAppEvent = _appDbSettings.Entities.AppEvent;

    string text = $$"""    
select
  count(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae
{{sqlForFilter.Text}}

""";

    return new(text, sqlForFilter.Parameters);
  }
}
