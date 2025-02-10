﻿namespace Makc2025.Dummy.Reader.Apps.InboxCleanerApp.App;

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

      var appConfigOptions = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var postgreSQL = Guard.Against.Null(appConfigOptions.Value.PostgreSQL);

      _logger.LogInformation("PostgreSQL: {postgreSQL}", postgreSQL);

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }

      await Task.Delay(10000, stoppingToken);
    }
  }
}
