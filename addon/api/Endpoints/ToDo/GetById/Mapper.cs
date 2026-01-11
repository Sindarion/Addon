using api.Models;
using FastEndpoints;

namespace ToDo.GetById
{
    internal sealed class Mapper : Mapper<Request, Response, ToDoModel>
    {
        public override Response FromEntity(ToDoModel e) => new(e.Id, e.Title, e.Description, e.Status, e.Priority, e.CreatedAt);
    }
}