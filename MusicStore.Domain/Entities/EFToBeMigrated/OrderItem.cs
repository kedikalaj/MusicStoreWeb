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
    public class OrderItem
    {
        [Key]
        public int OrderID { get; set; }
        public int SongID { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("SongID")]

        public virtual Song Song{ get; set; }

    }
}
