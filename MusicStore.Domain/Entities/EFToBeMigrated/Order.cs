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
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ShipDetailsID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User{ get; set; }
        [ForeignKey("ShipDetailsID")]
        public virtual ShippingDetail ShippingDetail { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
