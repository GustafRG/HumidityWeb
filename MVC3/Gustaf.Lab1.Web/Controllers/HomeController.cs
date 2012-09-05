using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;
using NHibernate;

namespace Gustaf.Lab1.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // NHibernate session
        private ISession session;
        
        //
        //log4net through Castle.Core.Logging
        public ILogger Logger { get; set; }

        public HomeController(ISession session)
        {
            this.session = session;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
