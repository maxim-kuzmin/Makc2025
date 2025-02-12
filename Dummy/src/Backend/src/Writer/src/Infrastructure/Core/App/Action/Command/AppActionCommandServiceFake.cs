namespace Makc2025.Dummy.Writer.Infrastructure.Core.App.Action.Command;

/// <summary>
/// Подделка сервиса команд действия с приложением.
/// </summary>
public class AppActionCommandServiceFake : IAppActionCommandService
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken)
  {
    var dto = new AppLoginActionDTO(command.UserName, string.Empty);

    return Task.FromResult(Result.Success(dto));
  }
}
