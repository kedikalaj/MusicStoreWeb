using System.Collections.Generic;
using MusicStore.Domain.Entities;


namespace MusicStore.Domain.Models
{
    public class ChekoutModel
    {
        public IEnumerable<Songs> Songs { get; set; }
        public Cart Cart { get; set; }
        public ShippingDetail shippingDetails { get; set; }
        public Order Order { get; set; }
        public User User { get; set; }


    }
}