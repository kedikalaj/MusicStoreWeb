using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Domain.Models
{
    public class SongViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a name for the song")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an author for the song")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please enter a price for the song")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter a genre id for the song")]
        public int GenreID { get; set; }
        [Required(ErrorMessage = "Please enter a length for the song")]
        public int Length { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}