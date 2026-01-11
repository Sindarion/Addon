using api.Enums;
using FastEndpoints;

namespace ToDo.Create
{
    internal sealed class Request
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public EPriority Priority { get; init; }
        public EStatus Status { get; init; }
        public List<CreateLinkRequest> Links { get; init; } = [];

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {

            }
        }
    }

    internal sealed record Response(Guid Id);

    internal sealed record CreateLinkRequest(string Title, string Url);
}
