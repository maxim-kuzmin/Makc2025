namespace Makc2025.Dummy.Writer.Apps.WebApp.App;

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
  public static WebApplication BuildApp(this WebApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigSectionAuthentication = appConfigSection.GetSection("Authentication");

    var appConfigSectionRabbitMQ = appConfigSection.GetSection("RabbitMQ");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger)
      .AddAppInfrastructureTiedToCore(logger, appBuilder.Configuration)
      .AddAppInfrastructureTiedToEntityFramework(logger, appConfigOptions.PostgreSQL, appBuilder.Configuration)
      .AddAppInfrastructureTiedToAuthentication(logger, appConfigSectionAuthentication)
      .AddAppInfrastructureTiedToGrpc(logger)
      .AddAppInfrastructureTiedToRabbitMQ(logger, appConfigSectionRabbitMQ);

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddFastEndpoints();

    var authentication = Guard.Against.Null(appConfigOptions.Authentication);

    services
      .AddAuthorization()
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        byte[] keyBytes = Encoding.UTF8.GetBytes(authentication.Key);

        var issuerSigningKey = authentication.GetSymmetricSecurityKey();

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = authentication.Issuer,
          ValidateAudience = true,
          ValidAudience = authentication.Audience,
          ValidateLifetime = true,
          IssuerSigningKey = issuerSigningKey,
          ValidateIssuerSigningKey = true
        };
      });

    services.SwaggerDocument(options =>
    {
      options.ShortSchemaNames = true;
      options.EnableJWTBearerAuth = true;
    });

    logger.LogInformation("App is ready to build");

    return appBuilder.Build();
  }

  /// <summary>
  /// Использовать приложение.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static async Task<WebApplication> UseApp(this WebApplication app, ILogger logger)
  {
    if (app.Environment.IsDevelopment())
    {
      IdentityModelEventSource.ShowPII = true;

      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseDefaultExceptionHandler(); // from FastEndpoints

      app.UseHsts();
    }

    List<CultureInfo> supportedCultures = [new("ru"), new("en")];

    var requestLocalizationOptions = new RequestLocalizationOptions
    {
      DefaultRequestCulture = new("ru"),
      SupportedCultures = supportedCultures,
      SupportedUICultures = supportedCultures
    };

    app.UseRequestLocalization(requestLocalizationOptions);

    //app.UseHttpsRedirection(); // //makc//Не нужно для внутреннего сервиса//

    app.UseAuthentication()
      .UseAuthorization()
      .UseMiddleware<AppTracingMiddleware>()
      .UseMiddleware<AppSessionMiddleware>();

    app.UseAppInfrastructureTiedToGrpc(logger);

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware

    await app.UseAppInfrastructureTiedToEntityFramework(logger);

    logger.LogInformation("App is ready to run");

    return app;
  }
}
