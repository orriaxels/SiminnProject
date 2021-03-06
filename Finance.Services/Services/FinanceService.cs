using Finance.Services.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Services.Services
{

    public interface IFinanceService
    {
        public Task<List<SearchResults>> Search(string searchString);
		public Task<Stock> GetStock(string stock);


	}
    public class FinanceService : IFinanceService
    {
		private string _key = "34d487137emsh873a55ac6506eebp13e8adjsne659eee0e7b2";
		private string _host = "google-finance4.p.rapidapi.com";

		public FinanceService() { }

		public async Task<List<SearchResults>> Search(string searchString)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://google-finance4.p.rapidapi.com/search/?q={searchString}&hl=en&gl=US"),
				Headers =
				{
					{ "X-RapidAPI-Key", _key },
					{ "X-RapidAPI-Host", _host },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				if(response.IsSuccessStatusCode)
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();

					List<SearchResults> results = new List<SearchResults>();

					if (!String.IsNullOrEmpty(body))
					{
						JArray jsonArr = JArray.Parse(body);

						for (int i = 0; i < jsonArr.Count; i++)
						{
							SearchResults temp = new SearchResults();
							temp.Title = jsonArr[i]["info"]["title"].ToString();
							temp.Ticker = jsonArr[i]["info"]["ticker"].ToString();

							results.Add(temp);
						}
					}
					return results;
				}
				return null;
			}
		}

		public async Task<Stock> GetStock(string stock)
		{
			var client = new HttpClient();
			Stock stockResponse = new Stock();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://google-finance4.p.rapidapi.com/ticker/?t={stock}&hl=en&gl=US"),
				Headers =
				{
					{ "X-RapidAPI-Key", _key },
					{ "X-RapidAPI-Host", _host },
				},
			};

			using (var response = await client.SendAsync(request))
			{
				if (response.IsSuccessStatusCode)
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();


					stockResponse = JsonConvert.DeserializeObject<Stock>(body);

					return stockResponse;
				}

				return null;
			}
		}

	}
}
