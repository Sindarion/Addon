using api.DTOs;
using api.Enums;
using api.Mapping;
using api.Models;
using api.Services.Interfaces;
using Supabase;

namespace api.Services
{
    public class WorkItemService(Client supabaseClient, ILinkService linkService) : IWorkItemService
    {
        private readonly Client _supabaseClient = supabaseClient;
        private readonly ILinkService _linkService = linkService;

        public async Task<List<WorkItemModel>> GetAllAsync()
        {
            var result = await _supabaseClient.From<WorkItemModel>().Get();

            return result.Models;
        }

        public async Task<WorkItemModel?> GetByIdAsync(Guid id)
        {
            var result = await _supabaseClient.From<WorkItemModel>().Where(t => t.Id == id).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<WorkItemModel> CreateAsync(string title, string description, EStatus status, EPriority priority, List<LinkDto> links)
        {
            var workItem = new WorkItemModel
            {
                Title = title,
                Description = description,
                Status = status,
                Priority = priority,
            };

            var result = await _supabaseClient.From<WorkItemModel>().Insert(workItem);

            if (result.Model is null)
            {
                throw new InvalidOperationException("Failed to create Work Item: result.Model is null.");
            }

            //TODO: uncomment when link service is ready
            //if (links.Count > 0)
            //{
            //    var linkList = LinkMapper.ToModelListWorkItem(links, result.Model.Id);

            //    await _linkService.AddLinksAsync(linkList);
            //}

            return result.Model;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _supabaseClient
                .From<WorkItemModel>()
                .Where(x => x.Id == id)
                .Delete();
        }
    }
}
