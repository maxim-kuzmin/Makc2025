var logger = AppLogger.Create<Program>();

try
{
  logger.LogInformation("Starting application");

  AppEnvironment.LoadVariables();

  var appBuilder = Host.CreateApplicationBuilder(args);

  appBuilder.AddAppUI(logger);

  var app = appBuilder.Build();

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
