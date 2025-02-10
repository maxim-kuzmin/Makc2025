namespace Makc2025.Dummy.Writer.Infrastructure.EntityFramework.App.Db;

/// <summary>
/// Исполнитель базы данных приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbExecutor(AppDbContext dbContext) : DbExecutor(dbContext), IAppDbExecutor
{
}
