﻿using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunDtos
    {
        [XmlAttribute("Manufacturer")]

        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public string GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public string BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public string Range { get; set; }

        [XmlAttribute("Countries")]

        public ExportCountriesDtos[] Countries { get; set; }
    }
}
