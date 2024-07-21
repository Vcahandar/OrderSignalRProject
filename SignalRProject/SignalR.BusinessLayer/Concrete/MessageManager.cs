using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

		public List<Message> TGetAllMessageByFalse()
		{
			return _messageDal.GetAllMessageByFalse();
		}

		public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

		public void TMessageChangeToFalse(int id)
		{
			_messageDal.MessageChangeToFalse(id);
		}

		public void TMessageChangeToTrue(int id)
		{
			_messageDal.MessageChangeToTrue(id);
		}

		public int TMessageCountByStatusFalse()
		{
			return _messageDal.MessageCountByStatusFalse();
		}

		public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
