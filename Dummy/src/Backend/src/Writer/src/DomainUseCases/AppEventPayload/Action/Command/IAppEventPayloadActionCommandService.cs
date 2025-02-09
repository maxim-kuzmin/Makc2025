﻿namespace Makc2025.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Command;

/// <summary>
/// Интерфейс сервиса команд действия с полезной нагрузкой события приложения.
/// </summary>
public interface IAppEventPayloadActionCommandService
{
  /// <summary>
  /// Создать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadSingleDTO>> Create(
    AppEventPayloadCreateActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> Delete(
    AppEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppEventPayloadSingleDTO>> Update(
    AppEventPayloadUpdateActionCommand command,
    CancellationToken cancellationToken);
}
