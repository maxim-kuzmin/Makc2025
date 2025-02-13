namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.DummyItem.Action.Query;

/// <summary>
/// Сервис запросов действия с фиктивным предметом.
/// </summary>
/// <param name="_dummyItemGetActionFactory">Фабрика действия по получению фиктивного предмета.</param>
/// <param name="_dummyItemGetListActionFactory">Фабрика действия по получению списка фиктивных предметов.</param>
/// <param name="_appDbSQLContext">SQL-контекст базы данных приложения.</param>
/// <param name="appSession">Сессия приложения.</param>
public class DummyItemActionQueryService(
  IAppDbSQLContext _appDbSQLContext,
  IDummyItemGetActionFactory _dummyItemGetActionFactory,
  IDummyItemGetListActionFactory _dummyItemGetListActionFactory,
  AppSession appSession) : DummyItemActionQueryServiceBase(appSession)
{
  /// <inheritdoc/>
  protected sealed override async Task<DummyItemSingleDTO?> GetDTO(
    DummyItemGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sql = _dummyItemGetActionFactory.CreateSQL(query);

    var task = _appDbSQLContext.GetFirstOrDefaultAsync<DummyItemSingleDTO>(sql, cancellationToken);

    var result = await task.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  protected sealed override async Task<DummyItemListDTO> GetDTO(
    DummyItemGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var sqlForFilter = _dummyItemGetListActionFactory.CreateSQLForFilter(query);

    var sqlForTotalCount = _dummyItemGetListActionFactory.CreateSQLForTotalCount(sqlForFilter);

    var taskForTotalCount = _appDbSQLContext.GetListAsync<long>(sqlForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<DummyItemSingleDTO> items;

    if (totalCount > 0)
    {
      var sqlForItems = _dummyItemGetListActionFactory.CreateSQLForItems(sqlForFilter, query.Page);

      var taskForItems = _appDbSQLContext.GetListAsync<DummyItemSingleDTO>(sqlForItems, cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    return new(items, totalCount);
  }
}
