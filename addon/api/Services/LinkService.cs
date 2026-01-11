using api.Enums;
using api.Models;
using api.Services.Interfaces;
using Supabase;

namespace api.Services
{
    public class LinkService(Client supabaseClient) : ILinkService
    {
        private readonly Client _supabaseClient = supabaseClient;

        public async Task AddLinksAsync(Guid OwnerId, List<LinkModel> links, ELinkOwnerType type)
        {

            foreach (var link in links)
            {
                link.OwnerId = OwnerId;
                link.OwnerType = type;
                link.CreatedAt = DateTime.Now;
            }

            var res = await _supabaseClient.From<LinkModel>()
                .Insert(links);

            if (res.ResponseMessage is null)
            {
                throw new InvalidOperationException("ResponseMessage was null after insert operation.");
            }

            res.ResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
