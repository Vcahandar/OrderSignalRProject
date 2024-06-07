using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.TestimonialVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class TestimonialController : Controller
	{
		readonly IHttpClientFactory _httpClientFactory;

		public TestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7172/api/Testimonial");

			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData = await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialVM>>(jsonData);

				return View(values);
			}
			return View();
		}



		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialVM createTestimonialVM)
		{
			createTestimonialVM.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createTestimonialVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:7172/api/Testimonial", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}


		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Testimonial/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Testimonial/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateTestimonialVM>(jsonData);

				return View(values);
			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialVM updateTestimonialVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateTestimonialVM);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/Testimonial/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
