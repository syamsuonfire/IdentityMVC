using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>alert('You need to login first!');window.location.href='/Account/Login'</script>");
                //return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Contact()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You need to login first!');window.location.href='/Account/Login'</script>");
            }
        }
    }
}