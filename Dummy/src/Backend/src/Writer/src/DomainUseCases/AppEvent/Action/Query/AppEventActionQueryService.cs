namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent.Action.Query;

/// <summary>
/// Сервис запросов действия с событием приложения.
/// </summary>
/// <param name="_appEventGetActionFactory">Фабрика действия по получению события приложения.</param>
/// <param name="_appEventGetListActionFactory">Фабрика действия по получению списка событий приложения.</param>
/// <param name="_appDbSQLContext">SQL-контекст базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public class AppEventActionQueryService(
  IAppDbSQLContext _appDbSQLContext,
  IAppEventGetActionFactory _appEventGetActionFactory,
  IAppEventGetListActionFactory _appEventGetListActionFactory,
  AppSession _appSession) : IAppEventActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Get(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sql = _appEventGetActionFactory.CreateSQL(query);

    var task = _appDbSQLContext.GetFirstOrDefaultAsync<AppEventSingleDTO>(sql, cancellationToken);

    var dto = await task.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventListDTO>> GetList(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var sqlForFilter = _appEventGetListActionFactory.CreateSQLForFilter(query);

    var sqlForTotalCount = _appEventGetListActionFactory.CreateSQLForTotalCount(sqlForFilter);

    var taskForTotalCount = _appDbSQLContext.GetListAsync<long>(sqlForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<AppEventSingleDTO> items;

    if (totalCount > 0)
    {
      var sqlForItems = _appEventGetListActionFactory.CreateSQLForItems(sqlForFilter, query.Page);

      var taskForItems = _appDbSQLContext.GetListAsync<AppEventSingleDTO>(sqlForItems, cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
