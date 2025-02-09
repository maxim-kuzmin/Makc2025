﻿namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.App.Repository;

/// <summary>
/// Основа репозитория приложения.
/// </summary>
/// <typeparam name="TAggregateRoot">Тип корня агрегата.</typeparam>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class AppRepositoryBase<TAggregateRoot>(AppDbContext addDbContext) :
  RepositoryBase<TAggregateRoot>(addDbContext),
  IReadRepository<TAggregateRoot>,
  IRepository<TAggregateRoot>
  where TAggregateRoot : class, IAggregateRoot
{
}
