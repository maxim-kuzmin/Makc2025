﻿using System.Globalization;

namespace Makc2025.Dummy.Writer.Apps.OutboxCleanerApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Построить приложение.
  /// </summary>
  /// <param name="appBuilder">Построитель приложения.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static IHost BuildApp(this HostApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger)
      .AddAppInfrastructureTiedToCore(logger, appBuilder.Configuration)
      .AddAppInfrastructureTiedToEntityFramework(logger, appConfigOptions.PostgreSQL, appBuilder.Configuration);

    services.AddHostedService<AppService>();

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
