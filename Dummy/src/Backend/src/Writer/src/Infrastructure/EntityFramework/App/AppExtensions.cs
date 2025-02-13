﻿namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Entity Framework.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFramework(
    this IServiceCollection services,
    ILogger logger,
    AppDbSettings appDbSettings)
  {
    AppDbContext.Init(appDbSettings);

    services.AddScoped<IAppDbExecutor, AppDbExecutor>();
    services.AddScoped<IAppDbHelperForSQL, AppDbContext>();
    services.AddScoped<IAppDbSQLContext, AppDbContext>();

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<IAppEventRepository, AppEventRepository>();
    services.AddScoped<IAppEventPayloadRepository, AppEventPayloadRepository>();
    services.AddScoped<IDummyItemRepository, DummyItemRepository>();

    services.AddTransient<IAppEventActionQueryService, AppEventActionQueryService>();
    services.AddTransient<IAppEventPayloadActionQueryService, AppEventPayloadActionQueryService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();

    logger.LogInformation("Added application infrastructure tied to Entity Framework");

    return services;
  }

  /// <summary>
  /// Использовать инфраструктуру приложения, привязанную к Entity Framework.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Задача.</returns>
  public static async Task UseAppInfrastructureTiedToEntityFramework(this IHost app, ILogger logger)
  {
    using var scope = app.Services.CreateScope();

    var scopedServices = scope.ServiceProvider;

    try
    {
      var appDbContext = scopedServices.GetRequiredService<AppDbContext>();

      //await appDbContext.Database.MigrateAsync().ConfigureAwait(false);
      //await appDbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);

      await AppData.InitializeAsync(appDbContext).ConfigureAwait(false);

      logger.LogInformation("Used application infrastructure tied to Entity Framework");
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
  }
}
