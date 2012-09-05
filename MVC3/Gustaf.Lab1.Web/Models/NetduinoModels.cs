using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Gustaf.Lab1.Web.Models
{
    public class ReadSHT15Model
    {

        [Display(Name = "Temperature")]
        public double Temperature { get; set; }

        [Display(Name = "Humidity")]
		public double Humidity { get; set; }
    }

    public class FadeRGBModel
    {
        [Display(Name = "Color")]
        public  String HEXRGBColor { get; set; }
    }
    
}