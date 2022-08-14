using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class MyCustomFootballerDtos
    {


        [XmlElement("Name")]
        [Required]
        [StringLength(40), MinLength(2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        [Required]
        public string PositionType { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        public string BestSkillType { get; set; }
    }
}
