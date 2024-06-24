using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutVM;
using SignalRWebUI.ViewModels.SliderVM;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {

        readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Sliders");

            
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderVM>>(jsonData);

                return View(values);

        }
    }
}
