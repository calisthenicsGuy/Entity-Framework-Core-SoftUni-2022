
namespace MusicHub.Data.Models
{
    using MusicHub.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.AlbumNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => GetAlbumPrice();


        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        
        
        private decimal GetAlbumPrice()
        {
            decimal price = 0;

            foreach (var song in this.Songs)
            {
                price += song.Price;
            }

            return price;
        }
    }
}
