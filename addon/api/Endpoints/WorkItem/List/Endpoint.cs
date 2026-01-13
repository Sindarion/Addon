using api.Services.Interfaces;
using FastEndpoints;

namespace List.WorkItem
{
    internal sealed class Endpoint(IWorkItemService toDoService) : EndpointWithoutRequest<List<WorkItemDto>>
    {
        private readonly IWorkItemService _toDoService = toDoService;

        public override void Configure()
        {
            Get("api/WorkItem");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            var result = await _toDoService.GetAllAsync();

            var dtos = result.Select(m => new WorkItemDto(m.Id, m.ParentId,m.Title, m.Status, m.Priority)).ToList();

            await Send.OkAsync(dtos, c);
        }
    }
}