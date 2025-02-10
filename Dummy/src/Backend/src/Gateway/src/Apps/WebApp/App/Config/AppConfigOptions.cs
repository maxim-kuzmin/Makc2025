namespace Makc2025.Dummy.Gateway.Apps.WebApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions
{
  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthentication? Authentication { get; set; }

  /// <summary>
  /// Писатель.
  /// </summary>
  public AppConfigOptionsWriter? Writer { get; set; }
}
