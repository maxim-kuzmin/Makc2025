namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к базе данных PostgreSQL.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToPostgreSQL(
    this IServiceCollection services,
    ILogger logger,
    out AppDbSettingsBase appDbSettings)
  {
    appDbSettings = new Db.AppDbSettings();

    services.AddSingleton(appDbSettings);

    services.AddSingleton(appDbSettings.Entities.AppEvent);
    services.AddSingleton(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton(appDbSettings.Entities.DummyItem);

    services.AddSingleton<AppEventEntitySettings>(appDbSettings.Entities.AppEvent);
    services.AddSingleton<AppEventPayloadEntitySettings>(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton<DummyItemEntitySettings>(appDbSettings.Entities.DummyItem);

    logger.LogInformation("Added application infrastructure tied to PostgreSQL");

    return services;
  }
}
