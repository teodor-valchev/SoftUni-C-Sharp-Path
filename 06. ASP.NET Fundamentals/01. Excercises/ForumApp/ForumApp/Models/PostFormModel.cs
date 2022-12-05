using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class PostFormModel
    {
        public int Id { get; set; }

        [StringLength(50,MinimumLength = 10)]
        [Display(Name = "Загалвие")]
        public string Title { get; set; }

        [StringLength(1500, MinimumLength = 30)]
        [Display(Name ="Съдържание")]
        public string Content { get; set; }
    }
}
