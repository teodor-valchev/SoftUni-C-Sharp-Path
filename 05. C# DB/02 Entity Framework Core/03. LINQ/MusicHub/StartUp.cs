namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                 .Where(p => p.ProducerId == producerId)
                 .Include(p => p.Producer)
                 .Include(s => s.Songs)
                 .ThenInclude(w => w.Writer)
                 .ToArray()
                 .Select(a => new
                 {
                     AlbumName = a.Name,
                     RelaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProducerName = a.Producer.Name,
                     AlbumPrice = a.Price,
                     AlbumSongs = a.Songs.Select(s => new
                     {
                         SongName = s.Name,
                         Price = s.Price,
                         SongWriter = s.Writer.Name
                     }).OrderByDescending(s => s.SongName)
                     .ThenBy(w => w.SongWriter)
                     .ToArray()
            
                 })
                 .OrderByDescending(a=>a.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"ReleaseDate: {album.RelaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}");

                int counter = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"-Songs:")
                        .AppendLine($"---#{counter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.SongWriter}");
                }
         
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
           var songs = context.Songs
                .Include(sp=>sp.SongPerformers)
                .ThenInclude(p=>p.Performer)
                .Include(w => w.Writer)
                .Include(a => a.Album)
                .ThenInclude(p => p.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)             
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerName = s.SongPerformers
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                    ).FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                }).OrderBy(s => s.SongName)
                .ThenBy(w => w.WriterName)
                .ThenBy(p => p.PerformerName)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();
            int count = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
