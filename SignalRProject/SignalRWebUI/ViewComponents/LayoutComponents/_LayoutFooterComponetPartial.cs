using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterComponetPartial : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
