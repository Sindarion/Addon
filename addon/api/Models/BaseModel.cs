using Supabase.Postgrest.Attributes;

namespace api.Models
{
    public abstract class BaseModel : Supabase.Postgrest.Models.BaseModel
    {
        [PrimaryKey("Id")]
        public Guid Id { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
