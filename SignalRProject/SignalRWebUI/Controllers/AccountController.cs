using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.ViewModels.IdentityVM;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		readonly SignInManager<AppUser> _signInManager;

		public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			var appUser = new AppUser()
			{
				Name = registerVM.Name,
				Surname = registerVM.Surname,
				Email = registerVM.Mail,
				UserName = registerVM.Username
			};

			var result = await _userManager.CreateAsync(appUser, registerVM.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");

			}

			return View();
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM )
		{
			var result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			return View();
		}


		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}
	}
}
