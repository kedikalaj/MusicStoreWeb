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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int SongID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        [ForeignKey("SongID")]

        public virtual Songs Song{ get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

    }

    
}
