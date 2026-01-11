using api.Services.Interfaces;
using FastEndpoints;

namespace ToDo.GetById
{
    internal sealed class Endpoint(IToDoService toDoService) : Endpoint<Request, Response, Mapper>
    {
        private readonly IToDoService _toDoService = toDoService;

        public override void Configure()
        {
            Get("api/ToDo/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var result = await _toDoService.GetByIdAsync(r.Id);

            if (result == null)
                await Send.NotFoundAsync(c);
            else
                await SendMapped(result, ct: c);
        }
    }
}