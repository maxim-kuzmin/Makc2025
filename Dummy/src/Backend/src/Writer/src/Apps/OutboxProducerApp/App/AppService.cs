﻿namespace Makc2025.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(ILogger<AppService> _logger, IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var appConfigOptionsPostgreSQLSection = Guard.Against.Null(appConfigOptionsSnapshot.Value.PostgreSQL);

      _logger.LogInformation("PostgreSQL: {appConfigOptionsPostgreSQLSection}", appConfigOptionsPostgreSQLSection);

      var appConfigOptionsRabbitMQSection = Guard.Against.Null(appConfigOptionsSnapshot.Value.RabbitMQ);

      _logger.LogInformation("RabbitMQ: {appConfigOptionsRabbitMQSection}", appConfigOptionsRabbitMQSection);

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }

      await Task.Delay(10000, stoppingToken);
    }
  }
}
