namespace ProjectPRN212.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogImage { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Summary { get; set; }
        public int? CategoryId { get; set; }

        public virtual BlogCategory? Category { get; set; }
    }
}
