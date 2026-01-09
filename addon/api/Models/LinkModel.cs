namespace api.Models
{
    public class LinkModel : BaseModel
    {
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
