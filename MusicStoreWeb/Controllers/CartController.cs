using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStoreWeb.Models;

namespace MusicStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private ISongsRepository repository;
        public CartController(ISongsRepository repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(int songId, string returnUrl)
        {
            Song product = repository.Songs
            .FirstOrDefault(p => p.SongID == songId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Song product = repository.Songs
            .FirstOrDefault(p => p.SongID == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

        return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}