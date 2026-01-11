using api.Enums;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDoModel>> GetAllAsync();
        Task<ToDoModel?> GetByIdAsync(Guid id);
        Task<ToDoModel> CreateAsync(string title, string description, EStatus status, EPriority priority);
    }
}
