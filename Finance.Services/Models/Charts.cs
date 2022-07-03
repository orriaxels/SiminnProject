using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Services.Models
{
    public class Charts
    {
        [JsonProperty("1month")]
        public List<Month> Month { get; set; }
    }

    public class Month
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
