﻿namespace Makc2025.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Сущность фиктивного предмета.
/// </summary>
public class DummyItemEntity : EntityBaseWithIdProperty<long>, IAggregateRoot
{
  /// <summary>
  /// Токен конкуренции.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = null!;
}
