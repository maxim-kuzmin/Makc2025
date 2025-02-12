﻿namespace Makc2025.Dummy.Writer.Infrastructure.Core.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к ядру.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToCore(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    IConfiguration configuration)
  {
    services.AddSerilog(config => config.ReadFrom.Configuration(configuration));

    services.AddJsonLocalization();

    services.AddScoped<AppSession>();

    services.AddTransient<IAppEventResources, AppEventResources>();
    services.AddTransient<IAppEventPayloadResources, AppEventPayloadResources>();
    services.AddTransient<IDummyItemResources, DummyItemResources>();

    logger.LogInformation("Added application infrastructure tied to Core");

    return services;
  }
}
