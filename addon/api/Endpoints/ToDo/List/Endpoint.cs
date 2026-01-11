using api.Services.Interfaces;
using FastEndpoints;

namespace ToDo.List
{
    internal sealed class Endpoint(IToDoService toDoService) : EndpointWithoutRequest<List<ToDoDto>>
    {
        private readonly IToDoService _toDoService = toDoService;

        public override void Configure()
        {
            Get("api/ToDo");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken c)
        {
            var result = await _toDoService.GetAllAsync();

            var dtos = result.Select(m => new ToDoDto(m.Id, m.Title, m.Status, m.Priority)).ToList();

            await Send.OkAsync(dtos, c);
        }
    }
}