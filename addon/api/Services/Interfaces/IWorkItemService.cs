using api.DTOs;
using api.Enums;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IWorkItemService
    {
        Task<List<WorkItemModel>> GetAllAsync();
        Task<WorkItemModel?> GetByIdAsync(Guid id);
        Task<WorkItemModel> CreateAsync(string title, string description, EStatus status, EPriority priority, List<LinkDto> links);
        Task DeleteAsync (Guid id);
    }
}
