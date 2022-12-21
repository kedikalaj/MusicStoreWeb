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
        private IUserRepository UserRepository;
        public CartController(ISongsRepository repo, IOrderProcessor proc, IShippingDetailRepository sdetail, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            repository = repo;
            orderProcessor = proc;
            shippingDetailRepository = sdetail;
            OrderRepository = orderRepository;
            UserRepository = userRepository;
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

            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var user = UserRepository.User
            .Where(p => p.Username == value).FirstOrDefault();

            int ID = user.ID;


            ShippingDetail detail = shippingDetailRepository.ShippingDetail
           .LastOrDefault(p => p.ID == ID);
           

            CartIndexViewModel indexView = new CartIndexViewModel
            {
                shippingDetails = detail,
                Cart = cart
            };


            if (detail != null)
            {
                return View("FinalStep", indexView);
            }

            else
            {
                return View(new ShippingDetail());
            }
        }
        public ViewResult newShippingDetails(ShippingDetail detail)
        {
            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var user = UserRepository.User
            .Where(p => p.Username == value).FirstOrDefault();

            int ID = user.ID;


            if (ModelState.IsValid)
            {


                shippingDetailRepository.SaveShippingDeatails(detail);

            }

            return View("Checkout");
            
          
        }
        public ViewResult editShipping()
        {


            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var user = UserRepository.User
            .Where(p => p.Username == value).FirstOrDefault();

            string name = user.Username;


            ShippingDetail detail = shippingDetailRepository.ShippingDetail.LastOrDefault(p => p.Name== name);

            

            return View("Checkout", detail);
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetail detail)
        {


            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }


            CartIndexViewModel indexView = new CartIndexViewModel
            {
                shippingDetails = detail,
                Cart = cart
            };


            if (detail != null && ModelState.IsValid)
            {
                shippingDetailRepository.SaveShippingDeatails(detail);
                return View("FinalStep", indexView);
            }

            else
            {
                return View(new ShippingDetail());
            }


        }
        //    public ViewResult Checkout(Cart cart, ShippingDetail shippingDetails)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Sorry, your cart is empty!");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        orderProcessor.ProcessOrder(cart, shippingDetails);
        //        cart.Clear();
        //        return View("Completed");
        //    }
        //    else
        //    {
        //        return View(shippingDetails);
        //    }
        //}
        
        public ActionResult SaveShippingDetails(Cart cart, ShippingDetail shippingDetails)
        {
            


            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var user = UserRepository.User
            .Where(p => p.Username == value).FirstOrDefault();

            int ID = user.ID;




            ShippingDetail detail = shippingDetailRepository.ShippingDetail
           .LastOrDefault(p => p.ID == ID);

            if (detail == null)
            {
                detail = shippingDetails;
            }

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
                return View("FinalStep", indexView);
            }
        }

        public ActionResult Finalise(ChekoutModel model)
        {
           


            string value = "";
            
            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var user = UserRepository.User
            .Where(p => p.Username == value).FirstOrDefault();

            int ID = user.ID;

            OrderRepository.CreateNewOrder(ID, model);

            return View("Finalised");
        }
        public ActionResult detailExists(Cart cart)
        {
            string value = "";

            if (Request.Cookies["fatcookie"] != null)
            {
                string value2 = Request.Cookies["fatcookie"]["username"];
                value = value2;

            }

            var userd = shippingDetailRepository.ShippingDetail.Where(m => m.Name == value).FirstOrDefault(); ;

            CartIndexViewModel indexView = new CartIndexViewModel
            {
                shippingDetails = userd,
                Cart = cart
            };

            if (userd== null)
            {
                return RedirectToAction("newShippingDetails", new ShippingDetail());
              
            }
            else
            {

                return View("FinalStep", indexView);
            }
        }

    }
}