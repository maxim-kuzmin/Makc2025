﻿namespace Makc2025.Dummy.Writer.Infrastructure.Grpc.AppEvent;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  public static AppEventCreateActionCommand ToAppEventCreateActionCommand(
    this AppEventCreateActionRequest request)
  {
    return new(request.IsPublished, request.Name);
  }

  public static AppEventDeleteActionCommand ToAppEventDeleteActionCommand(
    this AppEventDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static AppEventGetActionQuery ToAppEventGetActionQuery(this AppEventGetActionRequest request)
  {
    return new(request.Id);
  }

  public static AppEventGetActionReply ToAppEventGetActionReply(this AppEventSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      IsPublished = dto.IsPublished,
      Name = dto.Name,
    };
  }

  public static AppEventGetListActionQuery ToAppEventGetListActionQuery(
    this AppEventGetListActionRequest request)
  {
    return new(new QueryPage(request.Page.Number, request.Page.Size), new(request.Filter.FullTextSearchQuery));
  }

  public static AppEventGetListActionReply ToAppEventGetListActionGrpcReply(this AppEventListDTO dto)
  {
    AppEventGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppEventGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppEventUpdateActionCommand ToAppEventUpdateActionCommand(
    this AppEventUpdateActionRequest request)
  {
    return new(request.Id, request.IsPublished, request.Name);
  }
}
