using ForumApp.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.MaxTitleLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.MaxContentLength)]
        public string Content { get; set; } = null!;
    }
}
