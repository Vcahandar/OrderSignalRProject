using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutVM;
using SignalRWebUI.ViewModels.BookingVM;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {

        readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingVM createBookingVM)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingVM);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7172/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }

            return View();

        }
    }
}
