using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {

        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40),MinLength(4)]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(100),MinLength(10)]
        public string Founded { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }

}
