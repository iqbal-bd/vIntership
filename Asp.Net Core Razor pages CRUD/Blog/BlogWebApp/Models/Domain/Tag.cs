namespace BlogWebApp.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BlogPostId { get; set; }
    }
}
