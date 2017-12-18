using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoXe.Controllers
{
    public class HomeController : Controller
    {
        // Trang chủ jdsakdjaskdjsak
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
       
        
        //trang liên 
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}