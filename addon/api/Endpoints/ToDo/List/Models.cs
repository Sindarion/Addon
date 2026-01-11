using api.Enums;

namespace ToDo.List
{
    internal sealed record ToDoDto(Guid Id, string Title, EStatus Status, EPriority Priority);
}
