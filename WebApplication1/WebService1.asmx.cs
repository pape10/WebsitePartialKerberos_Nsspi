using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetMessage(string name)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.Now.AddMinutes(30);
            string PrincipalName = name;
            string roles = SQLTicket.GetRoleUser(PrincipalName);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(new SessionTicket {name = PrincipalName,StartTime = d1,EndTime = d2,Role=roles});

        }
    }
}
