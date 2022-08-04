using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class TicketsDto
    {
        [JsonProperty("Price")]
     
        [Range(typeof(decimal),"1.00","100.00")]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]

        [Range(typeof(sbyte), "1", "10")]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]

        public int PlayId { get; set; }


    }
}
