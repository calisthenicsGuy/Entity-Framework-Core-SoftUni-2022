
namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class SongsPerformer
    {
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public Song Song { get; set; }


        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; }
    }
}
