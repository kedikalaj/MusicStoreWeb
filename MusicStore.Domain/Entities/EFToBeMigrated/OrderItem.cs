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
        public int ID { get; set; }
        public int SongID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        [ForeignKey("ID")]

        public virtual Songs Song{ get; set; }
        [ForeignKey("ID")]
        public virtual Order Order { get; set; }

    }

    //public void AddOrder(User user, ShippingDetail details, List<OrderItemModel> listOfOrderItems)
    //{
    //    Order order = new Order()
    //    {
    //        UserID = user.UserID,
    //        ShipDetailsID = details.ShippingDetailsID,
    //    };
    //    _orderRepository.Add(order);
    //    foreach(var item in listOfOrderItems)
    //    {
    //        OrderItem orderItem = new OrderItem()
    //        {
    //            SongID = item.SongID,
    //            Quantity = item.Quantity,
    //            OrderID = order.ID
    //        };
    //    }

    //}
    //public class OrderItemModel
    //{
    //    public int SongID { get; set; }
    //    public int Quantity { get; set; }
    //}
}
