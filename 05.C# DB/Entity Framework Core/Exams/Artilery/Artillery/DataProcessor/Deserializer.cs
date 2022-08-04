namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var countryDtos = Deserialize<CountryDtos[]>(xmlString, "Countries");

            var countries = new HashSet<Country>();

            var sb = new StringBuilder();

            foreach (var country in countryDtos)
            {
                var currentCountry = new Country
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize
                };

                if (!IsValid(currentCountry))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                countries.Add(currentCountry);
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static object XmlDeserializer<T>(object cOUNTRIES, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var manufacturerDtos = Deserialize<ManufacturerDtos[]>(xmlString, "Manufacturers");

            var manufacturers = new HashSet<Manufacturer>();

            var sb = new StringBuilder();

            var manufacturerNamesImported = new List<string>();

            foreach (var manufacturer in manufacturerDtos)
            {
                var currentManufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturer.ManufacturerName,
                    Founded = manufacturer.Founded
                };

                if (!IsValid(currentManufacturer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (manufacturerNamesImported.Contains(manufacturer.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                manufacturerNamesImported.Add(manufacturer.ManufacturerName);

                var townCountry = manufacturer.Founded.Split(", ").TakeLast(2).ToList();

                var townName = townCountry[0];

                var countryName = townCountry[1];

                manufacturers.Add(currentManufacturer);
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, $"{townName}, {countryName}")); ;
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var shellDtos = Deserialize < ShellDtos[]>(xmlString, "Shells");

            var shells = new HashSet<Shell>();

            var sb = new StringBuilder();

            foreach (var shell in shellDtos)
            {
                var currentShell = new Shell
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber
                };

                if (!IsValid(currentShell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                shells.Add(currentShell);
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var gunDtos = JsonConvert.DeserializeObject<GunDtos[]>(jsonString);

            var validGuns = new List<Gun>();

            foreach (var gDto in gunDtos)
            {
               

                var gunParse = Enum.TryParse<GunType>(gDto.GunType, out GunType realGun);

                if (!gunParse)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = (new Gun
                {
                    ManufacturerId = gDto.ManufacturerId,
                    GunWeight = gDto.GunWeight,
                    BarrelLength = gDto.BarrelLength,
                    NumberBuild = gDto.NumberBuild,
                    Range = gDto.Range,
                    GunType = realGun,
                    ShellId = gDto.ShellId

                });

                foreach (var country in gDto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun 
                    { 
                    Gun = gun,
                    CountryId = country.Id,
                    
                    });

                }

                if (!IsValid(gun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validGuns.Add(gun);
                sb.AppendLine(String.Format(SuccessfulImportGun, gDto.GunType, gDto.GunWeight, gDto.BarrelLength));
            }
            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
               .Deserialize(reader);

            return dtos;
        }
    }
}
