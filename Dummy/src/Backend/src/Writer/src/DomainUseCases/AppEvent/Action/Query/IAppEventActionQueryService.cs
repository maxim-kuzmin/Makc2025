﻿namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent.Action.Query;

/// <summary>
/// Интерфейс сервиса запросов действия с событием приложения.
/// </summary>
public interface IAppEventActionQueryService
{
  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventSingleDTO>> Get(AppEventGetActionQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventListDTO>> GetList(AppEventGetListActionQuery query, CancellationToken cancellationToken);
}
