using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.DiscountVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DiscountController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

		public DiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7172/api/Discount");

			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDiscountVM>>(jsonData);

				return View(values);
			}
			return View();
		}



		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountVM createDiscountVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7172/api/Discount", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}


		public async Task<IActionResult> DeleteDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Discount/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Discount/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDiscountVM>(jsonData);

				return View(values);
			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountVM updateDiscountVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/Discount/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
