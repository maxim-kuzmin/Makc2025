namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.DummyItem.Entity;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public abstract class DummyItemEntityDbSettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = null!;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = null!;

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
  /// Уникальный индекс для имени.
  /// </summary>
  public string UniqueIndexForName { get; protected set; } = null!;

  /// <summary>
  /// Преобразовать к настройкам сущности.
  /// </summary>
  /// <returns>Настройки сущности.</returns>
  public DummyItemEntitySettings ToEntitySettings()
  {
    return new(MaxLengthForName);
  }
}
