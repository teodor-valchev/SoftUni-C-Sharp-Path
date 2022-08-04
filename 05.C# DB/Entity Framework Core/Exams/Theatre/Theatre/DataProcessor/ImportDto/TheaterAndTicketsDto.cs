using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheaterAndTicketsDto
    {
     [JsonProperty("Name")]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; }

        [JsonProperty("NumberOfHalls")]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [MaxLength(30)]
        [MinLength(4)]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public TicketsDto[] Tickets { get; set; }
    }
}



   