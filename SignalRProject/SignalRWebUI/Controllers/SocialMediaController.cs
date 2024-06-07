using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.SocialMediaVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class SocialMediaController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

		public SocialMediaController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
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



		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaVM createSocialMediaVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSocialMediaVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7172/api/SocialMedia", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}


		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/SocialMedia/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/SocialMedia/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSocialMediaVM>(jsonData);

				return View(values);
			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaVM updateSocialMediaVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSocialMediaVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/SocialMedia/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
