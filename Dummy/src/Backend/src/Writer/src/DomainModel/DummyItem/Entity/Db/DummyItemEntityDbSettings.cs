﻿namespace Makc2025.Dummy.Writer.DomainModel.DummyItem.Entity.Db;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public abstract record DummyItemEntityDbSettings : DummyItemEntitySettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = string.Empty;

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; protected set; } = string.Empty;

  /// <summary>
  /// Схема.
  /// </summary>
  public string Schema { get; protected set; } = string.Empty;

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; protected set; } = string.Empty;
  
  /// <summary>
  /// Уникальный индекс для имени.
  /// </summary>
  public string UniqueIndexForName { get; protected set; } = string.Empty;
}
