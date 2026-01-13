using api.Enums;
using api.Models;

namespace api.Services.Interfaces
{
    public interface ILinkService
    {
        Task AddLinksAsync(List<LinkModel> links);
    }
}
