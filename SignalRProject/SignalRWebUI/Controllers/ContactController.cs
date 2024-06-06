using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.ContactVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ContactController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7172/api/Contact");

			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonData);

				return View(values);
			}
			return View();
		}



		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactVM createContactVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7172/api/Contact", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}


		public async Task<IActionResult> DeleteContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Contact/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Contact/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateContactVM>(jsonData);

				return View(values);
			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactVM updateContactVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/Contact/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
