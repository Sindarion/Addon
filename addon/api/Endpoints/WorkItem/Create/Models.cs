using api.DTOs;
using api.Enums;
using FastEndpoints;

namespace Create.WorkItem
{
    internal sealed class Request
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public EPriority Priority { get; init; }
        public EStatus Status { get; init; }
        public List<LinkDto> Links { get; init; } = [];

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {

            }
        }
    }

    internal sealed record Response(Guid Id);
}
