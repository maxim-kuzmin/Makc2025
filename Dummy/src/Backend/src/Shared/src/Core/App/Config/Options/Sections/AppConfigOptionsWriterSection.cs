namespace Makc2025.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел микросервиса Writer в параметрах конфигурации приложения.
/// </summary>
/// <param name="GrpcApiAddress">Адрес API gRPC.</param>
/// <param name="RestApiAddress">Адрес API REST.</param>
/// <param name="Transport">Транспорт.</param>
public record AppConfigOptionsWriterSection(string GrpcApiAddress, string RestApiAddress, AppTransport Transport);
