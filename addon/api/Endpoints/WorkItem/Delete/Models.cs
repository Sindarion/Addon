using FastEndpoints;

namespace WorkItem.Delete
{
    internal sealed class Request
    {
        public Guid Id { get; set; }

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {

            }
        }
    }

    internal sealed class Response
    {
        public string Message => "This endpoint hasn't been implemented yet!";
    }
}
