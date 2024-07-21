using SignalR.EntityLayer.Entities;


namespace SignalR.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
		int TMessageCountByStatusFalse();
		void TMessageChangeToTrue(int id);
		void TMessageChangeToFalse(int id);
		List<Message> TGetAllMessageByFalse();

	}
}
