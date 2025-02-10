﻿namespace Makc2025.Dummy.Writer.DomainUseCases.App.Actions.Login;

/// <summary>
/// Объект передачи данных действия по входу в приложение.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="AccessToken">Токен доступа.</param>
public record AppLoginActionDTO(
  string UserName,
  string AccessToken);
