using api.Enums;

namespace List.WorkItem
{
    internal sealed record WorkItemDto(Guid Id, Guid? ParentId, string Title, EStatus Status, EPriority Priority);
}