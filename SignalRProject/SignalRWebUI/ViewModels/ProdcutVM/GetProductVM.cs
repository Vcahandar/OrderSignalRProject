namespace SignalRWebUI.ViewModels.ProdcutVM
{
	public class GetProductVM
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
		public int CategoryId { get; set; }
	}
}
