using MusicStore.Domain.Entities;

namespace MusicStoreWeb.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public string Username { get; set; }
    }
}