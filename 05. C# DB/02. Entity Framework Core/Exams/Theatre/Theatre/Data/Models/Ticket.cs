﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        [MaxLength(100)]
        public decimal  Price { get; set; }

        [Required]
        [MaxLength(10)]
        public sbyte RowNumber { get; set; }

        [ForeignKey(nameof(Play))]
        [Required]

        public int PlayId { get; set; }

        public Play Play { get; set; }

        [ForeignKey(nameof(Theatre))]
        [Required]

        public int TheatreId  { get; set; }

        public Theatre Theatre { get; set; }
    }
}
