using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Services.Models
{
    public class Stock
    {
        public Info Info { get; set; }
        public Charts Charts { get; set; }
        public About About { get; set; }
        public Price Price { get; set; }
    }

    public class Stocks
    {
        public Info Info { get; set; }
        public List<Charts> Charts { get; set; }
        public About About { get; set; }
        public Price Price { get; set; }
    }
}
