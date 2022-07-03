using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Services.Models
{
    public class Price
    {
        public string Currency { get; set; }

        //[JsonProperty("previous_close")]
        public double Previous_Close { get; set; }
        public Last Last { get; set; }
    }

    public class Last
    {
        public double Value { get; set; }
    }
}
