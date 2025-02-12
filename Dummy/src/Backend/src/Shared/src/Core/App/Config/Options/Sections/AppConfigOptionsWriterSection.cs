namespace Makc2025.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел микросервиса Writer в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsWriterSection
{
  /// <summary>
  /// Тип API.
  /// </summary>
  public AppInfrastructure ApiType { get; set; } = AppInfrastructure.Grpc;

  /// <summary>
  /// Адрес gRPC API.
  /// </summary>
  public string GrpcApiAddress { get; set; } = string.Empty;

  /// <summary>
  /// Адрес HTTP REST API.
  /// </summary>
  public string HttpApiAddress { get; set; } = string.Empty;
}
