using Supabase.Postgrest.Attributes;

namespace api.Models
{
    public abstract class BaseModel : Supabase.Postgrest.Models.BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
