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
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ShipDetailsID { get; set; }

        //[ForeignKey("OrderID")]
        //[ForeignKey("UserID")]                        <------!
        //[ForeignKey("ShippingDetailsID")]


        public virtual OrderItem OrderItem { get; set; }
        public virtual Songs Songs{ get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }

    }
}
