﻿var logger = AppLogger.Create<Program>();

try
{
  logger.LogInformation("Starting application");

  AppEnvironment.LoadVariables();

  var builder = WebApplication.CreateBuilder(args);

  var appConfigSection = builder.Configuration.GetSection(AppConfigOptions.SectionKey);

  var appConfigOptions = appConfigSection.CreateAppConfigOptions();

  builder.Services    
    .AddAppDomainUseCasesLayer(logger)
    .AddAppInfrastructureLayer(logger, appConfigOptions, builder.Configuration, appConfigSection)
    .AddAppUILayer(logger, appConfigOptions);

  var app = builder.Build();

  app.UseAppUILayer(logger);

  app.Run();
}
catch (Exception ex)
{
  logger.LogCritical(ex, "Application terminated unexpectedly");
}
finally
{
  AppLogger.CloseAndFlush();
}

public partial class Program { }
