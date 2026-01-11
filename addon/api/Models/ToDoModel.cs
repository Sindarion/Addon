using api.Enums;
using Supabase.Postgrest.Attributes;

namespace api.Models
{
    [Table("ToDos")]
    public class ToDoModel : BaseModel
    {
        [Column("Title")]
        public string Title { get; set; } = string.Empty;

        [Column("Description")]
        public string Description { get; set; } = string.Empty;

        [Column("Priority")]
        public EPriority Priority { get; set; }

        [Column("Status")]
        public EStatus Status { get; set; }
    }
}
