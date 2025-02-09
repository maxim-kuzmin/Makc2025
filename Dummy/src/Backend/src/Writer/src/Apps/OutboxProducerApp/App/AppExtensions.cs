namespace Makc2025.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить пользовательский интерфейс приложения.
  /// </summary>
  /// <param name="appBuilder">Построитель приложения.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppUI(this HostApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigSectionRabbitMQ = appConfigSection.GetSection("RabbitMQ");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger)
      .AddAppInfrastructureTiedToRabbitMQ(logger, appConfigSectionRabbitMQ)
      .AddAppInfrastructureTiedToEntityFramework(
        logger,
        appConfigOptions.PostgreSQL,
        appBuilder.Configuration)
      .AddAppInfrastructureTiedToCore(logger, appBuilder.Configuration);

    services.AddHostedService<AppService>();

    logger.LogInformation("Added app UI");

    return services;
  }
}
