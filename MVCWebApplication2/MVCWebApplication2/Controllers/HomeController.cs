using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication2.Controllers
{
    public class HomeController : Controller
    {
        /*public List<string>  Index()
        {
            return "Hello From MVC Application";
        }
        */
        public ViewResult Index() 
        {
            ViewBag.Countries = new List<string>()
            {
                "Ireland",
                "Nigeria",
                "Uk",
                "America"

            }; 

            return View();
        }

      /*  public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}