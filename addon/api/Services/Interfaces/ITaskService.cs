using api.DTOs;

namespace api.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<List<TaskDto>> GetAllAsync();
    }
}
