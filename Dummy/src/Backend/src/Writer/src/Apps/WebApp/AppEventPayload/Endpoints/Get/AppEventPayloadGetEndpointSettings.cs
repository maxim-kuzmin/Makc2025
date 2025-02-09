﻿namespace Makc2025.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.Get;

/// <summary>
/// Настройки конечной точки получения полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadGetEndpointSettings
{
  /// <summary>
  /// Маршрут.
  /// </summary>
  public const string Route = $"{AppEventPayloadEndpointsSettings.Root}/{{id:long}}";
}
