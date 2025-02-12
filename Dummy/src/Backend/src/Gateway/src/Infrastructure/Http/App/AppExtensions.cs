namespace Makc2025.Dummy.Gateway.Infrastructure.Http.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Http.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="writerApiAddress">Адрес API писателя.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttp(
      this IServiceCollection services,
      ILogger logger,
      string writerApiAddress)
  {
    services.AddTransient<IAppActionCommandService, AppActionCommandService>();
    services.AddTransient<IDummyItemActionCommandService, DummyItemActionCommandService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AppSettings.WriterDummyItemClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(writerApiAddress);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application infrastructure tied to Http");

    return services;
  }
}
