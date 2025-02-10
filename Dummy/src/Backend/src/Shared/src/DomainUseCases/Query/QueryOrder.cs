﻿namespace Makc2025.Dummy.Shared.DomainUseCases.Query;

/// <summary>
/// Порядок сортировки в запросе.
/// </summary>
/// <param name="Field">Поле.</param>
/// <param name="IsDesc">По убыванию?</param>
public record QueryOrder(string Field, bool IsDesc);
