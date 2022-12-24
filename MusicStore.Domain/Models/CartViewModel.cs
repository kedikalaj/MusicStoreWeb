using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public ShippingDetail shippingDetails { get; set; }

        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}