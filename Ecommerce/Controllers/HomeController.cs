using Ecommerce.Models;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using Ecommerce.Context;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        public ActionResult Index()
        {
    
            return View();
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}