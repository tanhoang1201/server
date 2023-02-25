using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace server.Context
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public Guid BlogId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}