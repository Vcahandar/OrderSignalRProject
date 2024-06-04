using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptComponetPartial : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
