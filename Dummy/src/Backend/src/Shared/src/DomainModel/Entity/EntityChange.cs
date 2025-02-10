﻿namespace Makc2025.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Изменение сущности.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <param name="Inserted">Вставленное.</param>
/// <param name="Deleted">Удалённое.</param>
public record EntityChange<TEntity>(TEntity? Inserted, TEntity? Deleted);
