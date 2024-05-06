
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.
                Shells
                .Include(x=>x.Guns)
                .ToArray()
                .Where(s=>s.ShellWeight>shellWeight)
                .Select(s=> new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                    .Where(g=>g.GunType== GunType.AntiAircraftGun)
                    .Select(g=> new
                    {
                        GunType = "AntiAircraftGun",
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range": "Regular range"

                    }).OrderByDescending(g=>g.GunWeight)
                    .ToArray()
                }).OrderBy(s=>s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells,Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context
                .Guns
                .Include(c=>c.CountriesGuns)
                .Include(m => m.Manufacturer)             
                .ToArray()
                .Where(m => m.Manufacturer.ManufacturerName == manufacturer)
                .Select(m => new ExportGunDtos
                {
                    Manufacturer = m.Manufacturer.ManufacturerName,
                    GunType = m.GunType.ToString(),
                    GunWeight = m.GunWeight.ToString(),
                    BarrelLength = m.BarrelLength.ToString(),
                    Range = m.Range.ToString(),
                    Countries = m.CountriesGuns
                    .Where(x=>x.Country.ArmySize> 4500000)
                    .Select(s=> new ExportCountriesDtos
                    {
                        Country =  s.Country.CountryName,
                        ArmySize = s.Country.ArmySize,
                    }).OrderBy(a=>a.ArmySize)
                    .ToArray()
                    
                }).OrderBy(b=>b.BarrelLength)
                .ToArray();

          

            return Serialize(guns,"Guns");
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
