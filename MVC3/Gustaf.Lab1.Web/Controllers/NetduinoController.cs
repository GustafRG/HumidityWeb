using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gustaf.Lab1.Web.Models;
using Gustaf.Lab1.Web.Repositories;

namespace Gustaf.Lab1.Web.Controllers
{
    public class NetduinoController : Controller
    {
        //
        // Repository with methods persistence. For Loose coupling.
        private readonly IRepository _repository;

        public NetduinoController(IRepository repository)
        {
            this._repository = repository;
        }

        //
        // GET: /Netduino/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Netduino/ReadSHT15
        
        public JsonResult ReadSHT15(ReadSHT15Model model)
        {
            string[] rawResult = _repository.ReadSHT15().Split(';');

            model.Temperature = Convert.ToDouble(rawResult[0]);
			model.Humidity = Convert.ToDouble(rawResult[1]);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
                
        //
        // GET: /Netduino/TemperatureGraph

        public ActionResult TemperatureGraph()
        {
            return View();
        }

        public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
        {
            // Java timestamp is millisecods past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(javaTimeStamp / 1000)).ToLocalTime();
            return dtDateTime;
        }

        //
        // GET: /Netduino/FadeRGB

        public ActionResult FadeRGB()
        {
            return View();
        }
    }
}
