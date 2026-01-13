using Supabase.Postgrest.Attributes;

namespace api.Models
{
    [Table("links")]
    public class LinkModel : BaseModel
    {
        [Column("work_item_id")]
        public Guid? WorkItemId { get; set; }

        [Column("expense_id")]
        public Guid? ExpenseId { get; set; }

        [Column("idea_id")]
        public Guid? IdeaId { get; set; }

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("url")]
        public string Url { get; set; } = string.Empty;
    }
}
