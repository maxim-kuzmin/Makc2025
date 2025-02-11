namespace Makc2025.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел аутентификации в параметрах конфигурации приложения.
/// </summary>
/// <param name="Issuer">Издатель.</param>
/// <param name="Audience">Аудитория.</param>
/// <param name="Key">Ключ.</param>
public record AppConfigOptionsAuthenticationSection(
  string Issuer,
  string Audience,
  string Key)
{
  /// <summary>
  /// Получить симметричный ключ безопасности.
  /// </summary>
  /// <returns>Симметричный ключ безопасности.</returns>
  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    var keyBytes = Encoding.UTF8.GetBytes(Key);

    return new SymmetricSecurityKey(keyBytes);
  }
}
