using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebApplication26.Models;

namespace WebApplication26.Services
{
    public class Helper
    {
        public SessionTicket jsonToObject(string json_string)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            SessionTicket blogObject = js.Deserialize<SessionTicket>(json_string);
            return blogObject;
        }
    }
}