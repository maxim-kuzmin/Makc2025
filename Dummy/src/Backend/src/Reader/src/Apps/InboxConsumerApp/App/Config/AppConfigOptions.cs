namespace Makc2025.Dummy.Reader.Apps.InboxConsumerApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public class AppConfigOptions
{
  /// <summary>
  /// Повтор включён оркестратором.
  /// </summary>
  public bool IsRetryEnabledByOrchestrator { get; set; }

  /// <summary>
  /// Язык.
  /// </summary>
  public string Language { get; set; } = "ru";

  /// <summary>
  /// База данных PostgreSQL.
  /// </summary>
  public AppConfigOptionsPostgreSQL? PostgreSQL { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsRabbitMQ? RabbitMQ { get; set; }
}
