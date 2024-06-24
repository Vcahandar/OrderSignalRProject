using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutVM;
using SignalRWebUI.ViewModels.SliderVM;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {

        readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7172/api/About");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutVM>>(jsonData);

            return View(values);
        }


    }
}
