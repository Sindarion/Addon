using api.Services.Interfaces;
using FastEndpoints;

namespace WorkItem.Delete
{
    internal sealed class Endpoint(IWorkItemService workItemService) : Endpoint<Request, Response, Mapper>
    {
        private readonly IWorkItemService _workItemService = workItemService;

        public override void Configure()
        {
            Delete("api/WorkItem/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await _workItemService.DeleteAsync(r.Id);
            await Send.OkAsync(c);
        }
    }
}