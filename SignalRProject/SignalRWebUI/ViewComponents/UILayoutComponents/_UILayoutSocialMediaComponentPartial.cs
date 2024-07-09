using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.SocialMediaVM;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial : ViewComponent
    {
            readonly IHttpClientFactory _httpClientFactory;

            public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

        public async  Task<IViewComponentResult> InvokeAsync()

        {
            var client = _httpClientFactory.CreateClient();
                var responseMassage = await client.GetAsync("https://localhost:7172/api/SocialMedia");

                if (responseMassage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMassage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultSocialMediaVM>>(jsonData);

                    return View(values);
                }
                return View();
            }
        }
    }
