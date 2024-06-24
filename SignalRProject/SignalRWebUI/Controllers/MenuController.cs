using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.BasketVM;
using SignalRWebUI.ViewModels.ProdcutVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Product");
            var jsonData = await responseMassage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductVM>>(jsonData);

            return View(values);

        }



        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketVM createBasketVM = new CreateBasketVM();
            createBasketVM.ProductId= id;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketVM);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7172/api/Basket", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketVM);
        }
    }
}
