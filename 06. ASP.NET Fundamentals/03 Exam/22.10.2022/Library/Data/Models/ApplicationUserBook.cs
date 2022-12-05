using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUserId))]
        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(BookId))]
        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }
    }


}
