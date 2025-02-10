﻿namespace Makc2025.Dummy.Writer.Infrastructure.Grpc.AppEvent;

/// <summary>
/// Сервис события приложения.
/// </summary>
/// <param name="_mediator">Посредник.</param>
public class AppEventService(IMediator _mediator) : AppEventServiceBase
{
  public override async Task<AppEventGetActionReply> Create(
    AppEventCreateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppEventCreateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReply();
  }

  public override async Task<Empty> Delete(AppEventDeleteActionRequest request, ServerCallContext context)
  {
    var command = request.ToAppEventDeleteActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return new Empty();
  }

  public override async Task<AppEventGetActionReply> Get(
    AppEventGetActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppEventGetActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReply();
  }

  public override async Task<AppEventGetListActionReply> GetList(
    AppEventGetListActionRequest request,
    ServerCallContext context)
  {
    var query = request.ToAppEventGetListActionQuery();

    var resultTask = _mediator.Send(query, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetListActionGrpcReply();
  }

  public override async Task<AppEventGetActionReply> Update(
    AppEventUpdateActionRequest request,
    ServerCallContext context)
  {
    var command = request.ToAppEventUpdateActionCommand();

    var resultTask = _mediator.Send(command, context.CancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    result.ThrowRpcExceptionIfNotSuccess();

    return result.Value.ToAppEventGetActionReply();
  }
}
