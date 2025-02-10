﻿namespace Makc2025.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;

/// <summary>
/// Команда действия по созданию события приложения.
/// </summary>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppEventCreateActionCommand(
  bool IsPublished,
  string Name) : ICommand<Result<AppEventSingleDTO>>;
