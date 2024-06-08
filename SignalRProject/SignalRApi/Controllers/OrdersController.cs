using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}

		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			return Ok(_orderService.TActiveOrderCount());
		}

		[HttpGet("LastOrderPirce")]
		public IActionResult LastOrderPirce()
		{
			return Ok(_orderService.TLastOrderPirce());
		}
	}
}
