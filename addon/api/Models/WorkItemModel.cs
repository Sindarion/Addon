using api.Enums;
using Supabase.Postgrest.Attributes;

namespace api.Models
{
    [Table("work_items")]
    public class WorkItemModel : BaseModel
    {
        [Column("parent_id")]
        public Guid? ParentId { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("estimated_time")]
        public int? EstimatedTime { get; set; }

        [Column("priority")]
        public EPriority Priority { get; set; }

        [Column("status")]
        public EStatus Status { get; set; }
    }
}
