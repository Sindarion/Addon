using api.Enums;
using FastEndpoints;
using FluentValidation;

namespace ToDo.GetById
{
    internal sealed class Request
    {
        public Guid Id { get; set; }

        internal sealed class Validator : Validator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            }
        }
    }

    internal sealed record Response(Guid Id, string Title, string Description, EStatus Status, EPriority Priority, DateTime CreatedAt);
}
