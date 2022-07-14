
namespace MusicHub.Data.Models
{
    using System;
    using MusicHub.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using MusicHub.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Song
    {
        public Song()
        {
            this.SongsPerformers = new HashSet<SongsPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.SongNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public Album Album { get; set; }


        [ForeignKey(nameof(Writter))]
        public int WritterId { get; set; }
        public virtual Writter Writter { get; set; }

        [Required]
        public decimal Price { get; set; }


        public ICollection<SongsPerformer> SongsPerformers { get; set; }
    }
}
