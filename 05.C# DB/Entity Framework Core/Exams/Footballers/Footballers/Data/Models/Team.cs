using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Team
    {

        public Team()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40),MinLength(3)]
        [RegularExpression(@"[a-zA-Z\d\s.-]+")]
        public string Name { get; set; }

        [Required]
        [StringLength(40), MinLength(3)]

        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }

    }



}
