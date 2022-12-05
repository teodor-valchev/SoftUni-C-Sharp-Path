using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Coach
    {

        public Coach()
        {
            Footballers = new HashSet<Footballer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40),MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public virtual ICollection<Footballer> Footballers { get; set; }
    }

}
