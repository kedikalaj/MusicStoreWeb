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
        
        private IOrderProcessor orderProcessor;
        public CartController(ISongsRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int songId, string returnUrl)
        {
            Songs product = repository.Songs
            .FirstOrDefault(p => p.ID == songId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        [HttpPost]
        public ActionResult RemoveFromCart(Cart cart, int ID, string returnUrl)
        {
            Songs product = repository.Songs
            .FirstOrDefault(p => p.ID == songId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            CartIndexViewModel model = new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return PartialView("Recipt", model);
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetail());
     
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetail shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

    }
}