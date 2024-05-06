﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ShellDtos
    {
        [XmlElement("ShellWeight")]
        [Required]
        [Range(typeof(double), "2", "1680")]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [StringLength(30), MinLength(4)]
        public string Caliber { get; set; }
    }
}
