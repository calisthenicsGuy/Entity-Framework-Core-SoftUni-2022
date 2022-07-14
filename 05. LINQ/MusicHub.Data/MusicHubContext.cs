namespace MusicHub.Data
{
    using MusicHub.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class MusicHubContext : DbContext
    {
        public MusicHubContext()
        {

        }

        public MusicHubContext(DbContextOptions<MusicHubContext> options)
            : base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Writter> Writters { get; set; }
        public DbSet<SongsPerformer> SongsPerformers { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongsPerformer>()
                .HasKey(e => new { e.SongId, e.PerformerId });

            modelBuilder.Entity<Song>()
                .HasKey(e => new { e.AlbumId, e.WritterId });


            modelBuilder.Entity<SongsPerformer>()
                .HasOne(t => t.Song)
                .WithMany(c => c.SongsPerformers)
                .HasForeignKey(t => t.SongId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
