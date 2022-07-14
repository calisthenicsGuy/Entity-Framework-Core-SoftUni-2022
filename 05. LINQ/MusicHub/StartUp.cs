namespace MusicHub
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using MusicHubContext context = new MusicHubContext();

            // P02: System.Console.WriteLine(ExportAlbumsInfo(context, 9));
            // P03: System.Console.WriteLine(ExportSongsAboveDuration(context, 4));

            context.Dispose();
        }

        // Problem 2: All Albums Produced by Given Producer
        public static string ExportAlbumsInfo(MusicHubContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var targetAlbums = context.Albums
                .Include(a => a.Name)
                .Include(a => a.ReleaseDate)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .Where(p => p.ProducerId == producerId)
                .ToList()
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    Producer = a.Producer.Name,
                    Songs = a.Songs.Select(n => new
                    {
                        Name = n.Name,
                        Price = n.Price,
                        Writter = n.Writter.Name
                    })
                                    .OrderByDescending(s => s.Name)
                                    .ThenBy(s => s.Writter),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice);

            int songCounter = 1;
            foreach (var album in targetAlbums)
            {
                output
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.Producer}")
                    .AppendLine("-Songs:")
                    .AppendLine($"#{songCounter++}");

                foreach (var song in album.Songs)
                {
                    output
                        .AppendLine($"--SongName: {song.Name}")
                        .AppendLine($"--Price: {song.Price:f2}")
                        .AppendLine($"--Writter: {song.Writter}");
                }

                output.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }


            return output.ToString().TrimEnd();
        }

        // Problem 3: Songs Above Given Duration
        public static string ExportSongsAboveDuration(MusicHubContext context, int duration)
        {
            StringBuilder output = new StringBuilder();

            var songs = context.Songs
                .Include(s => s.SongsPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(w => w.Writter)
                .Include(a => a.Album)
                .ThenInclude(p => p.Producer)
                .Include(d => d.Duration)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new 
                { 
                    Name = s.Name,
                    Performer = s.SongsPerformers
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(),
                    Writter = s.Writter.Name,
                    Producer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString()
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writter)
                .ThenBy(s => s.Performer);

            foreach (var song in songs)
            {
                output
                        .AppendLine($"--SongName: {song.Name}")
                        .AppendLine($"--Writter: {song.Writter}")
                        .AppendLine($"--Performer: {song.Performer}")
                        .AppendLine($"--AlbumProducer: {song.Producer}")
                        .AppendLine($"--Duration: {song.Duration}");
            }


            return output.ToString().TrimEnd();
        }
    }
}