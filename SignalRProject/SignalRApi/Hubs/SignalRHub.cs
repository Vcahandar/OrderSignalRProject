﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SignalRApi.Hubs
{
	public class SignalRHub :Hub
	{
		readonly ICategoryService _categoryService;
		readonly IProductService _productService;
		readonly IOrderService _orderService;
		readonly IMoneyCaseService _moneyCaseService;
		readonly IMenuTableService _menuTableService;
		readonly IBookingService _bookingService;
		readonly INotificationService _notificationService;
		readonly IMessageService _messageService;

        public SignalRHub(ICategoryService categoryService, 
							IProductService productService,
							IOrderService orderService,
							IMoneyCaseService moneyCaseService,
							IMenuTableService menuTableService,
                            IBookingService bookingService,
                            INotificationService notificationService,
							IMessageService messageService)
        {
            _categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
			_messageService = messageService;

        }


		public static int clientCount { get; set; } = 0;
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

		public async Task SendProgress()
		{
			var moneyCaseAmount = _moneyCaseService.TTotalMonetCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", moneyCaseAmount.ToString("0.00") + "$");

			var activeOrderCount = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

			var menuTableCount = _menuTableService.TMenuTabelCount();
            await Clients.All.SendAsync("ReceiveMenuTabelCount", menuTableCount);

            var productPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg);

            var productAvgPriceByHamburger = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", productAvgPriceByHamburger);

            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

			var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var totalPriceByDrinkCategory = _productService.TTotalPriceByDrinkCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", totalPriceByDrinkCategory);

            var totalPriceBySaladCategory = _productService.TTotalPriceBySaladCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", totalPriceBySaladCategory);

            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var bookingCount = _bookingService.TBookingCount();
			await Clients.All.SendAsync("ReceiveBookingCount", bookingCount);

            var productCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var totalProductPrice = _productService.TTotalProductPrice();
            await Clients.All.SendAsync("ReceiveTotalProductPrice", totalProductPrice);
        }

		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotificationService()
		{
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);

            var notifiactionListByFalse = _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationByFalse", notifiactionListByFalse);

			var messageCountByFalse = _messageService.TMessageCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveMessageCountByFalse", messageCountByFalse);

			var messageListByFalse = _messageService.TGetAllMessageByFalse();
			await Clients.All.SendAsync("ReceiveMessageByFalse", messageListByFalse);
		}

		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

		public async Task SendMassage(string user,string message)
		{

			await Clients.All.SendAsync("ReceiveMessage",user,message);
		}


        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }



    }
}
