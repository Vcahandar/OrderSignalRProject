using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutVM;
using SignalRWebUI.ViewModels.BasketVM;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Basket/BasketListByMenuTableWithProductName?id=2");

            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketVM>>(jsonData);

                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Basket/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NoContent();
        }



    }
}
