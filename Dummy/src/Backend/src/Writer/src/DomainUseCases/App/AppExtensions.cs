namespace Makc2025.Dummy.Writer.DomainUseCases.App;

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

    services.AddTransient<IAppActionCommandService, AppActionCommandService>();
    services.AddTransient<IAppEventActionCommandService, AppEventActionCommandService>();
    services.AddTransient<IAppEventPayloadActionCommandService, AppEventPayloadActionCommandService>();
    services.AddTransient<IAppOutboxActionCommandService, AppOutboxActionCommandService>();
    services.AddTransient<IDummyItemActionCommandService, DummyItemActionCommandService>();

    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();

    logger.LogInformation("Added application domain use cases");

    return services;
  }
}
