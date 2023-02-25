using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class BlogModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}