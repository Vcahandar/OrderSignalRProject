using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.SliderVM;
using SignalRWebUI.ViewModels.TestimonialVM;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {

        readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Testimonial");


            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialVM>>(jsonData);

            return View(values);

        }
    }
}
