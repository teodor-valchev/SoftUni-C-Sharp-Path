using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastDto
    {
        [XmlElement(nameof(FullName))]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName  { get; set; }

        [XmlElement(nameof(IsMainCharacter))]

        public bool IsMainCharacter  { get; set; }

        [XmlElement(nameof(PhoneNumber))]
        [RegularExpression(@"([+44]{3})-(\d{2})-(\d{3})-(\d{4})")]
        public string  PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        public int PlayId { get; set; }
    }
}
