using api.Enums;
using Supabase.Postgrest.Attributes;

namespace api.Models
{
    [Table("Tasks")]
    public class TaskModel : BaseModel
    {
        [Column("Description")]
        public string Description { get; set; } = string.Empty;

        [Column("Priority")]
        public EPriority Priority { get; set; }

        [Column("Status")]
        public EStatus Status { get; set; }
    }
}
