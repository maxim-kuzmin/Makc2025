namespace Makc2025.Dummy.Writer.Infrastructure.PostgreSQL.App.Db;

/// <summary>
/// Настройки базы данных приложения для PostgreSQL.
/// </summary>
public record AppDbSettings : AppDbSettingsBase
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettings()
  {
    Schema = "writer";
    Entities = new AppDbSettingsEntities(Schema);    
  }
}
