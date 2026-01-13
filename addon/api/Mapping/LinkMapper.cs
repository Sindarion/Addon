using api.DTOs;
using api.Models;

namespace api.Mapping
{
    public static class LinkMapper
    {
        public static LinkModel ToModelWorkItem(this LinkDto dto, Guid workItemId)
        {
            return new LinkModel
            {
                WorkItemId = workItemId,
                Description = dto.Title,
                Url = dto.Url
            };
        }

        public static List<LinkModel> ToModelListWorkItem(this List<LinkDto> dtos, Guid workItemId)
        {
            return [.. dtos.Select(d => d.ToModelWorkItem(workItemId))];
        }

        public static LinkDto ToDto(this LinkModel model)
        {
            return new LinkDto(model.Description, model.Url);
        }

        public static List<LinkDto> ToDtoList(this List<LinkModel> models)
        {
            return [.. models.Select(m => m.ToDto())];
        }
    }
}
