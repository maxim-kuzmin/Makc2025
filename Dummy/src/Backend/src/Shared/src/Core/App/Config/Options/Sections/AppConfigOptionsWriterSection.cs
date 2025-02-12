namespace Makc2025.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел микросервиса Writer в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsWriterSection
{
  /// <summary>
  /// Адрес API gRPC.
  /// </summary>
  public string GrpcApiAddress { get; set; } = string.Empty;

  /// <summary>
  /// Адрес API REST.
  /// </summary>
  public string RestApiAddress { get; set; } = string.Empty;

  /// <summary>
  /// Транспорт.
  /// </summary>
  public AppTransport Transport { get; set; } = AppTransport.Grpc;
}
