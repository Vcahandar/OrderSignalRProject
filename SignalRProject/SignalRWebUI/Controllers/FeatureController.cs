using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.DiscountVM;
using SignalRWebUI.ViewModels.FeatureVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class FeatureController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7172/api/Feature");

			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureVM>>(jsonData);

				return View(values);
			}
			return View();
		}



		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureVM createFeatureVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7172/api/Feature", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}


		public async Task<IActionResult> DeleteFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Feature/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Feature/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureVM>(jsonData);

				return View(values);
			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureVM updateFeatureVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/Feature/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
