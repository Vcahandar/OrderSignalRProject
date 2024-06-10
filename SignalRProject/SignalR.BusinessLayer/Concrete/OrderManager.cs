﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
				_orderDal = orderDal;
        }

		public int TActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public void TAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public Order TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Order> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public decimal TLastOrderPirce()
		{
			return _orderDal.LastOrderPirce();
		}

		public decimal TTodayTotalPrice()
		{
			return _orderDal.TodayTotalPrice();
		}

		public int TTotalOrderCount()
		{
			return _orderDal.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
