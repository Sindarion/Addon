using api.Enums;
using api.Models;
using api.Services.Interfaces;
using Supabase;

namespace api.Services
{
    public class ToDoService(Client supabaseClient) : IToDoService
    {
        private readonly Client _supabaseClient = supabaseClient;

        public async Task<List<ToDoModel>> GetAllAsync()
        {
            var result = await _supabaseClient.From<ToDoModel>().Get();

            return result.Models;
        }

        public async Task<ToDoModel?> GetByIdAsync(Guid id)
        {
            var result = await _supabaseClient.From<ToDoModel>().Where(t => t.Id == id).Get();
            return result.Models.FirstOrDefault();
        }

        public async Task<ToDoModel> CreateAsync(string title, string description, EStatus status, EPriority priority)
        {
            // Create a new ToDoModel instance
            var toDo = new ToDoModel
            {
                Title = title,
                Description = description,
                Status = status,
                Priority = priority,
            };

            var result = await _supabaseClient.From<ToDoModel>().Insert(toDo);

            if (result.Model is null)
            {
                throw new InvalidOperationException("Failed to create ToDo item: result.Model is null.");
            }

            return result.Model;
        }
    }
}
