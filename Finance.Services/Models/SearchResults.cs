namespace Finance.Services.Models
{
    public class SearchResults
    {

		public string Title { get; set; }
        public string Ticker { get; set; }
    }

    public class Results
	{
        public List<Info> Info { get; set; }
        public List<Price> Price { get; set; }
    }
}
