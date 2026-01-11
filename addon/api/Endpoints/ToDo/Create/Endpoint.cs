using api.Enums;
using api.Services.Interfaces;
using FastEndpoints;

namespace ToDo.Create
{
    internal sealed class Endpoint(IToDoService toDoService, ILinkService linkService) : Endpoint<Request, Response, Mapper>
    {
        private readonly IToDoService _toDoService = toDoService;
        private readonly ILinkService _linkService = linkService;

        public override void Configure()
        {
            Post("api/ToDo");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {

            var toDoItem = await _toDoService.CreateAsync(r.Title, r.Description, r.Status, r.Priority);

            if (r.Links.Count > 0)
            {
                var links = Mapper.ToLinkModels(toDoItem.Id, r.Links);

                await _linkService.AddLinksAsync(toDoItem.Id, links, ELinkOwnerType.Task);
            }

            await SendMapped(toDoItem, ct: c);
        }
    }
}