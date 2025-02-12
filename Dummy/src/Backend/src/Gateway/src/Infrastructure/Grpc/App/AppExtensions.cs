﻿namespace Makc2025.Dummy.Gateway.Infrastructure.Grpc.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="writerApiAddress">Адрес API писателя.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToGrpc(
      this IServiceCollection services,
      ILogger logger,
      string writerApiAddress)
  {
    services.AddTransient<IAppActionCommandService, AppActionCommandService>();
    services.AddTransient<IDummyItemActionCommandService, DummyItemActionCommandService>();
    services.AddTransient<IDummyItemActionQueryService, DummyItemActionQueryService>();

    services.AddGrpcClient<WriterAppGrpcClient>(
      AppSettings.WriterAppClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerApiAddress);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddGrpcClient<WriterDummyItemGrpcClient>(
      AppSettings.WriterDummyItemClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerApiAddress);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application infrastructure tied to Grpc");

    return services;
  }

  /// <summary>
  /// Преобразовать к запросу действия по входу в приложение.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по входу в приложение.</returns>
  public static AppLoginActionRequest ToAppLoginActionRequestForGrpc(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных действия по входу в приложение.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по входу в приложение.</returns>
  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
