﻿namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem.Entity.Db;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета для PostgreSQL.
/// </summary>
public record DummyItemEntityDbSettings : DummyItemEntityDbSettingsBase
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public DummyItemEntityDbSettings(string schema)
  {
    Schema = schema;

    Table = "dummy_item";

    PrimaryKey = $"pk_{Table}";

    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForId = "id";
    ColumnForName = "name";

    MaxLengthForName = 255;

    UniqueIndexForName = $"ux_{Table}_name";
  }
}
