namespace Makc2025.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел брокера сообщений RabbitMQ в параметрах конфигурации приложения.
/// </summary>
/// <param name="HostName">Имя хоста.</param>
/// <param name="Password">Пароль.</param>
/// <param name="Port">Порт.</param>
/// <param name="UserName">Имя пользователя.</param>
public record AppConfigOptionsRabbitMQSection(
  string HostName,
  string Password,
  int Port,
  string UserName);
