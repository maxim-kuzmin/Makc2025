﻿namespace Makc2025.Dummy.Writer.Infrastructure.GRPC.AppEventPayload;

/// <summary>
/// Сервис полезной нагрузки события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppEventPayloadService(IMediator _mediator) : AppEventPayloadServiceBase
{
  public override async Task<AppEventPayloadGetActionReply> Create(
    AppEventPayloadCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppEventPayloadCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReply();
  }

  public override async Task<Empty> Delete(AppEventPayloadDeleteActionRequest request, ServerCallContext context)
  {
    var command = request.ToAppEventPayloadDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppEventPayloadGetActionReply> Get(
    AppEventPayloadGetActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppEventPayloadGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReply();
  }

  public override async Task<AppEventPayloadGetListActionReply> GetList(
    AppEventPayloadGetListActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppEventPayloadGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetListActionGrpcReply();
  }

  public override async Task<AppEventPayloadGetActionReply> Update(
    AppEventPayloadUpdateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppEventPayloadUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventPayloadGetActionReply();
  }
}
