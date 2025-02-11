namespace Makc2025.Dummy.Writer.Infrastructure.Authentication.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к аутентификации.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigSectionAuthentication">Раздел аутентификации в конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToAuthentication(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection appConfigSectionAuthentication)
  {
    services.Configure<AppConfigOptionsAuthenticationSection>(appConfigSectionAuthentication);

    services.AddTransient<IAppActionCommandService, AppActionCommandService>();

    logger.LogInformation("Added app infrastructure tied to authentication");

    return services;
  }
}
