using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ManufacturerDtos
    {
        [XmlElement(nameof(ManufacturerName))]
        [Required]
        [StringLength(40), MinLength(4)]
        public string ManufacturerName { get; set; }

        [XmlElement(nameof(Founded))]
        [Required]
        [StringLength(100), MinLength(10)]
        public string Founded { get; set; }
    }
}
