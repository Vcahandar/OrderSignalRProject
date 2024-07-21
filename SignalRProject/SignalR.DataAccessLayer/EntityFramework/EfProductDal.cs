using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values = context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
			using var context=new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where
			(y => y.Name == "Drinks").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where
			(y => y.Name == "Burgers").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price)))
				.Select(z => z.Name).FirstOrDefault();

		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price)))
				.Select(z => z.Name).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.Price);

		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x=>x.CategoryId == (context.Categories.Where(y=>y.Name=="Burgers")
			.Select(z=>z.CategoryId).FirstOrDefault())).Average(w=>w.Price);

		}

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.Name == "Drinks").Select(y => y.CategoryId).FirstOrDefault();
			return context.Products.Where(x => x.CategoryId == id).Sum(y => y.Price);

        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new SignalRContext();
            int id = context.Categories.Where(x => x.Name == "Salads").Select(y => y.CategoryId).FirstOrDefault();
            return context.Products.Where(x => x.CategoryId == id).Sum(y => y.Price);
        }

        public decimal TotalProductPrice()
        {
            using var context = new SignalRContext();
			var total = context.Products.Sum(x => x.Price);
			return total;
        }
    }
}
