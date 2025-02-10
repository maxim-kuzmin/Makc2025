﻿namespace Makc2025.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query;

/// <summary>
/// Интерфейс сервиса запросов действия с полезной нагрузкой события приложения.
/// </summary>
public interface IAppEventPayloadActionQueryService
{
  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadSingleDTO>> Get(AppEventPayloadGetActionQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadListDTO>> GetList(
    AppEventPayloadGetListActionQuery query,
    CancellationToken cancellationToken);
}
