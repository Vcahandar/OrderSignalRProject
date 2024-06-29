using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		readonly IMenuTableService _menuTableService;
        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTabelCount());

		}



		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(values);
		}



		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable()
			{
				TableName = createMenuTableDto.TableName,
				Status = false,
			};

			_menuTableService.TAdd(MenuTable);
			return Ok("MenuTable section successfully added!");
		}



		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.TGetById(id);
			_menuTableService.TDelete(values);
			return Ok("MenuTable me field has been deleted!");
		}



		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable()
			{
				MenuTableId = updateMenuTableDto.MenuTableId,
				TableName = updateMenuTableDto.TableName,
				Status = false
			};

			_menuTableService.TUpdate(MenuTable);
			return Ok("MenuTable area has been updated");
		}



		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
