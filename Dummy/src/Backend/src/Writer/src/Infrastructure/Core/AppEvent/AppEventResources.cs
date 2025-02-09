﻿namespace Makc2025.Dummy.Writer.Infrastructure.Core.AppEvent;

/// <summary>
/// Ресурсы фиктивного предмета.
/// </summary>
/// <param name="_stringLocalizer">Локализатор строк.</param>
public class AppEventResources(IStringLocalizer<AppEventResources> _stringLocalizer) : IAppEventResources
{
  /// <inheritdoc/>
  public string GetCreatedAtIsInvalidErrorMessage()
  {
    return _stringLocalizer["Error:CreatedAtIsInvalid"];
  }

  /// <inheritdoc/>
  public string GetNameIsEmptyErrorMessage()
  {
    return _stringLocalizer["Error:NameIsEmpty"];
  }

  /// <inheritdoc/>
  public string GetNameIsTooLongErrorMessage(int maxLength)
  {
    return _stringLocalizer["Error:Format:NameIsTooLong", maxLength];
  }
}
