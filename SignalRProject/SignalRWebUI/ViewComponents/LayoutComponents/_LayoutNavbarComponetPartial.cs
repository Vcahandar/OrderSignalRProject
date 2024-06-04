using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarComponetPartial:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
