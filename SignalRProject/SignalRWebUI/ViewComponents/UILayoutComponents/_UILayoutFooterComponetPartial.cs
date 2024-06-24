using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.ContactVM;
using SignalRWebUI.ViewModels.SliderVM;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponetPartial : ViewComponent
    {

        readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Contact");


            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonData);

            return View(values);

        }
    }
}
