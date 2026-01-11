using api.Models;
using FastEndpoints;

namespace ToDo.Create
{
    internal sealed class Mapper : Mapper<Request, Response, ToDoModel>
    {
        public override Response FromEntity(ToDoModel e) => new(e.Id);

        public override ToDoModel ToEntity(Request r)
        {
            // Map request to entity
            return new ToDoModel
            {
                Title = r.Title,
                Description = r.Description,
                Priority = r.Priority,
                Status = r.Status
            };
        }

        public static List<LinkModel> ToLinkModels(
            Guid toDoId,
            List<CreateLinkRequest> links)
            => [.. links.Select(l => new LinkModel
            {
                OwnerId = toDoId,
                Title = l.Title,
                Url = l.Url,
            })];
    }
}