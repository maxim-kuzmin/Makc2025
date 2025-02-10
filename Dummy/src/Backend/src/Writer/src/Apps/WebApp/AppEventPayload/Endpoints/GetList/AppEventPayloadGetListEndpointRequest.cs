﻿namespace Makc2025.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка полезных нагрузок события приложения.
/// </summary>
public record AppEventPayloadGetListEndpointRequest(int CurrentPage, int ItemsPerPage, string? Query);
