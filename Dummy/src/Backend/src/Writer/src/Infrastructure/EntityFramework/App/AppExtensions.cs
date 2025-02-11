namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Entity Framework.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsPostgreSQL">Секция PostgreSQL в параметрах конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFramework(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsPostgreSQLSection? appConfigOptionsPostgreSQL,
    IConfiguration configuration)
  {
    if (appConfigOptionsPostgreSQL != null)
    {
      var connectionStringTemplate = configuration.GetConnectionString(
        appConfigOptionsPostgreSQL.ConnectionStringName);

      Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

      var connectionString = appConfigOptionsPostgreSQL.ToConnectionString(connectionStringTemplate);

      AppDbContext.Init(new AppDbSettingsForPostgreSQL());

      services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }

    var appDbSettings = AppDbContext.GetAppDbSettings();

    services.AddSingleton(appDbSettings);

    services.AddSingleton(appDbSettings.Entities.AppEvent);
    services.AddSingleton(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton(appDbSettings.Entities.DummyItem);

    services.AddSingleton(appDbSettings.Entities.AppEvent.ToEntitySettings());
    services.AddSingleton(appDbSettings.Entities.AppEventPayload.ToEntitySettings());
    services.AddSingleton(appDbSettings.Entities.DummyItem.ToEntitySettings());

    services.AddScoped<IAppDbExecutor, AppDbExecutor>();
    services.AddScoped<IAppDbHelperForSQL, AppDbContext>();

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<IAppEventRepository, AppEventRepository>();
    services.AddScoped<IAppEventPayloadRepository, AppEventPayloadRepository>();
    services.AddScoped<IDummyItemRepository, DummyItemRepository>();

    services.AddTransient<IAppEventActionQueryService, AppEventActionQueryService>();
    services.AddTransient<IAppEventPayloadActionQueryService, AppEventPayloadActionQueryService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();

    logger.LogInformation("Added app infrastructure tied to Entity Framework");

    return services;
  }

  /// <summary>
  /// Использовать инфраструктуру приложения, привязанную к Entity Framework.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Задача.</returns>
  public static async Task UseAppInfrastructureTiedToEntityFramework(
    this IHost app,
    ILogger logger)
  {
    using var scope = app.Services.CreateScope();

    var scopedServices = scope.ServiceProvider;

    try
    {
      var context = scopedServices.GetRequiredService<AppDbContext>();

      //await context.Database.MigrateAsync().ConfigureAwait(false);
      await context.Database.EnsureCreatedAsync().ConfigureAwait(false);

      await AppData.InitializeAsync(context).ConfigureAwait(false);

      logger.LogInformation("Used app infrastructure tied to Entity Framework");
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
  }
}
