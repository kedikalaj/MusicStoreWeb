using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MusicStore.Domain.Entities
{
    public class Song
    {   
        public int SongID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Length { get; set; }

    }
}
