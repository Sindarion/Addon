using api.Models;
using FastEndpoints;

namespace WorkItem.GetById
{
    internal sealed class Mapper : Mapper<Request, Response, WorkItemModel>
    {
        public override Response FromEntity(WorkItemModel e) => new(e.Id, e.Title, e.Description, e.Status, e.Priority, e.CreatedAt);
    }
}