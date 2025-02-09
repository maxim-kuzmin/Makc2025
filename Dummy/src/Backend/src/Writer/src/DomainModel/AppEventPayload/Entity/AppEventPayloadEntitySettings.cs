namespace Makc2025.Dummy.Writer.DomainModel.AppEventPayload.Entity;

/// <summary>
/// Настройки сущности полезной нагрузки события приложения.
/// </summary>
/// <param name="MaxLengthForData">Максимальная длина для данных.</param>
public record AppEventPayloadEntitySettings(int MaxLengthForData);
