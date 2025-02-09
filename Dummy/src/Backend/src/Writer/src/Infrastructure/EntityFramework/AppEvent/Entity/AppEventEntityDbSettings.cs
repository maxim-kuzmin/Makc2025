﻿namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.AppEvent.Entity;

/// <summary>
/// Настройки базы данных сущности события приложения.
/// </summary>
public abstract class AppEventEntityDbSettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = null!;

  /// <summary>
  /// Столбец для даты создания.
  /// </summary>
  public string ColumnForCreatedAt { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = null!;

  /// <summary>
  /// Столбец для признака опубликованности.
  /// </summary>
  public string ColumnForIsPublished { get; protected set; } = null!;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = null!;

  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; protected set; } = null!;

  /// <summary>
  /// Схема.
  /// </summary>
  public string Schema { get; protected set; } = null!;

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; protected set; } = null!;

  /// <summary>
  /// Преобразовать к настройкам сущности.
  /// </summary>
  /// <returns>Настройки сущности.</returns>
  public AppEventEntitySettings ToEntitySettings()
  {
    return new(MaxLengthForName);
  }
}
