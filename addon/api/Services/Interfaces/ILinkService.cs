using api.Enums;
using api.Models;

namespace api.Services.Interfaces
{
    public interface ILinkService
    {
        Task AddLinksAsync(Guid OwnerId, List<LinkModel> links, ELinkOwnerType type);
    }
}
