namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";
        private static object play;

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var xmlPlays = Deserialize<List<PlayDto>>(xmlString, "Plays");
            var plays = new List<Play>();

            var sb = new StringBuilder();

            foreach (var play in xmlPlays)
            {
                var isvalidDuration = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture, out var duration);
                var isvalidGenre = Enum.TryParse<Genre>(play.Genre, out var genre);

                if (!isvalidGenre || !isvalidDuration || !IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                plays.Add(new Play
                {
                    Duration = duration,
                    Genre = genre,
                    Description = play.Description,
                    Rating = play.Rating,
                    Screenwriter = play.Screenwriter,
                    Title = play.Title
                });
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var castDtos = Deserialize<CastDto[]>(xmlString, "Casts");

            var validcasts = new List<Cast>();

            foreach (var cast in castDtos)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                validcasts.Add(new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId,
                });
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(validcasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theaterAndTicketsDtos = JsonConvert.DeserializeObject<TheaterAndTicketsDto[]>(jsonString);

            var validtheaters = new List<Theatre>();

            foreach (var theaterDto in theaterAndTicketsDtos)
            {
                if (!IsValid(theaterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                

                var validTheater = (new Theatre
                {
                    Name = theaterDto.Name,
                    NumberOfHalls = theaterDto.NumberOfHalls,
                    Director = theaterDto.Director
                });

                foreach (var ticket in theaterDto.Tickets)
                {

                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTheater.Tickets.Add(new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId,
                    });
                }
                validtheaters.Add(validTheater);

                sb.AppendLine(String.Format(SuccessfulImportTheatre, validTheater.Name, validTheater.Tickets.Count));
            }

            context.Theatres.AddRange(validtheaters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
