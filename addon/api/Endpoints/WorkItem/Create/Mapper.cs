using api.DTOs;
using api.Models;
using FastEndpoints;

namespace Create.WorkItem
{
    internal sealed class Mapper : Mapper<Request, Response, WorkItemModel>
    {
        public override Response FromEntity(WorkItemModel e) => new(e.Id);

        public override WorkItemModel ToEntity(Request r)
        {
            return new WorkItemModel
            {
                Title = r.Title,
                Description = r.Description,
                Priority = r.Priority,
                Status = r.Status
            };
        }

        public static List<LinkModel> ToLinkModels(
            Guid toDoId,
            List<LinkDto> links)
            => [.. links.Select(l => new LinkModel
            {
                //OwnerId = toDoId,
                Description = l.Title,
                Url = l.Url,
            })];
    }
}