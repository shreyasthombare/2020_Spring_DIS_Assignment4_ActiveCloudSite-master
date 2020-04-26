using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEXTrading.Models
{
    public class viewmodel
    {
        public IEnumerable<Rec> Rec { get; set; }
        public IEnumerable<Signup> Signup { get; set; }
    }
}
