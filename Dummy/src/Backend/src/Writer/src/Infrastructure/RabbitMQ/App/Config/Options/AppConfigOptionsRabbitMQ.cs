namespace Makc2025.Dummy.Writer.Infrastructure.RabbitMQ.App.Config.Options;

/// <summary>
/// Раздел RabbitMQ в параметрах конфигурации приложения.
/// </summary>
/// <param name="HostName">Имя хоста.</param>
/// <param name="Password">Пароль.</param>
/// <param name="Port">Порт.</param>
/// <param name="UserName">Имя пользователя.</param>
public record AppConfigOptionsRabbitMQ(
  string HostName,
  string Password,
  int Port,
  string UserName);
