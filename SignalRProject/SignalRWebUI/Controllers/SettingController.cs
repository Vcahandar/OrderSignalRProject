using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.ViewModels.IdentityVM;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);

		

			UserEditVM userEditVM = new UserEditVM();
			userEditVM.Name = values.Name;
			userEditVM.Surname = values.Surname;
			userEditVM.Username = values.UserName;
			userEditVM.Email = values.Email;

			return View(userEditVM);
		}



		[HttpPost]
		public async Task<IActionResult> Index(UserEditVM userEditVM)
        {
            if (userEditVM.Password == userEditVM.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = userEditVM.Name;
				user.Surname = userEditVM.Surname;
				user.UserName = userEditVM.Username;
				user.Email = userEditVM.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditVM.Password);
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index","Category");
			}

			return View();

		}

	}
}
