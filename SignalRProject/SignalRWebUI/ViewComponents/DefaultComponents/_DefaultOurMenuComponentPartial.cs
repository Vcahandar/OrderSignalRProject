using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.DiscountVM;
using SignalRWebUI.ViewModels.ProdcutVM;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Product");
            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductVM>>(jsonData);

            return View(values);

        }
    }
}
