﻿namespace Makc2025.Dummy.Writer.Infrastructure.GRPC.AppEventPayload;

/// <summary>
/// Расширения полезной нагрузки события приложения.
/// </summary>
public static class AppEventPayloadExtensions
{
  public static AppEventPayloadCreateActionCommand ToAppEventPayloadCreateActionCommand(
    this AppEventPayloadCreateActionRequest request)
  {
    return new(request.AppEventId, request.Data);
  }

  public static AppEventPayloadDeleteActionCommand ToAppEventPayloadDeleteActionCommand(
    this AppEventPayloadDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static AppEventPayloadGetActionQuery ToAppEventPayloadGetActionQuery(this AppEventPayloadGetActionRequest request)
  {
    return new(request.Id);
  }

  public static AppEventPayloadGetActionReply ToAppEventPayloadGetActionReply(this AppEventPayloadSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      AppEventId = dto.AppEventId,
      Data = dto.Data,
    };
  }

  public static AppEventPayloadGetListActionQuery ToAppEventPayloadGetListActionQuery(
    this AppEventPayloadGetListActionRequest request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static AppEventPayloadGetListActionReply ToAppEventPayloadGetListActionGrpcReply(this AppEventPayloadListDTO dto)
  {
    AppEventPayloadGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppEventPayloadGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        AppEventId = itemDTO.AppEventId,
        Data = itemDTO.Data,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppEventPayloadUpdateActionCommand ToAppEventPayloadUpdateActionCommand(
    this AppEventPayloadUpdateActionRequest request)
  {
    return new(request.Id, request.AppEventId, request.Data);
  }
}
