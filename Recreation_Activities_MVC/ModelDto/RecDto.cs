using IEXTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEXTrading.ModelDto
{
    public class RecDto
    {
      
        public int aid { get; set; }
        public string phone_number { get; set; }
        public string activity { get; set; }
        public string recreation_center { get; set; }
        public string address { get; set; }
        public string age_requirements { get; set; }
        public string days_of_week { get; set; }
        public string times { get; set; }
    }
}
