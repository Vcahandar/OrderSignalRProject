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
    public class EfMessageDal: GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(SignalRContext context) : base(context)
        {
        }

		public List<Message> GetAllMessageByFalse()
		{
			using var context = new SignalRContext();
			return context.Messages.Where(x => x.Status == false).ToList();
		}

		public void MessageChangeToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Messages.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void MessageChangeToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Messages.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public int MessageCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Messages.Where(x => x.Status == false).Count();
		}
	}
}
