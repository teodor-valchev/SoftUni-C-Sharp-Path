using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class MyCustoCoachDtos
    {
      
        [XmlElement("Name")]
        [Required]
        [StringLength(40), MinLength(2)]
        public string Name { get; set; }

        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public MyCustomFootballerDtos[] Footballers { get; set; }


    }
}
