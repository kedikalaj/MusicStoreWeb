using System.Linq;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using MusicStoreWeb.Models;

namespace MusicStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private ISongsRepository repository;
        
        private IOrderProcessor orderProcessor;
        private IShippingDetailRepository shippingDetailRepository;
        private IOrderRepository OrderRepository;
        public CartController(ISongsRepository repo, IOrderProcessor proc, IShippingDetailRepository sdetail, IOrderRepository orderRepository)
        {
            repository = repo;
            orderProcessor = proc;
            shippingDetailRepository = sdetail;
            OrderRepository = orderRepository;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int ID, string returnUrl)
        {
            Songs product = repository.Songs
            .FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int ID, string returnUrl)
        {
            Songs product = repository.Songs
            .FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout(Cart cart)
        {

            int ID = 2;
            ShippingDetail detail = shippingDetailRepository.ShippingDetail
           .FirstOrDefault(p => p.ID == ID);

            CartIndexViewModel indexView = new CartIndexViewModel
            {
                shippingDetails = detail,
                Cart = cart
            };


            if (indexView != null)
            {
                return View("FinalStep", indexView);
            }

            else
            {
                return View(new CartIndexViewModel());
            }
        }
        public ViewResult editShipping()
        {
            int ID = 1 ;
            ShippingDetail detail = shippingDetailRepository.ShippingDetail
           .FirstOrDefault(p => p.ID == ID);
            return View("Checkout",detail);
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
        public ActionResult SaveShippingDetails(Cart cart)
        {
            int ID = 1;
            ShippingDetail detail = shippingDetailRepository.ShippingDetail
           .FirstOrDefault(p => p.ID == ID);

            CartIndexViewModel indexView = new CartIndexViewModel
            {
                shippingDetails = detail,
                Cart = cart
            };

            if (ModelState.IsValid)
            {


                shippingDetailRepository.SaveShippingDeatails(detail);

                TempData["message"] = string.Format("Shipping details with id {0} has been saved", detail.ID);
                return RedirectToAction("Index");
            }
            else
            {
                return View("FinalStep",detail);
            }
        }

        public ActionResult Finalise(ChekoutModel model)
        {
            int ID = 4;


            OrderRepository.CreateNewOrder(ID, model);

            return View("Finalised");
        }

    }
}