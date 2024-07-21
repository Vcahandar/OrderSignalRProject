using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.AboutVM;
using SignalRWebUI.ViewModels.InboxVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class InboxController : Controller
	{

		readonly IHttpClientFactory _httpClientFactory;

		public InboxController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7172/api/Message");

			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultInboxVM>>(jsonData);

				return View(values);
			}
			return View();
		}



		public async Task<IActionResult> DeleteInbox(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Message/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}


		public async Task<IActionResult> DetailInbox(int id)
		{
			var client = _httpClientFactory.CreateClient();

			// Change message status to true
			var statusChangeResponse = await client.GetAsync($"https://localhost:7172/api/Message/MessageChangeToTrue/{id}");

			if (!statusChangeResponse.IsSuccessStatusCode)
			{
				// Log error or handle it
				ViewBag.ErrorMessage = "Failed to change message status.";
				return View("Error");
			}

			// Get message details
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Message/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<DetailInboxVM>(jsonData);

				return View(values);
			}

			// Log error or handle it
			ViewBag.ErrorMessage = "Failed to retrieve message details.";
			return View("Error");
		}






	}
}
