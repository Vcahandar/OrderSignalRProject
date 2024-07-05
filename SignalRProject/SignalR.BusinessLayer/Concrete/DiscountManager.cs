using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;


namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        readonly IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal= discountDal;
        }

        public void TChangeStatusToFalse(int id)
        {
            _discountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
           _discountDal.ChangeStatusToTrue(id);
        }

        public void TAdd(Discount entity)
        {
           _discountDal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount TGetById(int id)
        {
           return _discountDal.GetById(id);
        }

        public List<Discount> TGetListAll()
        {
          return  _discountDal.GetListAll();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }

		public List<Discount> TGetListByStatusTrue()
		{
			return _discountDal.GetListByStatusTrue();
		}
	}
}
