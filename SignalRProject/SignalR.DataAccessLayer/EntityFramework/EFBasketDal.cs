using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;


namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EFBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
           using var context = new SignalRContext();
            var values = context.Baskets.Where(x=>x.MenuTableId == id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}
