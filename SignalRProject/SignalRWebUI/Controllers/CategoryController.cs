using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.ViewModels.CategoryVM;
using SignalRWebUI.ViewModels.ProdcutVM;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task <IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7172/api/Category");

            if (responseMassage.IsSuccessStatusCode)
            {
                var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(jsonData);

                return View(values);
            }
            return View();
        }



        [HttpGet]
        public IActionResult CreateCategory() 
        { 
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            createCategoryVM.Status = true;
			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryVM);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:7172/api/Category", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

		}


        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7172/api/Category/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        [HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7172/api/Category/{id}"); 

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<UpdateCategoryVM>(jsonData);

                return View(values);
			}

			return View();
		}


        [HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
			updateCategoryVM.Status = true;

			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryVM);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7172/api/Category/", stringContent);

            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }

            return View();

		}

	}
}
