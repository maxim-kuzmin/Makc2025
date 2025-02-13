namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemGetListActionFactory(AppDbSettings _appDbSettings) : IDummyItemGetListActionFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForFilter(DummyItemGetListActionQuery query)
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    List<object>? parameters = null;

    var parameterIndex = 0;

    string text;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      parameters = [];

      text = $$"""
where
  di."{{sDummyItem.ColumnForId}}"::text ilike {{{parameterIndex}}}
  or
  di."{{sDummyItem.ColumnForName}}" ilike {{{parameterIndex}}}

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
  public DbSQLCommand CreateSQLForTotalCount(DbSQLCommand sqlForFilter)
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    string text = $$"""    
select
  count(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
{{sqlForFilter.Text}}

""";

    return new(text, sqlForFilter.Parameters);
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateSQLForItems(DbSQLCommand sqlForFilter, QueryPage? page)
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    var parameters = sqlForFilter.Parameters ?? [];

    int parameterIndex = parameters.Count;

    string text = $$"""
select
  di."{{sDummyItem.ColumnForId}}" "Id",
  di."{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
{{sqlForFilter.Text}}
order by
  di."{{sDummyItem.ColumnForId}}" desc

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
}
