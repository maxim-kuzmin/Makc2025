﻿namespace Makc2025.Dummy.Gateway.Apps.WebApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить уровень пользовательского интерфейса приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppUILayer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptions appConfigOptions)
  {
    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddFastEndpoints()
      .AddAuthorization()
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        byte[] keyBytes = Encoding.UTF8.GetBytes(appConfigOptions.Authentication.Key);

        var issuerSigningKey = appConfigOptions.Authentication.GetSymmetricSecurityKey();

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = appConfigOptions.Authentication.Issuer,
          ValidateAudience = true,
          ValidAudience = appConfigOptions.Authentication.Audience,
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

    logger.LogInformation("UI layer added");

    return services;
  }

  /// <summary>
  /// Использовать уровень пользовательского интерфейса приложения.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static WebApplication UseAppUILayer(this WebApplication app, ILogger logger)
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

    app.UseHttpsRedirection();

    app.UseAuthentication()
      .UseAuthorization()
      .UseMiddleware<AppTracingMiddleware>()
      .UseMiddleware<AppSessionMiddleware>();

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware    

    logger.LogInformation("UI layer used");

    return app;
  }

  private static SymmetricSecurityKey GetSymmetricSecurityKey(
    this AppConfigOptionsAuthentication options)
  {
    byte[] keyBytes = Encoding.UTF8.GetBytes(options.Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}
