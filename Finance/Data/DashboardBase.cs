using Finance.Services.Models;
using Finance.Services.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Finance.Data
{
	public class DashboardBase : ComponentBase
	{
		[Inject]
		public IFinanceService FinanceService { get; set; }

        [Parameter]
        public EventCallback<string> OnClick { get; set; }

        public List<SearchResults> results;
        public string searchString { get; set; }
        public bool hasSearched { get; set; } = false;

		public void ClearResult()
        {
            results.Clear();
            searchString = "";
            hasSearched = false;
        }

        public async Task OnUserFinish(KeyboardEventArgs e)
        {
            await InvokeAsync(async () => {
                if (e.Key == "Enter")
                {
                    results = await FinanceService.Search(searchString);
                    hasSearched = true;
                    StateHasChanged();
                }
                else
                    hasSearched = false;
            });
        }
    }
}
