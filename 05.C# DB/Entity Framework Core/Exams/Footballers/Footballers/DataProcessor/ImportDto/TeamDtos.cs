using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{

    [JsonObject]
    public class TeamDtos
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(40), MinLength(3)]
       /* [RegularExpression(@"([a-zA-Z]+|\d|\s|[.]|[-])")]*/
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [StringLength(40), MinLength(3)]

        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }


        public int[] Footballers { get; set; }

    }
}
