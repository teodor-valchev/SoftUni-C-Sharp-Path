using Artillery.Data.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class GunDtos
    {

        [JsonProperty(nameof(ManufacturerId))]
        [Required]
        public int ManufacturerId { get; set; }

        [JsonProperty(nameof(GunWeight))]
        [Required]
        [Range(100, 1350000)]
        public int GunWeight { get; set; }

        [JsonProperty(nameof(BarrelLength))]
        [Required]
        [Range(typeof(double), "2.00", "35.00")]

        public double BarrelLength { get; set; }

        [JsonProperty(nameof(NumberBuild))]

        public int? NumberBuild { get; set; }

        [JsonProperty(nameof(Range))]
        [Required]
        [Range(1, 100000)]

        public int Range { get; set; }

        [JsonProperty(nameof(GunType))]
        [Required]

        public string GunType { get; set; }

        [JsonProperty(nameof(ShellId))]
        [Required]
        public int ShellId { get; set; }

        [JsonProperty(nameof(Countries))]
        public CountryDtos[] Countries { get; set; }
    }
}
