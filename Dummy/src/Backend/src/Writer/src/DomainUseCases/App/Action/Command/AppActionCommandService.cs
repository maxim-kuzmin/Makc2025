namespace Makc2025.Dummy.Writer.DomainUseCases.App.Action.Command;

/// <summary>
/// Сервис команд действия с приложением.
/// </summary>
/// <param name="_appConfigOptionsAuthenticationSectionSnapshot">
/// Снимок раздела аутентификации в параметрах конфигурации приложения.
/// </param>
public class AppActionCommandService(
  IOptionsSnapshot<AppConfigOptionsAuthenticationSection> _appConfigOptionsAuthenticationSectionSnapshot)
  : IAppActionCommandService
{
  /// <inheritdoc/>
  public Task<Result<AppLoginActionDTO>> Login(AppLoginActionCommand command, CancellationToken cancellationToken)
  {
    var appConfigOptionsAuthenticationSection = _appConfigOptionsAuthenticationSectionSnapshot.Value;

    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, command.UserName)
    };

    var issuerSigningKey = appConfigOptionsAuthenticationSection.GetSymmetricSecurityKey();

    var signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);

    var expires = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

    var token = new JwtSecurityToken(
      issuer: appConfigOptionsAuthenticationSection.Issuer,
      audience: appConfigOptionsAuthenticationSection.Audience,
      claims: claims,
      expires: expires,
      signingCredentials: signingCredentials);

    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

    var dto = new AppLoginActionDTO(command.UserName, accessToken);

    return Task.FromResult(Result.Success(dto));
  }
}
