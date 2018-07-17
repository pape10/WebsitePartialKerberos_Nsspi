using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NSspi;
using NSspi.Contexts;
using NSspi.Credentials;
using WebApplication26.Models;
using WebApplication26.Services;

namespace WebApplication26.Controllers
{
    
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
       
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["SessionCookie"];
            //Response.StatusCode = 401;
            if (myCookie == null)
            {
                //Response.Redirect("https://stackoverflow.com/questions/2882817/how-do-i-redirect-to-another-page-with-asp-net");
                ClientCurrentCredential cred = new ClientCurrentCredential(PackageNames.Negotiate);
                ClientContext context = new ClientContext(
                    cred,
                    "",
                    ContextAttrib.InitIntegrity |
                    ContextAttrib.ReplayDetect |
                    ContextAttrib.SequenceDetect |
                    ContextAttrib.MutualAuth |
                    ContextAttrib.Delegate |
                    ContextAttrib.Confidentiality
                );

                return RedirectToAction("about", new { PrincipalName = cred.PrincipleName });
            }
            else
            {
                Helper h = new Helper();
                SessionTicket s = h.jsonToObject(myCookie.Value);
                return Content(s.name+" "+s.StartTime+" "+s.EndTime+" "+s.Role);
            }
        }
        [Route("[action]/{PrincipalName}")]
        public ActionResult About(string PrincipalName)
        {

            //ViewBag.Message = PrincipalName;
            ServiceReference2.WebService1SoapClient client = new ServiceReference2.WebService1SoapClient();
            string s = client.GetMessage(PrincipalName);
            return RedirectToAction("ActIndex", new {json_string = s});
            //return s;
        }
        [Route("[action]/{json_string}")]
        public ActionResult ActIndex(string json_String)
        {
                Helper h = new Helper();
                SessionTicket s = h.jsonToObject(json_String);
                HttpCookie myCookie = new HttpCookie("SessionCookie");
                // Set the cookie value.
                myCookie.Value = json_String;
                // Set the cookie expiration date.
                myCookie.Expires = DateTime.Now.AddMinutes(30); 
                // Add the cookie.
                Response.Cookies.Add(myCookie);
                return RedirectToAction("Index");
        }
    }
}