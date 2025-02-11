namespace Makc2025.Dummy.Writer.Apps.OutboxCleanerApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// База данных PostgreSQL.
  /// </summary>
  public AppConfigOptionsPostgreSQLSection? PostgreSQL { get; set; }
}
