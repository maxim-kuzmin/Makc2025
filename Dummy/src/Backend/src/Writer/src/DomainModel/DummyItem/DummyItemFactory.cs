﻿namespace Makc2025.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Фабрика фиктивного предмета.
/// </summary>
/// <param name="_resources">Ресурсы.</param>
/// <param name="_settings">Настройки.</param>
public class DummyItemFactory(IDummyItemResources _resources, DummyItemEntitySettings _settings) : IDummyItemFactory
{
  /// <inheritdoc/>
  public DummyItemAggregate CreateAggregate(DummyItemEntity? entityToChange = null)
  {
    return new(entityToChange, _resources, _settings);
  }
}
