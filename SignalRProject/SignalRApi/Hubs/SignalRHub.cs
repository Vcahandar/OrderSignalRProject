﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace SignalRApi.Hubs
{
	public class SignalRHub :Hub
	{
		readonly ICategoryService _categoryService;
		readonly IProductService _productService;
		readonly IOrderService _orderService;
		readonly IMoneyCaseService _moneyCaseService;
		readonly IMenuTableService _menuTableService;

        public SignalRHub(ICategoryService categoryService, 
							IProductService productService,
							IOrderService orderService,
							IMoneyCaseService moneyCaseService,
							IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
        }

        public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);

			var productCount = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", productCount);

			var active = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", active);

			var passive = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", passive);

			var productHamburgerCount = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburgerCount", productHamburgerCount);

			var productDrinkCount = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveroductCountByCategoryNameDrinkCount", productDrinkCount);

			var productPriceAvg = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00") + "$");

			var productNameMaxPrice = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameMaxPrice);

			var productNameMinPrice = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameMinPrice);

			var productAvgPriceHamburger = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", productAvgPriceHamburger.ToString("0.00") + "$");

			var totalOrderCount = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

			var activeOrderCount = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

			var lastOrderCount = _orderService.TLastOrderPirce();
			await Clients.All.SendAsync("ReceiveLastOrderPirce", lastOrderCount.ToString("0.00") + "$");

			var totalMoneyCaseAmount = _moneyCaseService.TTotalMonetCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + "$");

			var menuTabelCount = _menuTableService.TMenuTabelCount();
			await Clients.All.SendAsync("ReceiveMenuTabelCount", menuTabelCount);

		}


	}
}
