using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
		int MessageCountByStatusFalse();
		void MessageChangeToTrue(int id);
		void MessageChangeToFalse(int id);
		List<Message> GetAllMessageByFalse();
	}
}
