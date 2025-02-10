﻿namespace Makc2025.Dummy.Shared.DomainUseCases.Db;

/// <summary>
/// Интерфейс исполнителя базы данных.
/// </summary>
public interface IDbExecutor
{
  /// <summary>
  /// Выполнить.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);

  /// <summary>
  /// Выполнить в транзакции.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);

  /// <summary>
  /// С уровнем изоляции.
  /// </summary>
  /// <param name="isolationLevel">Уровень изоляции.</param>
  /// <returns>Исполнитель базы данных.</returns>
  IDbExecutor WithIsolationLevel(IsolationLevel isolationLevel);

  /// <summary>
  /// С сохранением изменений.
  /// </summary>
  /// <returns>Исполнитель базы данных.</returns>
  IDbExecutor WithSaveChanges();
}
