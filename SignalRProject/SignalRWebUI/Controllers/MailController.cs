using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.ViewModels.MailVM;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateMailVM createMailVM)
		{
			var mimeMessage = new MimeMessage();

			var mailboxAddressFrom = new MailboxAddress("SignalR Reservation", "cvelibeyli@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			var mailboxAddressTo = new MailboxAddress("User", createMailVM.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder
			{
				TextBody = createMailVM.Body
			};
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = createMailVM.Subject;

			using (var smtpClient = new SmtpClient())
			{
				await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
				await smtpClient.AuthenticateAsync("cvelibeyli@gmail.com", "vvpd uogn huke yqfn");

				await smtpClient.SendAsync(mimeMessage);
				await smtpClient.DisconnectAsync(true);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
