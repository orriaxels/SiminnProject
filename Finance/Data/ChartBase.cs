using DevExpress.Blazor;
using Finance.Services.Models;
using Finance.Services.Services;
using Microsoft.AspNetCore.Components;

namespace Finance.Data
{
	public class ChartBase : ComponentBase
	{
		[Inject]
		public IFinanceService FinanceService { get; set; }

		public Stock stock { get; set; }
		public List<Month> months { get; set; }
		public List<Month> tempMonths { get; set; }
		public DxChart<Month> chart;
		public bool lastMonth = true;

		protected override async Task OnInitializedAsync()
		{
			stock = await FinanceService.GetStock("ABNB:NASDAQ");
			months = stock.Charts.Month;
		}

		private async Task<Stock> GetStock(string ticker)
		{
			stock = await FinanceService.GetStock(ticker);
			months = stock.Charts.Month;

			return stock;
		}
		public async Task ClickHandler(string ticker)
		{
			stock = await GetStock(ticker);
			lastMonth = true;
		}

		public void GetLastSevenDays()
		{
			if(months.Any())
			{
				if (lastMonth)
				{
					tempMonths = months.GetRange(0, months.Count);
					months.RemoveRange(0, months.Count - 7);
					lastMonth = !lastMonth;
					chart.RefreshData();
				}
			}
			
		}

		public void GetLastMonth()
		{
			if (months.Any())
			{
				if (!lastMonth)
				{
					months = tempMonths;
					lastMonth = !lastMonth;
					chart.RefreshData();
				}
			}
		}


	}
}
