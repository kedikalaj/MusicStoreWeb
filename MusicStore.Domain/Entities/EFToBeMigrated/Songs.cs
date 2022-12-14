using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Entities
{
    public class Songs
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int GenreID { get; set; }
        public int Length { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [ForeignKey("GenreID")]

        public virtual Genres Genre { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}