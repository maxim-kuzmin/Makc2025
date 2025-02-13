namespace Makc2025.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query;

/// <summary>
/// Сервис запросов действия с полезной нагрузкой события приложения.
/// </summary>
/// <param name="_appEventPayloadGetActionFactory">
/// Фабрика действия по получению полезной нагрузки события приложения.</param>
/// <param name="_appEventPayloadGetListActionFactory">
/// Фабрика действия по получению списка полезных нагрузок события приложения.</param>
/// <param name="_appDbSQLContext">SQL-контекст базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public class AppEventPayloadActionQueryService(
  IAppDbSQLContext _appDbSQLContext,
  IAppEventPayloadGetActionFactory _appEventPayloadGetActionFactory,
  IAppEventPayloadGetListActionFactory _appEventPayloadGetListActionFactory,
  AppSession _appSession) : IAppEventPayloadActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Get(
    AppEventPayloadGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var sql = _appEventPayloadGetActionFactory.CreateSQL(query);

    var task = _appDbSQLContext.GetFirstOrDefaultAsync<AppEventPayloadSingleDTO>(sql, cancellationToken);

    var dto = await task.ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadListDTO>> GetList(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var sqlForFilter = _appEventPayloadGetListActionFactory.CreateSQLForFilter(query);

    var sqlForTotalCount = _appEventPayloadGetListActionFactory.CreateSQLForTotalCount(sqlForFilter);

    var taskForTotalCount = _appDbSQLContext.GetListAsync<long>(sqlForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<AppEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      var sqlForItems = _appEventPayloadGetListActionFactory.CreateSQLForItems(sqlForFilter, query.Page);

      var taskForItems = _appDbSQLContext.GetListAsync<AppEventPayloadSingleDTO>(sqlForItems, cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventPayloadListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
