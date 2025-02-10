namespace Makc2025.Dummy.Gateway.Apps.WebApp.App.Config.Options;

/// <summary>
/// Писатель в параметрах конфигурации приложения.
/// </summary>
/// <param name="GrpcApiAddress">Адрес API gRPC.</param>
/// <param name="RestApiAddress">Адрес API REST.</param>
/// <param name="Transport">Транспорт.</param>
public record AppConfigOptionsWriter(string GrpcApiAddress, string RestApiAddress, AppTransport Transport);
