using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Domain.Models
{
    public class SongViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int GenreID { get; set; }
        public int Length { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}