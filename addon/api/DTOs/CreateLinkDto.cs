namespace api.DTOs
{
    public record CreateLinkDto(Guid? WorkItemId, Guid? ExpenseId, Guid? IdeaId, string Title, string Url);
}
