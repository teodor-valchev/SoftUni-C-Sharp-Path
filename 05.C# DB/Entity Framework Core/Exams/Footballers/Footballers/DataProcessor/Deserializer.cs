namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var coachesDtos = DeserializerMethod<MyCustoCoachDtos[]>(xmlString, "Coaches");

            var theValidCoaches = new List<Coach>();

            foreach (var coach in coachesDtos)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                var realCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality,
                };

                foreach (var footballer in coach.Footballers)
                {
                    var validContractorStartDate = DateTime.TryParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime contractorStartDate);

                    var validContractorEndDate = DateTime.TryParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out DateTime contractorEndDate);

                    var validPositionType = Enum.TryParse<PositionType>(footballer.PositionType, out PositionType positionType);

                    var validBestSkillType = Enum.TryParse<BestSkillType>(footballer.BestSkillType, out BestSkillType bestSkillType);

                    if (!validContractorStartDate || !validContractorEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!validPositionType || !validBestSkillType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractorStartDate > contractorEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validFootballer = new Footballer()
                    {
                        Name = footballer.Name,
                        ContractStartDate = contractorStartDate,
                        ContractEndDate = contractorEndDate,
                        BestSkillType = bestSkillType,
                        PositionType = positionType,

                    };

                    realCoach.Footballers.Add(validFootballer);
                    

                }
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, realCoach.Footballers.Count));
                theValidCoaches.Add(realCoach);
            }

            context.Coaches.AddRange(theValidCoaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var teamDtos = JsonConvert.DeserializeObject<TeamDtos[]>(jsonString);
       

            var validTeams = new List<Team>();

            foreach (var tDto in teamDtos)
            {
                if (!IsValid(tDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (tDto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = tDto.Name,
                    Nationality = tDto.Nationality,
                    Trophies = tDto.Trophies
                };

                foreach (var footballer in tDto.Footballers.Distinct())
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footbollerId = context.Footballers.Find(footballer);

                    if (footbollerId == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Team = team,
                        Footballer = footbollerId
                    });


                }

                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count} footballers.");
                validTeams.Add(team);
            }


            context.Teams.AddRange(validTeams);
            context.SaveChanges();


            return sb.ToString().TrimEnd();


        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T DeserializerMethod<T>(string inputXml, string rootName)
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
