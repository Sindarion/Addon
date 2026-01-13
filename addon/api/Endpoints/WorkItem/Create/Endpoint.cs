using api.Enums;
using api.Services.Interfaces;
using FastEndpoints;

namespace Create.WorkItem
{
    internal sealed class Endpoint(IWorkItemService toDoService, ILinkService linkService) : Endpoint<Request, Response, Mapper>
    {
        private readonly IWorkItemService _toDoService = toDoService;
        private readonly ILinkService _linkService = linkService;

        public override void Configure()
        {
            Post("api/WorkItem");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {

            var toDoItem = await _toDoService.CreateAsync(r.Title, r.Description, r.Status, r.Priority, r.Links);



            await SendMapped(toDoItem, ct: c);
        }
    }
}