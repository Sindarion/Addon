using api.Enums;
using api.Models;
using api.Services.Interfaces;
using Supabase;

namespace api.Services
{
    public class LinkService(Client supabaseClient) : ILinkService
    {
        private readonly Client _supabaseClient = supabaseClient;

        public async Task AddLinksAsync(List<LinkModel> links)
        {
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
