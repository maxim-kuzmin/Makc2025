﻿namespace Makc2025.Dummy.Writer.Infrastructure.RabbitMQ.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к RabbitMQ.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigSectionRabbitMQ">Раздел RabbitMQ в конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToRabbitMQ(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection appConfigSectionRabbitMQ)
  {
    services.Configure<AppConfigOptionsRabbitMQSection>(appConfigSectionRabbitMQ);

    logger.LogInformation("Added application infrastructure tied to RabbitMQ");

    return services;
  }
}
