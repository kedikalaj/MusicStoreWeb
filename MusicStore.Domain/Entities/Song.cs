using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace MusicStore.Domain.Entities
{
    public class Song
    {
        [HiddenInput(DisplayValue = false)]
        public int SongID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int Length { get; set; } 
    }
}
