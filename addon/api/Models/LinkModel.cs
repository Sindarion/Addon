using api.Enums;
using Supabase.Postgrest.Attributes;

namespace api.Models
{
    [Table("Links")]
    public class LinkModel : BaseModel
    {
        [Column("OwnerId")]
        public Guid OwnerId { get; set; }

        [Column("OwnerType")]
        public ELinkOwnerType OwnerType { get; set; }

        [Column("Title")]
        public string Title { get; set; } = string.Empty;

        [Column("Url")]
        public string Url { get; set; } = string.Empty;
    }
}
