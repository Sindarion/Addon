using api.DTOs;
using api.Models;
using api.Services.Interfaces;
using Facet.Extensions;
using Supabase;

namespace api.Services
{
    public class TaskService : ITaskService
    {
        private readonly Client _supabase;

        public TaskService(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<TaskDto>> GetAllAsync()
        {
            var result = await _supabase.From<TaskModel>().Get();

            return [.. result.Models.SelectFacets<TaskModel, TaskDto>()];
        }
    }
}
