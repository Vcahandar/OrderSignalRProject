namespace SignalRWebUI.ViewModels.InboxVM
{
	public class DetailInboxVM
	{
		public int MessageId { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public bool Status { get; set; }
		public DateTime MessageSendDate { get; set; }

	}
}
