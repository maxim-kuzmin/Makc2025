﻿namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent.Action.Query.Service;

/// <summary>
/// Основа сервиса запросов действия с событием приложения.
/// </summary>
/// <param name="_appDbHelperForSQL">Помощник базы данных приложения для SQL.</param>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
public abstract class AppEventActionQueryServiceBase(AppSession _appSession) : IAppEventActionQueryService
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Get(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken)
  {
    var dto = await GetDTO(query, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }

  /// <inheritdoc/>
  public async Task<Result<AppEventListDTO>> GetList(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    var dto = await GetDTO(query, cancellationToken);

    return Result.Success(dto);
  }

  /// <summary>
  /// Получить объект передачи данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  protected abstract Task<AppEventSingleDTO?> GetDTO(
    AppEventGetActionQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить объект передачи данных.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  protected abstract Task<AppEventListDTO> GetDTO(
    AppEventGetListActionQuery query,
    CancellationToken cancellationToken);
}
