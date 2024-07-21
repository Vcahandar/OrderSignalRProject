namespace SignalRWebUI.ViewModels.InboxVM
{
	public class ResultInboxVM
	{
		public int MessageId { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool Status { get; set; }
	}
}
