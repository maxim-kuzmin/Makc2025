﻿namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public abstract class AppDbSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbSettingsEntities Entities { get; protected set; } = null!;

  /// <summary>
  /// Схема.
  /// </summary>
  protected string Schema { get; set; } = null!;
}
