using api.Services.Interfaces;
using FastEndpoints;

namespace WorkItem.GetById
{
    internal sealed class Endpoint(IWorkItemService workItemService) : Endpoint<Request, Response, Mapper>
    {
        private readonly IWorkItemService _workItemService = workItemService;

        public override void Configure()
        {
            Get("api/WorkItem/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var result = await _workItemService.GetByIdAsync(r.Id);

            if (result == null)
                await Send.NotFoundAsync(c);
            else
                await SendMapped(result, ct: c);
        }
    }
}