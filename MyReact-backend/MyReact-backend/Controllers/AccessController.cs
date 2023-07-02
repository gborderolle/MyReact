using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyReact_backend.Models;
using MyReact_backend.Services;
using System.Security.Claims;
using DeviceDetectorNET.Parser;
using DeviceDetectorNET;

namespace MyReact_backend.Controllers
{
	[Route("api/Access")]
	[ApiController]
	public class AccessController : Controller
	{
		private readonly ServiceUser _serviceUser;
		private readonly ServiceLogin _serviceLogin;

		public AccessController(ServiceUser serviceUser, ServiceLogin serviceLogin)
		{
			_serviceUser = serviceUser;
			_serviceLogin = serviceLogin;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(VMLogin modelLogin)
		{
			// s: https://www.youtube.com/watch?v=uGoNCJf0t1g&ab_channel=CodeStudentNet
			User user = _serviceUser.Login(modelLogin);
			if (user != null)
			{
				List<Claim> claims = new()
				{
					new Claim(ClaimTypes.NameIdentifier, modelLogin.Username),
					new Claim("UserID", user.UserID.ToString()),
					new Claim("IsMobile", DetectMobile().IsMobile().ToString())
				};
				ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				AuthenticationProperties properties = new()
				{
					AllowRefresh = true,
					IsPersistent = modelLogin.KeepLoggedIn
				};
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

				_serviceLogin.MakerLogin(user.UserID);
				return RedirectToAction("Index", "Estate");
			}
			ViewData["ValidateMessage"] = "El usuario no existe";
			return View();
		}


		public IActionResult Login()
		{
			ClaimsPrincipal claimUser = HttpContext.User;
			if (claimUser.Identity != null)
			{
				if (claimUser.Identity.IsAuthenticated)
				{
					return RedirectToAction("Index", "Estate");
				}
			}
			return View();
		}

		private DeviceDetector DetectMobile()
		{
			DeviceDetector.SetVersionTruncation(VersionTruncation.VERSION_TRUNCATION_NONE);
			var userAgent = Request.Headers["User-Agent"]; // change this to the useragent you want to parse
			var headers = Request.Headers.ToDictionary(a => a.Key, a => a.Value.ToArray().FirstOrDefault());
			var deviceDetector = new DeviceDetector(userAgent);
			deviceDetector.Parse();
			return deviceDetector;
		}

	}
}
