using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountryDtos
    {
        [JsonProperty]
        public int Id { get; set; }

        [XmlElement(nameof(CountryName))]
        [Required]
        [StringLength(60), MinLength(4)]
        public string CountryName { get; set; }

        [XmlElement(nameof(ArmySize))]
        [Required]
        [Range(50_000, 10_000_000)]
        public int ArmySize { get; set; }
    }
}
