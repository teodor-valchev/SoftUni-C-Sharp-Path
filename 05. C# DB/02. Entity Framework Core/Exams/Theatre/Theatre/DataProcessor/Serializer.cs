namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context
                 .Theatres
                 .Include(x => x.Tickets)
                 .Where(t => t.NumberOfHalls >= numbersOfHalls)
                 .Where(t=>t.Tickets.Count>=20)
                 .ToList()
                 .Select(t => new
                 {
                     Name = t.Name,
                     Halls = t.NumberOfHalls,
                     TotalIncome = Decimal.Parse(t.Tickets
                     .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                     .Sum(p => p.Price).ToString("F2")),
                     Tickets = t.Tickets.Where(t=>t.RowNumber >=1 && t.RowNumber<=5).Select(t => new
                     {
                         Price = Decimal.Parse(t.Price.ToString("f2")),
                         RowNumber = t.RowNumber
                     }).OrderByDescending(t => t.Price)
                     .ToArray()
                })
                 .OrderByDescending(t=>t.Halls)
                 .ThenBy(t => t.Name)
                 
                 .ToArray();
            

            return JsonConvert.SerializeObject(theaters,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            return "sb";
        }
    }
}
