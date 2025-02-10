namespace Makc2025.Dummy.Gateway.DomainUseCases.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования домена приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCases(this IServiceCollection services, ILogger logger)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    logger.LogInformation("Added domain use cases");

    return services;
  }
}
