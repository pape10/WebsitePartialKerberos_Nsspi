using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication26.Models;
using WebApplication26.Services;

namespace WebApplication26.Controllers
{
    public class TrialController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["SessionCookie"];
            //Response.StatusCode = 401;
            if (myCookie == null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                Helper h = new Helper();
                SessionTicket s = h.jsonToObject(myCookie.Value);
                return Content(s.name + " " + s.StartTime + " " + s.EndTime + " " + s.Role);
            }
        }
    }
}