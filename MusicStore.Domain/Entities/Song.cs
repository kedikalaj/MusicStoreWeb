using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Domain.Entities
{
    public class Song
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int SongID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        //public int GenreId { get; set; }
        //[ForeignKey("GenreId")]
        //public virtual Genre Genre { get; set; }
        public int Length { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
