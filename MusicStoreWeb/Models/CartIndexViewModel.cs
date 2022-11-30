using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStoreWeb.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public ShippingDetail shippingDetails { get; set; }
        public string ReturnUrl { get; set; }

        public string Username { get; set; }
    }
}